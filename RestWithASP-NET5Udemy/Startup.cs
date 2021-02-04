using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RestWithASP_NET5Udemy.Model.Context;
using RestWithASP_NET5Udemy.Business.Implementations;
using Microsoft.EntityFrameworkCore;
using RestWithASP_NET5Udemy.Repository.Implementations;

namespace RestWithASP_NET5Udemy
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestWithASP_NET5Udemy", Version = "v1" });
            });

            //variável responsável por ler o arquivo appsettings.json e pegar a conexão com o banco de dados.
            var lconnection = Configuration["ConnectionStrings:SqlServerConnectionString"];

            //foi necessário instalar o pacote nuget Microsoft.EntityFrameworkCore.SqlServer
            services.AddDbContext<SQLServerContext>(options => options.UseSqlServer(lconnection));

            //antes era addsingleton mas estava dando erro, mudamos para Addscopped
            services.AddScoped<Business.IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<Repository.IPersonRepository, PersonRepositoryImplementation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestWithASP_NET5Udemy v1"));
            }

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
