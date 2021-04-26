using LibraryManagementBackend.Data;
using LibraryManagementBackend.Repositoties.Books;
using LibraryManagementBackend.Repositoties.Categories;
using LibraryManagementBackend.Repositoties.Requests;
using LibraryManagementBackend.Repositoties.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LibraryManagementBackend
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
      services.AddCors(options =>
        {
          options.AddDefaultPolicy(
                builder =>
                {
                  builder.WithOrigins("https://localhost:5001",
                                      "http://localhost:3000")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .AllowCredentials();
                });
        });

      services.AddDbContext<LibraryContext>(
        opts => opts.UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.GetConnectionString("sqlConnection")));

      services.AddControllers()
        .AddNewtonsoftJson(
          opts => opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );

      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<IBookRepository, BookRepository>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IRequestRepository, RequestRepository>();

      services.AddDistributedMemoryCache();

      services.AddSession(
        options =>
        {
          options.Cookie.HttpOnly = true;
          options.Cookie.IsEssential = true;
        }
      );

      services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
      .AddCookie(
        options =>
        {
          options.LoginPath = "/loginFail";
          options.AccessDeniedPath = "/accessDenied";
        });

      services.AddAuthentication(
        options =>
        {
          options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }
      );

      services.AddAuthorization(
        options =>
        {
          options.DefaultPolicy = new AuthorizationPolicyBuilder("Cookies").RequireAuthenticatedUser().Build();
        }
      );

      services.AddAuthorization(options =>
        {

          options.AddPolicy("Admin",
              authBuilder =>
              {
                authBuilder.RequireRole("Admin");
              });
          options.AddPolicy("Member",
          authBuilder =>
          {
            authBuilder.RequireRole("Member");
          });

        });

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryManagement", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryManagement v1"));
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseCors();

      app.UseAuthentication();
      app.UseAuthorization();
      app.UseSession();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
