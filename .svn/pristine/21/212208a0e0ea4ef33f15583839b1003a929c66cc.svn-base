using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaGateway.DL.Entities;
using eSyaGateway.DL.Repository;
using eSyaGateway.IF;
using eSyaGateway.WebAPI.Extention;
using eSyaGateway.WebAPI.Services;
using eSyaGateway.WebAPI.Utility;
using HCP.Gateway.DL.Repository;
using HCP.Gateway.IF;
using HCP.Gateway.WebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace eSyaGateway.WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //eSyaEnterprise._connString = Configuration.GetConnectionString("dbConn_eSyaEnterprise");
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpAuthAttribute));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IeSyaUserRepository, eSyaUserRepository>();
            services.AddScoped<IApplicationRulesRepository, ApplicationRulesRepository>();
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddScoped<ILocalizationRepository, LocalizationRepository>();
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<ISmsStatementRepository, SmsStatementRepository>();
            services.AddScoped<ISmsSender, SmsSender>();
            services.AddScoped<ISmsReminderRepository, SmsReminderRepository>();
            services.AddScoped<IRazorpayPaymentApi, RazorpayPaymentApi>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
