using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PostsMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using System;
using PostsMicroservice.Consumers;
using MySql.EntityFrameworkCore.Extensions;

namespace PostsMicroservice
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

            services.AddMassTransit(x =>
            {
                x.AddConsumer<Consumer>();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri("amqp://guest:guest@rabbitmq:5672"));
                    cfg.ReceiveEndpoint("postQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<Consumer>(provider);
                    });
                }));
            });
            services.AddControllers();

           var connectionString = Configuration["mysqlconnection:connectionString"];

                services.AddDbContext<DBContext>(options =>
                {
                    options.UseMySQL(Configuration["mysqlconnection:connectionString"]);
                });

            services.AddControllers();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DBContext context)
        {
            if (context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                context.Database.Migrate();
            }

            DbInitializer.Initialize(context);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //DISABLE WHILE IN PRODUCTION!
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
