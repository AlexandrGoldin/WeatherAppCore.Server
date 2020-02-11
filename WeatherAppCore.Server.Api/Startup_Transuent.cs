using BuissnesL;
using BuissnesL.Implementations;
using BuissnesL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using PresentationL.HangFireWeatherRequestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAppCore.Server.Api
{
    public partial class Startup
    {
        private void SetUpDependencies(IServiceCollection services)
        {
            services.AddTransient<ICityRepository, EFCityRepository>();
            services.AddTransient<IJsResponseRepository, EFJsResponseRepository>();
            services.AddTransient<IPushMessageRepository, EFPushMessageRepository>();
            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddTransient<IWeatherRepository, EFWeatherRepository>();
            services.AddTransient<IWeatherResponseRepository, EFWeatherResponseRepository>();
            services.AddTransient<IWindRepository, EFWindRepository>();

            services.AddScoped<DataManager>();

            services.AddScoped<IHangFireWeaserRequest, HangFireWeatherRequest>();
        }
    }
}
