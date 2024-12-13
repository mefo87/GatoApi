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

services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var modelStateEntryList = context.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .ToList();

        var errors = modelStateEntryList
            .SelectMany(x => x.Value.Errors.Select(x => x.ErrorMessage))
            .ToList();

        var customResponse = new ErrorResponse(false,
            StatusCodes.Status400BadRequest,
            "Houveram erros de validação",
            errors);

        return new BadRequestObjectResult(customResponse);
    };
});
    
var app = builder.Build();
app.UseRouting();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

public record ErrorResponse(bool Success, int StatusCode, string Message, List<string> Errors);