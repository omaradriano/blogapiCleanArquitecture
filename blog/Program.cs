
using Infrastructure;
using Application;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    //Dependency injection for infrastructure 
    builder.Services.AddInfrastructure();
    //Dependency injection for application
    builder.Services.AddApplication();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}