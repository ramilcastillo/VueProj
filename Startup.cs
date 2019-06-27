using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace vue_sample_proj
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
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      var connectionString = Configuration.GetConnectionString("DefaultConnection");
      services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

      services.AddCors(options =>
      {
        options.AddPolicy("VueCorsPolicy", builder =>
        {
          builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins("http://localhost:8080");
        });
      });
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext dbContext)
        {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      dbContext.Database.EnsureCreated();

      app.UseMvc();
    }
    }
}
