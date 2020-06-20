using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RockPaperScissorsLizardSpock.Repository;

namespace RockPaperScissorsLizardSpock
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "RockPaperScissorsLizardSpock",
                        Version = "v1.0",
                        Description = "API para o jogo Pedra, Papel, Tesoura versão Nerd.\nOpções: [1 = Pedra | 2 = Papel | 3 = Tesoura | 4 = Lagarto | 5 = Spock]",
                        Contact = new OpenApiContact
                        {
                            Name = "Felipe Sartori",
                            Email = "felipe@sartori.app"
                        }
                    });
            });

            services.AddTransient<IGameOptions, GameOptions>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RockPaperScissorsLizardSpock v1.0");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
