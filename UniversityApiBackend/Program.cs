//EL PROGRAM.CS NOS ESTABLECE COMO VAMOS A MONTAR NUESTRA APLICACION.


//  1. Usings to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;  //NOS PERMITE ACCEDER A NUESTRO CONTEXTO

var builder = WebApplication.CreateBuilder(args);  //PARA CONSTRUIR LAS CONFIGURACIONES QUE VA A UTILIZAR NUESTRA APLICACION

//2. Connections with SQL Server Express                //CONEXION CON LA BD
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//3. Add Context     /ESTABLECER UN CONTEXTO GRAL O VARIOS.
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));
//para conectarse a la BD  es similar con otras bds, en este caso hay que tener en cuenta que UseSqlServer necesita de EntityFrameworkCore, la extension
//que agregamos al ppio


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                       //SE ESTABLECE SWAGGER PARA DOCUEMNTAR LA APLICACION
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();                    //BUSCA LOS CONTROLADORES DEPENDIENDO DONDE ESTEN ALOIJADOS CON EL NOMBRE DE LA RUTA QUE LE DEMOS

app.Run();                                //EJECUTA NUESTRA APLICACION
