using Microsoft.EntityFrameworkCore;
using FolderManagerApp.Data;
using FolderManagerApp.Repositories;
using FolderManagerApp.Repositories.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IFolderRepository, FolderRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddDbContext<FolderManagerDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("FolderManagerDbContextConnection"));
    options.EnableSensitiveDataLogging();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();

