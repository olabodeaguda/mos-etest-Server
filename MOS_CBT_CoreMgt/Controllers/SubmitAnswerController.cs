using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOS_CBT_CoreMgt.Models;
using MOS_CBT_CoreMgt.Utilities;
using MOS_CBT_CoreMgt.Services.Interfaces;

namespace MOS_CBT_CoreMgt.Controllers
{
    [Produces("application/json")]
    [Route("api/SubmitAnswer")]
    public class SubmitAnswerController : Controller
    {
        private readonly IQuestionAnswer submitAnswerService;
        private readonly IProfile profileService;
        private readonly IResult resultService;
        public SubmitAnswerController(IQuestionAnswer _submitAnswerService,
            IProfile _profileService, IResult _resultService)
        {
            this.submitAnswerService = _submitAnswerService;
            this.profileService = _profileService;
            this.resultService = _resultService;
        }

        // POST: api/SubmitAnswer
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SubmitAnswerModel subAnswer)
        {
            if (subAnswer.answers.Length <= 0)
            {
                return BadRequest(new Response() { code = HTTPStatusCode.BAD_CREDENTIALS, msg = "Answers can't be empty" });
            }

            Profile profile = await profileService.ByUsername(subAnswer.username);

            if (profile == null)
            {
                return BadRequest(new Response() { code = HTTPStatusCode.BAD_REQUEST, msg = "Username does not exist" });
            }
            if (profile.status != ProfileStatus.ACTIVE.ToString())
            {
                return BadRequest(new Response() { code = HTTPStatusCode.BAD_REQUEST, msg = $"{subAnswer.username} is not active" });
            }

            Response response = await this.submitAnswerService.ComputeResult(subAnswer);

            if (response.code != HTTPStatusCode.SUCCESS)
            {
                return BadRequest(response);
            }

            Result result = new Result()
            {
                dateCreated = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),
                score = response.resultInt,
                userId = profile.id,
                username = subAnswer.username
            };
            bool res = await this.resultService.add(result);

            if (res)
            {
                profile.status = ProfileStatus.LOCKED.ToString();
                //update user status
                bool r = await this.profileService.ChangeStatus(profile);
                if (!r)
                {
                    //log exception
                }

                return Ok(new { code = HTTPStatusCode.SUCCESS, msg = "Exam have been submitted successfully" });
            }
            else
            {
                return BadRequest(new { code = HTTPStatusCode.FAILED, msg = "An Error occur. Please try again or contact admin" });
            }
        }
    }
}
