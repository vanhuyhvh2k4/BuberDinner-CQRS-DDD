using BuberDinner.API.Errors;
using BuberDinner.API.Filters;
using BuberDinner.API.Middleware;
using BuberDinner.Application;
using BuberDinner.Infrashstructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication()
                    .AddInfrashstructure(builder.Configuration);
    builder.Services.AddControllers();
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

    builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
}

var app = builder.Build();

{
    //app.UseMiddleware<ErrorHandlingMiddleware>();

    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}

