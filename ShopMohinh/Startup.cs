using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
//using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopMohinh.Models;
using ShopMohinh.Models.IRepository;
using ShopMohinh.Models.Repository;
using ShopMohinh.Service;
using ShopMohinh.Settings;

namespace ShopMohinh
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
            services.AddControllersWithViews();
            //them chuoi ket noi EFContext
            services.AddDbContext<EFContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Connection")));

            services.AddMvc(option => option.EnableEndpointRouting = false); // config cho route
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly); //Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection -Version 8.1.0
            //add Install-Package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation -Version 3.1.9
            services.AddRazorPages().AddRazorRuntimeCompilation();

            //tao moi lien ket AddScoped<> giua Interface va Repository
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IOrderBillRepository, OrderBillRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<INewRepository, NewRepository>();

            #region cauhinhIdentity
            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<EFContext>()
                    .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Thiết lập về Password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

                // Cấu hình Lockout - khóa User
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lần thì khóa
                options.Lockout.AllowedForNewUsers = true;

                // Cấu hình về User.
                options.User.AllowedUserNameCharacters = // Các ký tự đặt tên User
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;  // Email là duy nhất

                // Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = false;  // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false; // Xác thực số điện thoại

            });
            #endregion


            #region Session
            services.AddSession(options =>
            { // ĐỂ LÀM GIỎ HÀNG
                // thời gian tồn tại của Session trên Server
                // ram bộ nhớ trên máy đầy => quy định phút, hoặc giờ
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            #endregion

            services.ConfigureApplicationCookie(options => // cấu hình trang AccessDenied khi tài khoản không được cấp quyền vào page admin
            {
                //options.AccessDeniedPath = new PathString("Administration/AccessDenied");
            });


            services.Configure<MailSettings>(Configuration.GetSection("MailSettings")); // bên appsetting.json á

            services.AddTransient<IMailService, ShopMohinh.Service.MailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseSession(); // SESSION


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
