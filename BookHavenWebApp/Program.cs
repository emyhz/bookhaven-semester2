using LogicLayer.Managers;
using LogicLayer.Algorithm;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddRazorPages();

//authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/AccessDenied";
    });

//authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Employee", policy => policy.RequireRole("Employee"));
    options.AddPolicy("Customer", policy => policy.RequireRole("Customer"));
});



// Add logic layer services to the container
builder.Services.AddScoped<UserManager>();
builder.Services.AddScoped<OrderManager>();
builder.Services.AddScoped<BookManager>();



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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
