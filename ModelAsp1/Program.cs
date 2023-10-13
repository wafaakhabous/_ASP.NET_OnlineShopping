﻿using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModelAsp1.Data;
using System.Diagnostics.Metrics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ModelAsp1Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ModelAsp1Context") ?? throw new InvalidOperationException("Connection string 'ModelAsp1Context' not found.")));

builder.Services.AddDistributedMemoryCache(); // cart  *************************
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

app.UseSession(); //caaaaaartttttttt

app.MapRazorPages();

app.MapGet("/", (HttpContext context) =>
{
    context.Response.Redirect("/Products");
    return Task.CompletedTask;
});

app.Run();




