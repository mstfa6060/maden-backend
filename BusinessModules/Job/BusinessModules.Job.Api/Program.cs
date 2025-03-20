using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Arfware.ArfBlocks.Core.Extentions;
using Arfware.ArfBlocks.Core;
// using Common.Services.Environment;

var builder = WebApplication.CreateBuilder(args);

// var configurations = builder.Configuration.GetSection("ProjectConfigurations").Get<ProjectConfigurations>();
// var environmentService = new EnvironmentService(configurations.EnvironmentConfiguration);

string DefaultCorsPolicy = "DefaultCorsPolicy";
builder.Services.AddCors(options =>
{
    // Development Cors Policy
    options.AddPolicy(name: DefaultCorsPolicy,
        builder =>
        {
            builder.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        });
});

// ArfBlocks Dependencies
builder.Services.AddArfBlocks(options =>
{
    options.ApplicationProjectNamespace = "BaseModules.IAM.Application";
    options.ConfigurationSection = builder.Configuration.GetSection("ProjectConfigurations");
    options.LogLevel = LogLevels.Warning;
    // options.PreOperateHandler = typeof(BaseModules.IAM.Application.DefaultHandlers.Operators.Commands.PreOperate.Handler);
    // options.PostOperateHandler = typeof(BaseModules.IAM.Application.DefaultHandlers.Operators.Commands.PostOperate.Handler);
});

var app = builder.Build();

app.UseCors(DefaultCorsPolicy);

app.UseArfBlocksRequestHandlers(options =>
{
    // options.AuthorizationOptions.Audience = JwtService.Audience;
    // options.AuthorizationOptions.Secret = JwtService.Secret;
});

app.Run();
