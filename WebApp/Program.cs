var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();
WebApp1.Codes.MyApp.Env = app.Environment;

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Compare}/{action=Index}/{id?}");

app.Run();
