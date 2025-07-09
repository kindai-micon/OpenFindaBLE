
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenFindaBLE.Backend.Handlers;
using OpenFindaBLE.Backend.Models;
using OpenFindaBLE.Backend.Services;

namespace OpenFindaBLE.Backend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("findble-db"));
        });
        builder.Services.AddSingleton<IAuthorityScanService,AuthorityScanService>();
        builder.Services.AddScoped<IAuthorizationHandler, DynamicRoleHandler>();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                options => builder.Configuration.Bind("JwtSettings", options))
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                options => builder.Configuration.Bind("CookieSettings", options))
            .AddIdentityCookies();

        builder.Services.AddIdentityCore<ApplicationUser>(o =>
        {
            o.Stores.MaxLengthForKeys = 128;
            o.User.RequireUniqueEmail = false;
        })
            .AddDefaultTokenProviders()
            .AddRoles<ApplicationRole>()
            .AddUserManager<UserManager<ApplicationUser>>()
            .AddSignInManager<SignInManager<ApplicationUser>>()
            .AddRoleManager<RoleManager<ApplicationRole>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();
        builder.Services.AddAuthorization(options =>
        {
            AuthorityScanService authorityScanService = new AuthorityScanService();
            foreach (var auth in authorityScanService.Authority)
            {
                options.AddPolicy(auth, policy =>
                    policy.Requirements.Add(new DynamicRoleRequirement(auth)));
            }
        });

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        
        app.UseAuthorization();

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapIdentityApi<ApplicationUser>();
        app.MapControllers();
        
        using (var sp = app.Services.CreateScope())
        {
            var dbContext = sp.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
        }
        app.Run();
    }
}
