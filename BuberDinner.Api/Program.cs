using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application; 
using BuberDinner.Infrastructure ;
using BuberDinner.Api.MiddleWare;
using BuberDinner.Api.Filters;
using dotnet_test.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Ajout des services d'application et d'infrastructure
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
//builder.Services.AddInfrastructure();

// Ajout des services au conteneur.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// CECI AUSSI POUR LE FILTER ET GESTION ERREUR
//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingErrorMiddleware>());
// ON BOUGE CETTE PARTI DU CODE DANS LE DEPENDENCY INJECTION
//builder.Services.AddScoped<IAuthenticationService , AuthenticationService>(); 
// En savoir plus sur la configuration de Swagger/OpenAPI à l'adresse https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(
);
// builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme,
        securityScheme: new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Name = "Authorization",
            Description = "Enter the Bearer Auth : `Bearer Generated-JWT-Token`",
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Type = SecuritySchemeType.Http, // Utilisez SecuritySchemeType.Http pour le schéma Bearer
            Scheme = "Bearer"
        });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme // Correction du nom de la classe
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "oauth2",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            },
            Array.Empty<string>() // Utilisez Array.Empty<string>() pour une liste vide
        }
    });
});

var app = builder.Build();

app.UseExceptionHandler("/error");

// Configuration du gestionnaire d'exceptions

// Configuration du pipeline de requête HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
