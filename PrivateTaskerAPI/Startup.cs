using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrivateTaskerAPI.Entity;
using PrivateTaskerAPI.Middleware;
using PrivateTaskerAPI.Repositories;
using PrivateTaskerAPI.Services;

namespace PrivateTaskerAPI
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("https://127.0.0.1:5500");
                                  });
            });

            services.AddControllers();
            services.AddScoped<NoteSeeder>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddTransient<IReminderRepository, ReminderRepository>();
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<IReminderService, ReminderService>();
            services.AddDbContext<TaskerDb>(options => options.UseSqlServer(Configuration.GetConnectionString("TaskerDb")));
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, NoteSeeder seeder)
        {
            seeder.Seed();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PrivateTaskerAPI");
            });

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
