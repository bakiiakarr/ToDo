using BlazorApp1.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Syncfusion.Blazor;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//sql Database conneciton
//var SqlConnectionConfiguration = new SqlConnectionConfiguration(Configuration.GetConnectionString("sqlDBcontext"));
//services.AddSingleton(SqlConnectionConfiguration);


builder.Services.AddScoped<ListDataAccesLayer>();
//var test = Configuration.GetConnectionString("DataSource=.;Database=BAKAR;Integrated Security=True");

//builder.Services.AddDbContext<ListDataAccesLayer>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

builder.Services.AddDbContext<ListDataAccesLayer>(option =>
              option.UseSqlServer("DataSource=BAKAR;Database=toDoList;Integrated Security=True"));
//builder.Services.AddDbContext<ListDataAccesLayer>(option =>
//              option.UseSqlServer(builder.Configuration.GetConnectionString("sqlDBcontext")));

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
