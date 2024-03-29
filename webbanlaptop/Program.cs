﻿using AspNetCoreHero.ToastNotification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NToastNotify;
using webbanlaptop.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<webbanlaptopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("webbanlaptopContext") ?? throw new InvalidOperationException("Connection string 'webbanlaptopContext' not found.")));

// Add services to the container.
builder.Services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions()
{
    ProgressBar = true,
    Timeout = 5000
});

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.Cookie.Name = "WebBanLaptop";
    options.IdleTimeout = TimeSpan.FromDays(60);
});

//builder.Services.AddNotyf(config => { config.DurationInSeconds = 4; config.IsDismissable = true; config.Position = NotyfPosition.TopCenter; });


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

app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseNToastNotify();

app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
