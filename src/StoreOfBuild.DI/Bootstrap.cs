using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreOfBuild.Data;
using StoreOfBuild.Data.Contexts;
using StoreOfBuild.Data.Identity;
using StoreOfBuild.Data.Repositories;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Account;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Domain.Sales;

namespace StoreOfBuild.DI {
    public class Bootstrap {
        public static void Configure (IServiceCollection services, string connectionString) {
            services.AddDbContext<ApplicationDbContext> (options => options.UseSqlServer (connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole> (config => {
                    config.Password.RequireDigit = false;
                    config.Password.RequiredLength = 3;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext> ()
                .AddDefaultTokenProviders ();

            services.AddAuthentication (CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie (options => {
                    options.LoginPath = "/Account/Login/";
                });

            services.AddTransient (typeof (IRepository<>), typeof (Repository<>));
            services.AddTransient (typeof (IRepository<Product>), typeof (ProductRepository));
            services.AddTransient (typeof (IAuthentication), typeof (Authentication));
            services.AddTransient (typeof (IManager), typeof (Manager));
            services.AddTransient (typeof (CategoryStorer));
            services.AddTransient (typeof (ProductStorer));
            services.AddTransient (typeof (SaleFactory));
            services.AddTransient (typeof (IUnitOfWork), typeof (UnitOfWork));

        }
    }
}