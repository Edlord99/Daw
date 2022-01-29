using DAW.Data;
using DAW.Repository.DatabaseRepository;
using DAW.Services;
using DAW.Utilities;
using DAW.Utilities.JWT;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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

namespace DAW
{
    public class Startup
    {
        private string CorsAllowSpecificOrigin = "frontendAllowOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DAW", Version = "v1" });
            });

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<DAWContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // inregistram toate repository-urile si toate serviciile (pt dependency injection)
            // transient: la fiecare injectare o instanta noua!
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IDetailsRepository, DetailsRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IShopRepository, ShopRepository>();


            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IDetailsService, DetailsService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IShopService, ShopService>();


            services.AddScoped<IJWT, JWT>();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddCors(option =>
            {
                option.AddPolicy(name: CorsAllowSpecificOrigin,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });

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
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyApi");
                c.RoutePrefix = string.Empty;
            });

            app.Use(async (c, n) => {
                c.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                await n.Invoke();
            });


            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


            app.UseHttpsRedirection();
            app.UseMiddleware<JWTMiddleware>();
            app.UseMvc();
        }
    }
}
