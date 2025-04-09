using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using APIVinotrip.Models.DataManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;
using System.Text.Json.Serialization;




var builder = WebApplication.CreateBuilder(args);

//Ajout dependances controllers
builder.Services.AddScoped<IDataRepository<Client>, ClientManager>();
builder.Services.AddScoped<IDataRepository<Commande>, CommandeManager>();
builder.Services.AddScoped<ISejourRepository<Sejour>, SejourManager>();
builder.Services.AddScoped<IDataRepository<Adresse>, AdresseManager>();
builder.Services.AddScoped<IDataRepository<Activite>, ActiviteManager>();
builder.Services.AddScoped<IDataRepository<RouteDesVins>, RouteDesVinsManager>();
builder.Services.AddScoped<IDataRepository<CategorieVignoble>, CategorieVignobleManager>();
builder.Services.AddScoped<IDataRepository<CategorieParticipant>, CategorieParticipantManager>();
builder.Services.AddScoped<IDataRepository<Theme>, ThemeManager>();
builder.Services.AddScoped<IDataRepository<Duree>, DureeManager>();
builder.Services.AddScoped<IDataRepository<CategorieSejour>, CategorieSejourManager>();
builder.Services.AddScoped<IDataRepository<Localite>, LocaliteManager>();
builder.Services.AddScoped<IPanierRepository<Panier>, PanierManager>();
builder.Services.AddScoped<IDataRepository<Favoris>, FavorisManager>();
builder.Services.AddScoped<IDataRepository<Hebergement>, HebergementManager>();
builder.Services.AddScoped<IDataRepository<Etape>, EtapeManager>();
builder.Services.AddScoped<IDataRepository<Visite>, VisiteManager>();
builder.Services.AddScoped<IDataRepository<Avis>, AvisManager>();
builder.Services.AddScoped<IDataRepository<Partenaire>, PartenaireManager>();
builder.Services.AddScoped<IRepasRepository<Repas>, RepasManager>();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });


// Add services to the container.
builder.Services.AddRazorPages();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<DBVinotripContext>(options =>
    options.UseNpgsql("Server=localhost;port=5432;Database=DBVinotrip; uid=postgres; password=root;"));
}
else
{
    builder.Services.AddDbContext<DBVinotripContext>(options =>
      options.UseNpgsql(builder.Configuration.GetConnectionString("DBVinotripContextRemote")));
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthorization(config =>
{
    config.AddPolicy(Policies.Dirigeant, Policies.DirigeantPolicy());
    config.AddPolicy(Policies.Client, Policies.ClientPolicy());
    config.AddPolicy(Policies.ServiceVente, Policies.ServiceVentePolicy());
    config.AddPolicy(Policies.Dpo, Policies.DPOPolicy());

});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    };
});

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseSwagger();
app.UseSwaggerUI();


app.UseCors(policy =>
    policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseStaticFiles();

// Authentication et Authorization doivent venir après CORS
app.UseAuthentication();
app.UseAuthorization();


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
