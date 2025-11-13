using Serilog;
using VMT.TechnicalTest.Api.Logging;
using VMT.TechnicalTest.Application.Extension;

var builder = WebApplication.CreateBuilder(args);

LoggingProvider.Serilog();

builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationProvider();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();