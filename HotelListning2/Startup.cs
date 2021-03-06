using AspNetCoreRateLimit;
using HotelListning2.Configurations;
using HotelListning2.Data;
using HotelListning2.IRepository;
using HotelListning2.Repository;
using HotelListning2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
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
using System.Threading.Tasks;

namespace HotelListning2
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

            services.AddDbContext<DatabaseContaxt>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMemoryCache();

            services.ConfigureRateLimiting();
            services.AddHttpContextAccessor();

            services.ConfigureHttpCacheHeaders();

            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfiguewJWT(Configuration);

            services.AddCors(o =>
            {
                o.AddPolicy("AllowAll", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            services.AddAutoMapper(typeof(MapperInitilizer));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthManager, AuthManager>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelListning2", Version = "v1" });
            });

            services.AddControllers(config =>
            {
                config.CacheProfiles.Add("120SecondsDuration", new CacheProfile { Duration = 120 });
            }).AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.ConfigureVersioning();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelListning2 v1"));

            app.UseHttpsRedirection();
            app.ConfigureExceptionHandler();
            app.UseCors("AllowAll");

            app.UseResponseCaching();
            //app.UseHttpCacheHeaders();
            //app.UseIpRateLimiting();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
