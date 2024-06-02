using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddMvc(config =>                      
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});


builder.Services.AddDbContext<BaseDbContext>();                  

builder.Services.AddSingleton<IIncidentDal, EfIncidentDal>();
builder.Services.AddSingleton<IIncidentService, IncidentManager>();

builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.Password.RequireUppercase = false;                  
    x.Password.RequireNonAlphanumeric = false;            
})
    .AddEntityFrameworkStores<BaseDbContext>();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)    
    .AddCookie(options =>
    {
        options.Cookie.Name = "deneme";
        options.LoginPath = "/Login/index";                                            
        options.AccessDeniedPath = "/Login/Index";                                      
    });




builder.Services.ConfigureApplicationCookie(options =>                           
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(100);                            
    options.AccessDeniedPath = new PathString("/Login/AccessDenied");            
    options.LoginPath = "/Login/Index/";
    options.SlidingExpiration = true;

});


builder.Services.AddSession();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

app.UseHttpsRedirection();


app.UseRouting();

app.UseSession();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");
});

app.Run();
