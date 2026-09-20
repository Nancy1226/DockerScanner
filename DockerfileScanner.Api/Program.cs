using DockerfileScanner.Application.Services;
using DockerfileScanner.Domain.Parsing;
using DockerfileScanner.Domain.Rules;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });

builder.Services.AddScoped<DockerfileParser>();
builder.Services.AddScoped<RootUserRule>();
builder.Services.AddScoped<DockerfileScannerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();