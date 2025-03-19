using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.EntityFramework;
public partial class DBVinotripContext : DbContext
{
    public DBVinotripContext()
    {
    }

    public DBVinotripContext(DbContextOptions<DBVinotripContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activite> Activites { get; set; }

    public virtual DbSet<Adresse> Adresses { get; set; }

    public virtual DbSet<AutreSociete> Autresocietes { get; set; }

    public virtual DbSet<Avis> Avis { get; set; }

    public virtual DbSet<CarteBancaire> CarteBancaires { get; set; }

    public virtual DbSet<CategorieParticipant> Categorieparticipants { get; set; }

    public virtual DbSet<CategorieSejour> Categoriesejours { get; set; }

    public virtual DbSet<CategorieVignoble> Categorievignobles { get; set; }

    public virtual DbSet<Cave> Caves { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<CodePromo> Codepromos { get; set; }

    public virtual DbSet<Commande> Commandes { get; set; }

    public virtual DbSet<DescriptionCommande> Descriptioncommandes { get; set; }

    public virtual DbSet<DescriptionPanier> Descriptionpaniers { get; set; }

    public virtual DbSet<Duree> Durees { get; set; }

    public virtual DbSet<EstProposePar> EstProposePars { get; set; }

    public virtual DbSet<Etape> Etapes { get; set; }

    public virtual DbSet<Hebergement> Hebergements { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Localite> Localites { get; set; }

    public virtual DbSet<Panier> Paniers { get; set; }

    public virtual DbSet<Partenaire> Partenaires { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Repas> Repas { get; set; }

    public virtual DbSet<Reponse> Reponses { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RouteDesVins> RouteDesVins { get; set; }

    public virtual DbSet<Sejour> Sejours { get; set; }

    public virtual DbSet<Theme> Themes { get; set; }

    public virtual DbSet<TypeCuisine> Typecuisines { get; set; }

    public virtual DbSet<TypeDegustation> Typedegustations { get; set; }

    public virtual DbSet<Visite> Visites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=DBVinotrip; uid=postgres; password=postgres;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");

        // Activite
        modelBuilder.Entity<Activite>()
            .HasKey(e => e.IdActivite)
            .HasName("pk_activite");

        // Adresse
        modelBuilder.Entity<Adresse>()
            .HasKey(e => e.IdAdresse)
            .HasName("pk_adresse");

        modelBuilder.Entity<Adresse>()
            .Property(e => e.PaysAdresse)
            .HasDefaultValueSql("'France'::character varying");

        modelBuilder.Entity<Adresse>()
            .HasOne(d => d.Client)
            .WithMany(p => p.Adresses)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_adresse_associati_client");

        modelBuilder.Entity<Adresse>()
            .HasOne(d => d.Partenaire)
            .WithMany(p => p.AdressesPartenaires)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_adresse_localise_partenai");

        // AutreSociete
        modelBuilder.Entity<AutreSociete>()
            .HasKey(e => e.IdPartenaire)
            .HasName("pk_autresociete");

        modelBuilder.Entity<AutreSociete>()
            .Property(e => e.IdPartenaire)
            .ValueGeneratedNever();

        modelBuilder.Entity<AutreSociete>()
            .Property(e => e.Telpartenaire)
            .IsFixedLength();

        modelBuilder.Entity<AutreSociete>()
            .HasOne(d => d.Partenaire)
            .WithOne(p => p.AutreSocietePartenaire)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_autresoc_heritage__partenai");

        // Avis
        modelBuilder.Entity<Avis>()
            .HasKey(e => e.IdAvis)
            .HasName("pk_avis");

        modelBuilder.Entity<Avis>()
            .HasOne(d => d.Client)
            .WithMany(p => p.LesAvis)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_avis_associati_client");

        modelBuilder.Entity<Avis>()
            .HasOne(d => d.Sejour)
            .WithMany(p => p.AvisNavigation)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_avis_critique_sejour");

        // CarteBancaire
        modelBuilder.Entity<CarteBancaire>()
            .HasKey(e => e.IdCB)
            .HasName("pk_carte_bancaire");

        modelBuilder.Entity<CarteBancaire>()
            .Property(e => e.Actif)
            .HasDefaultValue(true);

        modelBuilder.Entity<CarteBancaire>()
            .Property(e => e.DateExpirationCreditCard)
            .IsFixedLength();

        modelBuilder.Entity<CarteBancaire>()
            .Property(e => e.NumeroCB)
            .IsFixedLength();

        modelBuilder.Entity<CarteBancaire>()
            .HasOne(d => d.Client)
            .WithMany(p => p.CartesBancaires)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_carte_ba_associati_client");

        // Client
        modelBuilder.Entity<Client>()
            .HasKey(e => e.IdClient)
            .HasName("pk_client");

        modelBuilder.Entity<Client>()
            .HasIndex(e => e.EmailClient)
            .IsUnique();

        modelBuilder.Entity<Client>()
            .Property(e => e.A2f)
            .HasDefaultValue(false);

        modelBuilder.Entity<Client>()
            .Property(e => e.offresPromotionnellesClient)
            .HasDefaultValue(false);

        modelBuilder.Entity<Client>()
            .Property(e => e.TelClient)
            .IsFixedLength();

        modelBuilder.Entity<Client>()
            .Property(e => e.TokenResetMDP)
            .HasDefaultValueSql("NULL::bpchar")
            .IsFixedLength();

        modelBuilder.Entity<Client>()
            .Property(e => e.DateCreationCompteClient)
            .HasDefaultValueSql("now()");

        modelBuilder.Entity<Client>()
            .HasOne(d => d.Role)
            .WithMany(p => p.Clients)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_client_associati_roles");

        // Favoris (relation Many-to-Many entre Client et Sejour)
        modelBuilder.Entity<Favo>()
            .HasKey(e => new { e.idclient, e.idsejour })
            .HasName("pk_favoris");

        modelBuilder.Entity<Favori>()
            .HasOne(f => f.Client)
            .WithMany(c => c.Favoris)
            .HasForeignKey(f => f.idclient)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_favoris_favoris_client");

        modelBuilder.Entity<Favoris>()
            .HasOne(f => f.Sejour)
            .WithMany(s => s.Favoris)
            .HasForeignKey(f => f.idsejour)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_favoris_favoris2_sejour");

        // Sejour
        modelBuilder.Entity<Sejour>()
            .HasKey(e => e.Idsejour)
            .HasName("pk_sejour");


        modelBuilder.Entity<Sejour>()
            .Property(e => e.Publie)
            .HasDefaultValue(false);


        modelBuilder.Entity<Sejour>()
            .HasOne(d => d.IdcategorieparticipantNavigation)
            .WithMany(p => p.Sejours)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_sejour_destine_a_categori");

        modelBuilder.Entity<Sejour>()
            .HasOne(d => d.IdcategoriesejourNavigation)
            .WithMany(p => p.Sejours)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_sejour_regroupe_categori");

        modelBuilder.Entity<Sejour>()
            .HasOne(d => d.IdcategorievignobleNavigation)
            .WithMany(p => p.Sejours)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_sejour_categoris_categori");

        modelBuilder.Entity<Sejour>()
            .HasOne(d => d.IddureeNavigation)
            .WithMany(p => p.Sejours)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_sejour_dure_duree");

        modelBuilder.Entity<Sejour>()
            .HasOne(d => d.IdlocaliteNavigation)
            .WithMany(p => p.Sejours)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_sejour_se_situe_localite");

        modelBuilder.Entity<Sejour>()
            .HasOne(d => d.IdthemeNavigation)
            .WithMany(p => p.Sejours)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_sejour_definit_theme");

        // Autres entités...
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}