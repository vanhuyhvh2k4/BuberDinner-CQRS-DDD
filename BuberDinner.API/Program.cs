using BuberDinner.Application;
using BuberDinner.Infrashstructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication()
                    .AddInfrashstructure(builder.Configuration);
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}

