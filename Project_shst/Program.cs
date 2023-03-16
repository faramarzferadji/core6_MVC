using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_shst.Areas.Identity.Data;
using Project_shst.Repository.IRepository;
using Project_shst.Repository;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString
    ("ApplicationDbContextConnection") ?? throw new InvalidOperationException
    ("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IUnitofWork, UnitofWork>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Accout/Login";
    options.LogoutPath = $"/Identity/Accout/Logout";
    options.AccessDeniedPath = $"/Identity/Accout/AccessDenied";


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
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=IndexShop}/{id?}");

app.Run();
