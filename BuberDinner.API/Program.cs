using BuberDinner.API.Common.Errors;
using BuberDinner.Application;
using BuberDinner.Infrashstructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication()
                    .AddInfrashstructure(builder.Configuration);
    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
}

var app = builder.Build();

{
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}

