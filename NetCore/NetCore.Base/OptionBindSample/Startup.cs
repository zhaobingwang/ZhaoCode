using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OptionBindSample
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Class>(Configuration);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //mvc中使用如下：使用默认路由
            app.UseMvcWithDefaultRoute();

            //mvc中不使用以下代码
            //app.Run(async (context) =>
            //{
            //    var myClass = new Class();
            //    Configuration.Bind(myClass);
            //    await context.Response.WriteAsync($"ClassNo:{myClass.ClassNo}");
            //    await context.Response.WriteAsync($"ClassDesc:{myClass.ClassDesc}");
            //    await context.Response.WriteAsync($"StudentCount:{myClass.Students.Count}");
            //});
        }
    }
}
