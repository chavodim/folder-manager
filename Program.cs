using Microsoft.EntityFrameworkCore;
using FolderManagerApp.Data;
using FolderManagerApp.Repositories;
using FolderManagerApp.Repositories.Impl;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IFolderRepository, FolderRepository>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<FolderManagerDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("FolderManagerDbContextConnection"));
    options.EnableSensitiveDataLogging();
});

builder.Services.Configure<FormOptions>(x =>
{
    x.MultipartBodyLengthLimit = 1_000_000; // 1 MB
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

