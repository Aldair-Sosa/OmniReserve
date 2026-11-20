using OmniReserve.Application;
using OmniReserve.Infrastructure;
using OmniReserve.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("OmniReserveDb");


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Registro de servicio de generacion Swagger
builder.Services.AddSwaggerGen();



//Llamada a los metodos de extwension para inyectar las dependencias de otras capas
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

//Registro del middleware Global
app.UseMiddleware<OmniReserve.Api.Middlewares.GlobalExceptionHandlingMiddleware>();


if (app.Environment.IsDevelopment())
    {
        //Pepiline de middleware para Swagger agregado correctamente

        app.UseSwagger();
        app.UseSwaggerUI();
    }




app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
