using AutoMapper;
using DataManager.Context.Contracts;
using DataManager.Context.Implementation;
using DataManager.Repository.Contracts;
using DataManager.Repository.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Api.Extensions;
using Web.Api.Services.Palindrome.Processors;

namespace Web.Api
{
    public class Startup
    {
        private string _contentRootPath = "";
        public Startup(IHostingEnvironment env)
        {
            _contentRootPath = env.ContentRootPath;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            ConfigureAutoMapper(services);

            var dbConnection = Configuration.GetConnectionString("MyDBConnection");
            if (dbConnection.Contains("%CONTENTROOTPATH%"))
            {
                dbConnection = dbConnection.Replace("%CONTENTROOTPATH%", _contentRootPath);
            }

            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(dbConnection));

            services.AddSingleton<IMyDbContextFactory, MyDbContextFactory>();
            services.AddTransient<IMyDbContext, MyDbContext>();

			services.AddTransient<IPalindromeService, PalindromeService>();
            services.AddTransient<IPalindromeRepository, PalindromeRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        public void ConfigureAutoMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(configure =>
            {
                configure.AddProfile(new AutoMapperProfileConfiguration());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
