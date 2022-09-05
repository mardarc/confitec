using Confitec.Data.EF;
using Confitec.Recursos.Comandos.Usuarios;
using Confitec.Recursos.Consultas.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Confitec_Pleno
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<ConfitecContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConfitecConnection"), 
                                                                                    b => b.MigrationsAssembly(typeof(ConfitecContext).Assembly.FullName)));

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(ConsultaListUsuarios).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ConsultaGetUsuario).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ComandoCreateUsuario).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ComandoDeleteUsuario).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ComandoUpdateUsuario).GetTypeInfo().Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Confitec_Pleno", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Confitec_Pleno v1"));
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

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
