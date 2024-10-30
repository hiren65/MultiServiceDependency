
using MultiServiceDependency.Interfaces;
using MultiServiceDependency.Models;
using MultiServiceDependency.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddControllersWithViews();

//Adding the services to the container

    
    builder.Services.AddSingleton<FirstService>();
    builder.Services.AddSingleton<SecondService>();
builder.Services.AddSingleton<Func<string, IMultiService>>(serviceProvider => key =>
{
    switch (key)
    {
        case "Service1":
            return serviceProvider.GetService<FirstService>();
        case "Service2":
            return serviceProvider.GetService<SecondService>();
        default:
            throw new KeyNotFoundException(); // or maybe return null, up to you
    }
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
