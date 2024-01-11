using BuberDinner.API;
using BuberDinner.Application;
using BuberDinner.Infrashstructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication()
                    .AddPresentation()
                    .AddInfrashstructure(builder.Configuration);
}

var app = builder.Build();

{
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}

