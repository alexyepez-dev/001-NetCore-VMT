using _001_VMT.Application.Extension;
using _001_VMT.Persistence.Extension;
using _001_VMT.Shared.ExceptionFilter;
using _001_VMT.Shared.Extension;
using _001_VMT.Shared.Helpers.Message;
using _001_VMT.Shared.Service.Cors;
using Scalar.AspNetCore;

var arguments = args;
var builder = WebApplication.CreateBuilder(arguments);
var config = builder.Configuration;
var exception = typeof(ExceptionManager);
var policy = SharedMessage.CorsPolicies;

builder.Services.AddOpenApi();
builder.Services
.AddPersistence(config)
.AddApplication()
.AddCorsService(config)
.AddShared(config);

builder.Services.AddControllers
(
    options => options
    .Filters
    .Add(exception)
);

var app = builder.Build();
var environment = app.Environment.IsDevelopment();

if (environment)
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapControllers();
app.UseCors(policy);
app.UseHttpsRedirection();
app.Run();