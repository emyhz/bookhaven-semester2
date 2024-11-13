using LogicLayer.Managers;
using LogicLayer.Algorithm;
using Microsoft.AspNetCore.Authentication.Cookies;
using DataAccessLayer.Interfaces;
using DataAccessLayer;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddRazorPages();


// Configure cookie-based authentication with custom paths for login, access denied, and logout.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/Login");
    options.AccessDeniedPath = new PathString("/AccessDenied");
    options.LogoutPath = new PathString("/LogOut");

});

//authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "ADMIN")); 
});


// registering data access layer services
builder.Services.AddScoped<IUserDb, DBUser>();
builder.Services.AddScoped<IOrderDb, DBOrder>();
builder.Services.AddScoped<IOrderItemDb, DBOrderItem>();


// Add logic layer services to the container
builder.Services.AddScoped<UserManager>();
builder.Services.AddScoped<OrderManager>();
builder.Services.AddScoped<BookManager>();
builder.Services.AddScoped<OrderItemManager>();




//Add algorithm services to the container
builder.Services.AddScoped<RecommendationSystem>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
