using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BookingForm.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;
using reCAPTCHA.AspNetCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace BookingForm
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
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            services.Configure<RecaptchaSettings>(Configuration.GetSection("RecaptchaSettings"));
            services.AddTransient<IRecaptchaService, RecaptchaService>();
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

            services.AddDistributedMemoryCache();

            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.AddIdentity<Sale, Role>()
                .AddEntityFrameworkStores<BookingFormContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            //services.AddSingleton<IEmailService, EmailService>()

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
            });

            services.AddMvc(config =>
            {
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddSessionStateTempDataProvider();


            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            });

            services.AddDbContext<BookingFormContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("BookingFormContext")));

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = "Cookies";
            //    options.DefaultChallengeScheme = "oidc";
            //})
            //    .AddCookie("Cookies")
            //    .AddOpenIdConnect("oidc", options =>
            //    {
            //        options.SignInScheme = "Cookies";

            //        options.Authority = "https://id.annhome.vn/";
            //        options.RequireHttpsMetadata = false;

            //        options.ClientId = "mvc";
            //        options.SaveTokens = true;
            //        options.ClientSecret = "secret";
            //        options.ResponseType = "code id_token";

            //        options.SaveTokens = true;
            //        options.GetClaimsFromUserInfoEndpoint = true;

            //        options.Scope.Add("booking");
            //        options.Scope.Add("offline_access");
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}
            //app.UseExceptionHandler("/Error");
            //app.UseHsts();
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //CreateRoles(serviceProvider).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles   
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<Sale>>();
            string[] roleNames = { "Administrator", "Manager", "Sale", "TelSale", "Leader", "TeamLeader", "Collaborator" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1  
                    roleResult = await RoleManager.CreateAsync(new Role() { Name = roleName });
                }
            }

            //Sale user = await UserManager.FindByEmailAsync("huong.ngo@annhome.vn");

            //await UserManager.AddToRoleAsync(user, "Administrator");

            //Sale user1 = await UserManager.FindByEmailAsync("nguyenphungkieu2106@gmail.com");

            //await UserManager.AddToRoleAsync(user1, "Sale");

            //Sale user2 = await UserManager.FindByEmailAsync("nguyendinhhoangboss@gmail.com");

            //await UserManager.AddToRoleAsync(user2, "Sale");

            //Sale user3 = await UserManager.FindByEmailAsync("vinh.hoang@annhome.vn");

            //await UserManager.AddToRoleAsync(user3, "Leader");

            //Sale user4 = await UserManager.FindByEmailAsync("kai.pham@annhome.vn");

            //await UserManager.AddToRoleAsync(user4, "TeamLeader");

            //Sale user5 = await UserManager.FindByEmailAsync("truong.nguyen@gmail.com");

            //await UserManager.AddToRoleAsync(user5, "TeamLeader");

            //Sale user6 = await UserManager.FindByEmailAsync("nguyendinhhoangboss@gmail.com");

            //await UserManager.AddToRoleAsync(user6, "Sale");

            //Sale user7 = await UserManager.FindByEmailAsync("tom.nguyen@annhome.vn");

            //await UserManager.AddToRoleAsync(user7, "Sale");

            //Sale user8 = await UserManager.FindByEmailAsync("clinton.hoang@annhome.vn");

            //await UserManager.AddToRoleAsync(user8, "Sale");

            //Sale user9 = await UserManager.FindByEmailAsync("clinton.pham@annhome.vn");

            //await UserManager.AddToRoleAsync(user9, "Sale");

            //Sale user10 = await UserManager.FindByEmailAsync("clinton.than@annhome.vn");

            //await UserManager.AddToRoleAsync(user10, "Sale");

            //Sale user11 = await UserManager.FindByEmailAsync("hongminhgraphic@gmail.com");

            //await UserManager.AddToRoleAsync(user11, "Sale");

            //Sale user12 = await UserManager.FindByEmailAsync("tranngoc20988@gmail.com");

            //await UserManager.AddToRoleAsync(user12, "Sale");

            //Sale user13 = await UserManager.FindByEmailAsync("philip.pham@annhome.vn");

            //await UserManager.AddToRoleAsync(user13, "Sale");

            //Sale user14 = await UserManager.FindByEmailAsync("victory.le@annhome.vn");

            //await UserManager.AddToRoleAsync(user14, "Sale");

            //Sale user15 = await UserManager.FindByEmailAsync("hang.le@annhome.vn");

            //await UserManager.AddToRoleAsync(user15, "Manager");

            //Sale user16 = await UserManager.FindByEmailAsync("victory.le@annhome.vn");

            //await UserManager.AddToRoleAsync(user16, "Sale");

            //Sale user17 = await UserManager.FindByEmailAsync("admin@ilagroup.com.vn");

            //await UserManager.AddToRoleAsync(user17, "Sale");

            //Sale user18 = await UserManager.FindByEmailAsync("clinton.vu@annhome.vn");

            //await UserManager.AddToRoleAsync(user18, "Sale");

            //Sale user16 = await UserManager.FindByEmailAsync("nguyenphungkieu2106@gmail.com"); //clinton.vu @annhome.vn

            //await UserManager.AddToRoleAsync(user16, "Sale");

        }
    }
}
