using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StatlerWaldorf.TeamService.Persistence;
using StatlerWaldorfCorp.TeamService.Persistence;

namespace  StartlerWaldorf
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }
        public void Configure(IApplicationBuilder app,
        IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello, world!");
            });
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<ITeamRepository, MemoryTeamRepository>();
        }
        
    }
   
}
