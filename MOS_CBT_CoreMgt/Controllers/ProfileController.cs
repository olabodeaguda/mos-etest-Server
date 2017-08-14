using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOS_CBT_CoreMgt.Models;
using MOS_CBT_CoreMgt.Services.Interfaces;
using MOS_CBT_CoreMgt.Utilities;

namespace MOS_CBT_CoreMgt.Controllers
{
    [Produces("application/json")]
    [Route("api/Profile")]
    public class ProfileController : Controller
    {
        private readonly IProfile profileService;
        public ProfileController(IProfile _profileService)
        {
            this.profileService = _profileService;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            List<Profile> profiles = await this.profileService.All();
            return Ok(profiles.Select(x => new Profile
            {
                id = x.id,
                username = x.username,
                firstname = x.firstname,
                lastname = x.lastname,
                dateCreated = x.dateCreated,
                status = x.status,
                surname = x.surname
            }));
        }

        [Route("validate")]
        [HttpPost]
        public async Task<IActionResult> Validate([FromBody]LoginModel loginModel)
        {
            Profile profile = await this.profileService.ByUsername(loginModel.username);

            if (profile == null)
            {
                return NotFound(new Response() { code = HTTPStatusCode.NOT_FOUND, msg = $"{loginModel.username} does not exist" });
            }
            if (profile.status != ProfileStatus.ACTIVE.ToString())
            {
                return BadRequest(new Response() { code = HTTPStatusCode.FAILED, msg = $"{loginModel.username} is not active, contact administrator for help" });
            }
            if (profile.pwd != loginModel.pwd)
            {
                return BadRequest(new Response() { code = HTTPStatusCode.FAILED, msg = "Password is incorrect" });
            }
            profile.pwd = string.Empty;
            Response response = new Response()
            {
                code = HTTPStatusCode.SUCCESS,
                msg = "Successfull",
                data = profile
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Profile profile)
        {
            bool s = await this.profileService.Add(profile);
            if (s)
            {
                return Created("api/profile", new Response()
                {
                    code = "00",
                    msg = "User have been ssuccessfull"
                });
            }
            else
            {
                return StatusCode(500, new Response() { code = "01", msg = "An Error occur while processing the request. Please try again or contact administrator" });
            }
        }

        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> update([FromBody]Profile profile)
        {
            bool s = await this.profileService.Update(profile);
            if (s)
            {
                return Created("api/profile", new Response()
                {
                    code = "00",
                    msg = "User have been ssuccessfull"
                });
            }
            else
            {
                return StatusCode(500, new Response() { code = "01", msg = "An Error occur while processing the request. Please try again or contact administrator" });
            }
        }

        [Route("updatestatus")]
        [HttpPost]
        public async Task<IActionResult> ChangeStatus([FromBody]Profile profile)
        {
            bool s = await this.profileService.ChangeStatus(profile);
            if (s)
            {
                return Created("api/profile", new Response()
                {
                    code = "00",
                    msg = "User have been ssuccessfull"
                });
            }
            else
            {
                return StatusCode(500, new Response() { code = "01", msg = "An Error occur while processing the request. Please try again or contact administrator" });
            }
        }
    }
}