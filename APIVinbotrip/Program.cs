using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using APIVinotrip.Models.DataManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);

//Ajout dependances controllers
builder.Services.AddScoped<IDataRepository<Client>, ClientManager>();
builder.Services.AddScoped<IDataRepository<Avis>, AvisManager>();
builder.Services.AddScoped<IDataRepository<Commande>, CommandeManager>();
builder.Services.AddScoped<IDataRepository<Sejour>, SejourManager>();
builder.Services.AddScoped<IDataRepository<Adresse>, AdresseManager>();
builder.Services.AddScoped<IDataRepository<Activite>, ActiviteManager>();
builder.Services.AddScoped<IDataRepository<RouteDesVins>, RouteDesVinsManager>();
builder.Services.AddScoped<IDataRepository<CategorieVignoble>, CategorieVignobleManager>();
builder.Services.AddScoped<IDataRepository<Panier>, PanierManager>();
builder.Services.AddScoped<IDataRepository<Favoris>, FavorisManager>();



// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<DBVinotripContext>(options =>
  options.UseNpgsql(builder.Configuration.GetConnectionString("DBVinotripContextRemote")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

app.UseCors(policy =>
    policy.WithOrigins("https://localhost : 7173;http://localhost : 5208")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    );
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
