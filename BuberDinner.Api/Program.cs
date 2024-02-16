using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application; 
using BuberDinner.Infrastructure ;
using BuberDinner.Api.MiddleWare;
using BuberDinner.Api.Filters;
using dotnet_test.Mapping;

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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.UseAuthorization();
app.MapControllers();
app.Run();
