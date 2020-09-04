using System;
using System.IO;
using System.Linq;
using AutoMapper;
using ClepsydraLite.API.Options;
using ClepsydraLite.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ClepsydraLite.DAL.Services;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ClepsydraLite.API
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

            // Add db services.
            services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors();

            services.AddScoped<IShopRepository, ShopRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Register the Swagger generator, defining 1 or more Swagger documents
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    options.CustomSchemaIds(x => x.FullName);

                    // including comments from XML documentation files from the root directory
                    var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                    xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiDescriptionGroupCollectionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
                options
                    .WithOrigins("http://localhost:8080",
                        "http://localhost:8901",
                        "http://localhost:8902",
                        "http://localhost:8910",
                        "http://localhost:8911",
                        "http://localhost:8912")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseStaticFiles();

            //Configure Swagger
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API group name
                    foreach (var description in provider.ApiDescriptionGroups.Items.OrderBy(t => t.GroupName))
                    {
                        var groupDescription = !string.IsNullOrEmpty(description.GroupName) ? description.GroupName : "UnGrouped";

                        options.SwaggerEndpoint($"/swagger/{groupDescription}/swagger.json", groupDescription);
                    }

                    options.InjectStylesheet("/css/custom-swagger.css");
                });
        }
    }
}
