using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TAST_Store.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = "Server=LAPTOP-5K30TST1\\SQLEXPRESS;Database=TAST_STORE;Trusted_Connection=True;TrustServerCertificate=true;";
builder.Configuration.GetConnectionString("TAST_STOREConnection");
builder.Services.AddDbContext<TAST_STOREContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
AddCookie(options =>
{
    options.Cookie.Name = "PetStoreCookie";
    options.LoginPath = "/User/Login";
});
builder.Services.AddSession();
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

app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "trang-chu",
    pattern: "trang-chu",
    defaults: new { controller = "Home", action = "Index" });

    endpoints.MapControllerRoute(
    name: "san-pham",
    pattern: "san-pham",
    defaults: new { controller = "Product", action = "Index" });

    endpoints.MapControllerRoute(
    name: "dang-ky",
    pattern: "dang-ky",
    defaults: new { controller = "User", action = "Register" });

    endpoints.MapControllerRoute(
    name: "dang-nhap",
    pattern: "dang-nhap",
    defaults: new { controller = "User", action = "Login" });

    endpoints.MapControllerRoute(
    name: "edit-info",
    pattern: "edit-info",
    defaults: new { controller = "User", action = "EditInfo" });

    endpoints.MapControllerRoute(
    name: "quan-tri",
    pattern: "quan-tri",
    defaults: new { controller = "Admin", action = "Index" });


    endpoints.MapControllerRoute(
     name: "them-gio-hang",
     pattern: "them-gio-hang",
     defaults: new { controller = "Cart", action = "AddItem" });


    endpoints.MapControllerRoute(
    name: "thong-tin",
    pattern: "thong-tin",
    defaults: new { controller = "User", action = "Info" });

    endpoints.MapControllerRoute(
     name: "dang-xuat",
     pattern: "dang-xuat",
     defaults: new { controller = "User", action = "Logout" });

    endpoints.MapControllerRoute(
     name: "gio-hang",
     pattern: "gio-hang",
     defaults: new { controller = "Cart", action = "Index" });

    endpoints.MapControllerRoute(
    name: "thanh-toan",
    pattern: "thanh-toan",
    defaults: new { controller = "Cart", action = "Payment" });

    endpoints.MapControllerRoute(
     name: "hoan-thanh",
     pattern: "hoan-thanh",
     defaults: new { controller = "Cart", action = "Success" });

    endpoints.MapControllerRoute(
    name: "bai-viet",
    pattern: "bai-viet",
    defaults: new { controller = "Blog", action = "Index" });

    endpoints.MapControllerRoute(
    name: "chi-tiet-bai-viet",
    pattern: "bai-viet/{slug}-{id}",
    defaults: new { controller = "Blog", action = "BlogDetail" });

    endpoints.MapControllerRoute(
    name: "lien-he",
    pattern: "lien-he",
    defaults: new { controller = "Contact", action = "Index" });

    endpoints.MapControllerRoute(
    name: "xoa-san-pham",
    pattern: "xoa-san-pham",
    defaults: new { controller = "Cart", action = "Delete" });

    endpoints.MapControllerRoute(
    name: "quan-ly-bai-viet",
    pattern: "quan-ly-bai-viet",
    defaults: new { controller = "BlogManager", action = "Index" });

    endpoints.MapControllerRoute(
    name: "quan-ly-tai-khoan",
    pattern: "quan-ly-tai-khoan",
    defaults: new { controller = "Account", action = "Index" });

    endpoints.MapControllerRoute(
     name: "quan-ly-loai-san-pham",
     pattern: "quan-ly-loai-san-pham",
     defaults: new { controller = "CatManager", action = "Index" });

    endpoints.MapControllerRoute(
     name: "quan-ly-san-pham",
     pattern: "quan-ly-san-pham",
     defaults: new { controller = "ProductManager", action = "Index" });

    endpoints.MapControllerRoute(
       name: "the-loai-san-pham",
       pattern: "{slug}-{id}",
       defaults: new { controller = "Product", action = "CateProd" });

    endpoints.MapControllerRoute(
    name: "chi-tiet-san-pham",
    pattern: "san-pham/{slug}-{id}",
    defaults: new { controller = "Product", action = "ProdDetail" });

    endpoints.MapControllerRoute(
    name: "chuong-trinh",
    pattern: "chuong-trinh/{slug}",
    defaults: new { controller = "Product", action = "Index" });

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
