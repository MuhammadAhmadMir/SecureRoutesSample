using SecureRoutesSample.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});

builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", config =>
    {
        config.LoginPath = "/Account/Login";
        config.AccessDeniedPath = "/Account/AccessDenied";
    });

builder.Services.AddSingleton<UserData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSession();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<SecureRoutesMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
