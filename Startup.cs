using Book_Store.Data;
using Book_Store.Models;
using Book_Store.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(options=>options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<BookStoreContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;



            });
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.Configure<NewBookAlertConfig>("InternalBook",_configuration.GetSection("NewBookAlert"));
            services.Configure<NewBookAlertConfig>("ThirdPartyBook", _configuration.GetSection("ThirdPartyBook"));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(); //For static files like wwwroot folder files


            app.UseAuthentication();
           

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
               endpoints.MapDefaultControllerRoute();

                //endpoints.MapControllerRoute(
                //    name: "Default",
                //    pattern: "bookApp/{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
