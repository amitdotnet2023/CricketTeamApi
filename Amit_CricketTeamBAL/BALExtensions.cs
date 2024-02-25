using Amit_CricketTeamBAL.Interfaces;
using Amit_CricketTeamBAL.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amit_CricketTeamBAL
{
    public static class BALExtensions
    {
        public static IServiceCollection AddBusinessAccessExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICricketTeamServices, CricketTeamServices>();
            return services;
        }
    }
}
