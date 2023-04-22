using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DTO;
using BLL;
using DAL.DALFolder;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace WebApiCore
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
            services.AddCors(p => p.AddPolicy("AllowAll", option =>
            {
                option.AllowAnyMethod();
                option.AllowAnyHeader();
                option.AllowAnyOrigin();
            }));

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;  
                o.MemoryBufferThreshold = int.MaxValue; 

            });

            services.AddScoped(typeof(IPeopleDAL), typeof(PeopleDAL));
            services.AddScoped(typeof(IPeopleBLL), typeof(PeopleBLL));

            services.AddScoped(typeof(IOccasionsDAL), typeof(OccasionsDAL));
            services.AddScoped(typeof(IOccasionBLL), typeof(OccasionsBLL));

            services.AddScoped(typeof(IOccasionTypeDAL), typeof(OccasionTypeDAL));
            services.AddScoped(typeof(IOccasionTypeBLL), typeof(OccasionTypeBLL));

            services.AddScoped(typeof(IInvitesDAL), typeof(InvitesDAL));
            services.AddScoped(typeof(IInvitesBLL), typeof(InvitesBLL));

            services.AddDbContext<DBcontext>(p => p.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database= C:\\Users\\אבוביץ\\Desktop\\פרויקט גמר\\DB\\Occasion.mdf;Trusted_Connection=True;"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseEndpoints(endPoints =>
            {
                endPoints.MapControllers();
            });
        }
    }
}
