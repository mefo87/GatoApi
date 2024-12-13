using FluentValidation;
using FluentValidation.AspNetCore;
using GatoApi.Configuration;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "GatoApi.xml"));
});

services.AddDependencyInjection();
services.AddDatabase(builder.Configuration);

services.AddControllers();
services.AddMvc();
services.AddFluentValidationAutoValidation();
services.AddValidatorsFromAssemblyContaining<Program>();
    
var app = builder.Build();
app.UseRouting();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();