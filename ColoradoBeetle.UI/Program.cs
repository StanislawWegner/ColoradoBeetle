using AspNetCore.ReCaptcha;
using ColoradoBeetle.Application;
using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Infrastructure;
using ColoradoBeetle.UI.Extensions;
using GymManager2.UI.Middlewares;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Information);
builder.Logging.AddNLogWeb();

builder.Services.AddCulture();

builder.Services.AddReCaptcha(builder.Configuration.GetSection("ReCaptcha"));

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.DefineViewLocation(builder.Configuration);

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {

    app.UseInfrastructure(
        scope.ServiceProvider.GetRequiredService<IApplicationDbContext>(),
        app.Services.GetService<IAppSettingsService>(),
        app.Services.GetService<IEmail>());
        
}

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
