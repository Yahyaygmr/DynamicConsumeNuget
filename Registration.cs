using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicConsume
{
    public static class Registration
    {
        public static void AddDynamicConsume(this IServiceCollection services, string Url)
        {
            services.AddScoped(typeof(Consume<>));
            services.AddScoped<Consume>();
            services.AddHttpClient();
            ApiUrl.Urls = Url;
        }
    }
}
