using Microsoft.EntityFrameworkCore;
using ProductInflation.Shared.Data;
using ProductInflation.Shared.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductInflationContext>((options) =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ProductInflationDB"]).UseLazyLoadingProxies();
});
builder.Services.AddTransient<DAL<Product>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();

});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
