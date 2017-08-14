using Microsoft.Extensions.DependencyInjection;
using MOS_CBT_CoreMgt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_CBT_CoreMgt.Services
{
    public class ServicesPublisher
    {
        public static void Publish(IServiceCollection services)
        {
            services.AddTransient<IProfile, ProfileService>();
            services.AddTransient<ICourse, CoursesService>();
            services.AddTransient<IQuestionAnswer, QuestionAnswerService>();
            services.AddTransient<IResult, ResultService>();
        }
    }
}
