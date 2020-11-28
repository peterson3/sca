using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using SCA.Barragens.API.Consumer;
using SCA.Barragens.API.DataStorage;
using SCA.Barragens.API.HubConfig;
using Steeltoe.Discovery.Client;
using System;
using System.IO;

namespace SCA.Barragens.API
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



            MongoDbContext.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            MongoDbContext.DatabaseName = Configuration.GetSection("MongoConnection:Database").Value;
            MongoDbContext.IsSSL = Convert.ToBoolean(this.Configuration.GetSection("MongoConnection:IsSSL").Value);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Barragens",
                        Version = "v1",
                        Description = "API REST criada com o ASP.NET Core",
                        Contact = new OpenApiContact
                        {
                            Name = "Peterson Andrade",
                            Url = new System.Uri("https://github.com/peterson3")
                        }
                    });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });


            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy", builder => {
            //        builder
            //        .WithOrigins("http://localhost:4200")
            //        .WithOrigins("http://localhost:8761")
            //        .WithOrigins("http://localhost:59354")
            //        .WithOrigins("http://localhost:59354/barragemService")
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials();
            //        });

            //});

            services.AddSignalR();

            services.AddDiscoveryClient(Configuration);


            services.AddControllers();


            services.AddMassTransit(x =>
            {
                x.AddConsumer<BarragemConsumer>(); 
                x.AddConsumer<SensorConsumer>(); 

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri("rabbitmq://localhost"), host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ReceiveEndpoint(e =>
                    {
                        e.Consumer<BarragemConsumer>(context);
                        e.Consumer<SensorConsumer>(context);
                    });

                });
            });


            services.AddMassTransitHostedService();



            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins("http://localhost:4200")
                        .WithOrigins("http://localhost:8761");
                    });
            });


            //var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            //{
            //    cfg.Host(new Uri("rabbitmq://localhost"), host =>
            //    {
            //        host.Username("guest");
            //        host.Password("guest");
            //    });

            //    cfg.ReceiveEndpoint(e =>
            //    {
            //        e.Consumer<BarragemConsumer>();
            //    });
            //});

            //busControl.Start();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            //app.UseCors("CorsPolicy");


            app.UseHttpsRedirection();

            app.UseCors("AllowAll");


            app.UseDiscoveryClient();

            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChartHub>("/charts");
                endpoints.MapHub<SensorHub>("/sensor");
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Barragens");
            });


        }
    }

   
}
