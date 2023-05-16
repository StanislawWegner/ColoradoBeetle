using ColoradoBeetle.Application;
using ColoradoBeetle.Infrastructure;
using ColoradoBeetle.UI.Extensions;
using GymManager2.UI.Middlewares;
using Microsoft.AspNetCore.Mvc.Razor;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Information);
builder.Logging.AddNLogWeb();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.DefineViewLocation(builder.Configuration);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseInfrstructure();

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

var logger = app.Services.GetService<ILogger<Program>>();

if (app.Environment.IsDevelopment()) {
    logger.LogInformation("DEVELOPMENT MODE!!!");
}
else {
    logger.LogInformation("PRODUCTION MODE!!!");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
