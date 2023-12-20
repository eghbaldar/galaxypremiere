using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.Countries.FacadePattern;
using galaxypremiere.Application.Services.Languages.FacadePattern;
using galaxypremiere.Application.Services.Roles.FacadePattern;
using galaxypremiere.Application.Services.UserActionsLog.FacadePattern;
using galaxypremiere.Application.Services.UserLoginLog.FacadePattern;
using galaxypremiere.Application.Services.UserPosition.FacadePattern;
using galaxypremiere.Application.Services.Users.FacadePattern;
using galaxypremiere.Application.Services.UsersInformation.FacadePattern;
using galaxypremiere.Common.Constants;
using galaxypremiere.Domain.Entities.Users;
using galaxypremiere.Infrastructure.MappingProfiles.Users;
using galaxypremiere.Infrastructure.MappingProfiles.UsersInformation;
using galaxypremiere.Infrastructure.MappingProfiles.UsersLoginLog;
using galaxypremiere.Persistence.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//// Add DataContext Dependencies & Other Dependecies such as "Users Services"
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
// Facades
builder.Services.AddScoped<IRolesFacade, RoleFacade>();
builder.Services.AddScoped<IUserFacade, UserFacade>();
builder.Services.AddScoped<IUserActionLogFacade, UserActionsLogFacade>();
builder.Services.AddScoped<IUserLoginLogFacade, UserLoginLogFacade>();
builder.Services.AddScoped<IUserInformationFacade, UserInformationFacade>();
builder.Services.AddScoped<ICountiresFacade, CountriesFacade>();
builder.Services.AddScoped<ILanguagesFacade, LanguagesFacade>();
builder.Services.AddScoped<IUserPositionFacade, UsersPositionFacade>();

// SqlServer
var ConStr = builder.Configuration.GetConnectionString("LocalServer");
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(x => x.UseSqlServer(ConStr));

//Mapper
builder.Services.AddAutoMapper(typeof(UsersMappingProfile));
builder.Services.AddAutoMapper(typeof(UserLoginLogMappingProfile));
builder.Services.AddAutoMapper(typeof(UsersInformationProfile));

// ASN // Add Authentication & Auhortization
builder.Services.AddAuthentication(option =>
{
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option => // Admins' Scheme
{
    option.LoginPath = new PathString("/admin/auth/login");
    option.ExpireTimeSpan = TimeSpan.FromMinutes(1);
    option.AccessDeniedPath = new PathString("/");
}).AddCookie("user", option => // Users' Scheme
{
    option.LoginPath = new PathString("/");
    option.ExpireTimeSpan = TimeSpan.FromMinutes(1);
    option.AccessDeniedPath = new PathString("/");
});
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy(RoleConstants.King, policy => policy.RequireRole(RoleConstants.King));
    option.AddPolicy(RoleConstants.SuperAdmin, policy => policy.RequireRole(RoleConstants.SuperAdmin));
    option.AddPolicy(RoleConstants.Admin, policy => policy.RequireRole(RoleConstants.Admin));
    option.AddPolicy(RoleConstants.Client, policy => policy.RequireRole(RoleConstants.Client));
    option.AddPolicy(RoleConstants.User, policy => policy.RequireRole(RoleConstants.User));
});

builder.Services.AddAuthentication()
    .AddGoogle(option =>
    {
        option.ClientId = "337937604991-tdk4jupupcoepdggcjvhadral147udto.apps.googleusercontent.com";
        option.ClientSecret = "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";
    });
builder.Services.AddAuthentication()
    .AddInstagram(option =>
    {
        option.ClientId = "1006444983921222";
        option.ClientSecret = "38c543ac536b375f157cf6a1499cf08b";
        //option.CallbackPath = "/signin-instagram";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
