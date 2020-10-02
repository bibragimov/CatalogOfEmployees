using AutoMapper;
using CatalogOfEmployees.BusinessLogic.Domain.Services;
using CatalogOfEmployees.BusinessLogic.Services;
using CatalogOfEmployees.Domain.Ef;
using CatalogOfEmployees.Domain.Ef.Repositories;
using CatalogOfEmployees.Domain.Ef.UnitOfWork;
using CatalogOfEmployees.Domain.Repositories;
using CatalogOfEmployees.Domain.UnitOfWork;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CatalogOfEmployees
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EmployeesDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EmployeesContext")));

            services.AddControllers()
                .AddFluentValidation(x => { x.RegisterValidatorsFromAssemblyContaining<Startup>(); });

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen();

            services.AddOptions();
            services.Configure<CsrInformationOptions>(Configuration.GetSection("CsrInformationOptions"));

            services.AddSpaStaticFiles(config => { config.RootPath = "ClientApp/dist"; });

            services.AddScoped<DbContext, EmployeesDataContext>();
            services.AddScoped(typeof(IReader<>), typeof(Reader<>));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWorkFactory, EntityFrameworkUnitOfWorkFactory>();

            services.AddScoped<IEmployeeService, EmployeeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EmployeesDataContext dbContext)
        {
            dbContext.Database.Migrate();

            if (env.IsDevelopment()) 
                app.UseDeveloperExceptionPage();

            app.UseSpaStaticFiles();

            if (!env.IsDevelopment()) 
                app.UseSpaStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                    spa.UseAngularCliServer(npmScript: "start");
            });
        }
    }
}