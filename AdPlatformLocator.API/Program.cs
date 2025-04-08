using AdPlatformLocator.App.Interfaces;
using AdPlatformLocator.App.Services;
using AdPlatformLocator.App.Validators;
using AdPlatformLocator.Data;
using AdPlatformLocator.Data.Storages;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblyContaining<LoadRequestDtoValidator>();

builder.Services.AddSingleton<IAdPlatformStorage, InMemoryAdPlatformStorage>();
builder.Services.AddSingleton<IAdPlatformFileLoader, AdPlatformFileLoader>();
builder.Services.AddSingleton<IAdPlatformService, AdPlatformService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
