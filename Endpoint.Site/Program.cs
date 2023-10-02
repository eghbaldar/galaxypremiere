using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.Roles.FacadePattern;
using galaxypremiere.Application.Services.Users.FacadePattern;
using galaxypremiere.Infrastructure.MappingProfiles.Users;
using galaxypremiere.Persistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//// Add DataContext Dependencies & Other Dependecies such as "Users Services"
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
// Facades
builder.Services.AddScoped<IRolesFacade, RoleFacade>();
builder.Services.AddScoped<IUserFacade, UserFacade>();

// SqlServer
var ConStr = builder.Configuration.GetConnectionString("LocalServer");
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(x => x.UseSqlServer(ConStr));

//Mapper
builder.Services.AddAutoMapper(typeof(UsersMappingProfile));

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

app.UseAuthorization();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
