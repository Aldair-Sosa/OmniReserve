using OmniReserve.Application;
using OmniReserve.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

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
