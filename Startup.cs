using EmagClone.Entities;
using EmagClone.Options;
using EmagClone.Seeders;
using EmagClone.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OldIronIronWeTake.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldIronIronWeTake
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
            services.AddTransient<FavoritesService>();
            services.AddTransient<CartService>();
            services.AddTransient<ReviewService>();
            services.AddTransient<ProductService>();
            services.AddTransient<ISeeder, InitialSeeder>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("EmagClone")));
            services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
           {
               // Password settings
               options.Password.RequireDigit = true;
               options.Password.RequiredLength = 8;
               options.Password.RequireNonAlphanumeric = false;
               options.Password.RequireUppercase = true;
               options.Password.RequireLowercase = false;
               options.Password.RequiredUniqueChars = 6;

               // Lockout settings
               options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
               options.Lockout.MaxFailedAccessAttempts = 10;
               options.Lockout.AllowedForNewUsers = true;

               // User settings
               options.User.RequireUniqueEmail = true;
           });

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Facebook:Id"];
                facebookOptions.AppSecret = Configuration["Facebook:Secret"];
            });


            services.AddAuthentication()
        .AddGoogle(options =>
        {
            options.ClientId = Configuration["Google:Id"];
            options.ClientSecret = Configuration["Google:Secret"];
        });

            // Add application services.
            services.AddTransient<IEmailSender, MailKitEmailSender>();
            services.Configure<MailKitEmailSenderOptions>(options =>
            {
                options.Host_Address = "smtp.gmail.com";
                options.Host_Port = 587;
                options.Host_Username = "emagemag43@gmail.com";
                options.Host_Password = Configuration["SmtpPass"];
                options.Sender_Email = "emagemag43@gmail.com";
                options.Sender_Name = "Emag Emag";
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
