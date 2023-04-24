using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Form_Project.Models;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; //HTTP ile gelirse HTTP , HTTPS ile gelirse HTTPS ile çalýþýr.
    opt.Cookie.Name = "FormCookie";
    opt.ExpireTimeSpan = TimeSpan.FromDays(1);
    opt.LoginPath = new PathString("/Home/SignIn"); //Giris yapmayan kisi SignIn sayfasina yonlendirilir

}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePagesWithReExecute("/Error/{0}");
app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    if (response.StatusCode == 401)
    {
        response.Redirect("/Error/401");
    }
    else if (response.StatusCode == 403)
    {
        response.Redirect("/Error/403");
    }
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "form",
    pattern: "form",
    defaults: new { controller = "Form", action = "Index" })
    .RequireAuthorization();

app.Run();
