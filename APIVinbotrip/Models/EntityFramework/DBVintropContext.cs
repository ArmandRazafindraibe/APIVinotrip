using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Elfie.Model.Structures;
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

        // Activite configuration
        modelBuilder.Entity<Activite>(entity =>
        {
            entity.HasKey(e => e.IdActivite).HasName("pk_activite");
        });

        // Adresse configuration
        modelBuilder.Entity<Adresse>(entity =>
        {
            entity.HasKey(e => e.IdAdresse).HasName("pk_adresse");
            entity.Property(e => e.PaysAdresse).HasDefaultValueSql("'France'::character varying");

            entity.HasOne(d => d.Client)
                .WithMany(p => p.Adresses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_adresse_associati_client");

            entity.HasOne(d => d.Partenaire)
                .WithMany(p => p.AdressesPartenaires)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_adresse_localise_partenai");
        });

        // AutreSociete configuration
        modelBuilder.Entity<AutreSociete>(entity =>
        {
            entity.HasKey(e => e.IdPartenaire).HasName("pk_autresociete");
            entity.Property(e => e.IdPartenaire).ValueGeneratedNever();
            entity.Property(e => e.Telpartenaire).IsFixedLength();

            entity.HasOne(d => d.Partenaire)
                .WithOne(p => p.AutreSocietePartenaire)
                .HasForeignKey<AutreSociete>(d => d.IdPartenaire)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_autresoc_heritage__partenai");
        });

        // Avis configuration
        modelBuilder.Entity<Avis>(entity =>
        {
            entity.HasKey(e => e.IdAvis).HasName("pk_avis");

            entity.HasOne(d => d.Client)
                .WithMany(p => p.LesAvis)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_avis_associati_client");

            entity.HasOne(d => d.Sejour)
                .WithMany(p => p.AvisNavigation)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_avis_critique_sejour");
        });

        // CarteBancaire configuration
        modelBuilder.Entity<CarteBancaire>(entity =>
        {
            entity.HasKey(e => e.IdCB).HasName("pk_carte_bancaire");
            entity.Property(e => e.Actif).HasDefaultValue(true);
            entity.Property(e => e.DateExpirationCreditCard).IsFixedLength();
            entity.Property(e => e.NumeroCB).IsFixedLength();

            entity.HasOne(d => d.Client)
                .WithMany(p => p.CartesBancaires)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_carte_ba_associati_client");
        });

        // CategorieParticipant configuration
        modelBuilder.Entity<CategorieParticipant>(entity =>
        {
            entity.HasKey(e => e.IdCategorieParticipant).HasName("pk_categorieparticipant");
        });

        // CategorieSejour configuration
        modelBuilder.Entity<CategorieSejour>(entity =>
        {
            entity.HasKey(e => e.IdCategorieSejour).HasName("pk_categoriesejour");
        });

        // CategorieVignoble configuration
        modelBuilder.Entity<CategorieVignoble>(entity =>
        {
            entity.HasKey(e => e.IdCategorieVignoble).HasName("pk_categorievignoble");
        });

        // Cave configuration
        modelBuilder.Entity<Cave>(entity =>
        {
            entity.HasKey(e => e.IdPartenaire).HasName("pk_cave");
            entity.Property(e => e.IdPartenaire).ValueGeneratedNever();
            entity.Property(e => e.TelPartenaire).IsFixedLength();

            entity.HasOne(d => d.Partenaire)
                .WithOne(p => p.Caves)
                .HasForeignKey<Cave>(d => d.IdPartenaire)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cave_heritage__partenai");

            entity.HasOne(d => d.TypeDegustation)
                .WithMany(p => p.Caves)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cave_fait_degu_typedegu");
        });

        // Client configuration
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("pk_client");
            entity.Property(e => e.A2f).HasDefaultValue(false);
            entity.Property(e => e.offresPromotionnellesClient).HasDefaultValue(false);
            entity.Property(e => e.TelClient).IsFixedLength();
            entity.Property(e => e.TokenResetMDP)
                .HasDefaultValueSql("NULL::bpchar")
                .IsFixedLength();

            entity.HasOne(d => d.Role)
                .WithMany(p => p.Clients)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_client_associati_roles");
        });

        // CodePromo configuration
        modelBuilder.Entity<CodePromo>(entity =>
        {
            entity.HasKey(e => e.IdCodePromo).HasName("pk_codepromo");
        });

        // Commande configuration
        modelBuilder.Entity<Commande>(entity =>
        {
            entity.HasKey(e => e.IdCommande).HasName("pk_commande");
            entity.Property(e => e.DateCommande).HasDefaultValueSql("'2025-01-01'::date");
            entity.Property(e => e.EtatCommande).HasDefaultValueSql("'En attente de validation'::character varying");

            entity.HasOne(d => d.AdresseFacturation)
                .WithMany(p => p.CommandesFacturation)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_commande_associati_adresse2");

            entity.HasOne(d => d.AdresseLivraison)
                .WithMany(p => p.CommandesLivraison)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_commande_associati_adresse");

            entity.HasOne(d => d.CarteBancaire)
                .WithMany(p => p.Commandes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_commande_associati_carte_ba");

            entity.HasOne(d => d.ClientAcheteur)
                .WithMany(p => p.Commandes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_commande_associati_client2");

            entity.HasOne(d => d.ClientBeneficiaire)
                .WithMany(p => p.CommandesOfferts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_commande_associati_client");

            entity.HasOne(d => d.CodeReductionNavigation)
                .WithMany(p => p.Commandes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_commande_diminue_codeprom");

            entity.HasOne(d => d.PanierCommande)
                .WithMany(p => p.Commandes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_commande_associe_panier");
        });

        // DescriptionCommande configuration
        modelBuilder.Entity<DescriptionCommande>(entity =>
        {
            entity.HasKey(e => e.IdDescriptionCommande).HasName("pk_descriptioncommande");
            entity.Property(e => e.ValidationClient).HasDefaultValue(false);

            entity.HasOne(d => d.DescriptionsCommandeCB)
                .WithMany(p => p.DescriptionsCommande)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_descript_associati_carte_ba");

            entity.HasOne(d => d.Commande)
                .WithMany(p => p.DescriptionsCommande)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_descript_associati_commande");

            entity.HasOne(d => d.Hebergements)
                .WithMany(p => p.DescriptionsCommande)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_descript_associati_hebergem");

            entity.HasOne(d => d.Sejours)
                .WithMany(p => p.DescriptioncommandesNavigation)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_descript_associati_sejour");
        });

        // DescriptionPanier configuration
        modelBuilder.Entity<DescriptionPanier>(entity =>
        {
            entity.HasKey(e => e.IdDescriptionPanier).HasName("pk_descriptionpanier");

            entity.HasOne(d => d.Hebergement)
                .WithMany(p => p.DescriptionsPanier)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_descript_associati_hebergem");

            entity.HasOne(d => d.Panier)
                .WithMany(p => p.DescriptionsPanier)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_descript_decrit_pa_panier");

            entity.HasOne(d => d.Sejour)
                .WithMany(p => p.Descriptionpaniers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_descript_decrit_se_sejour");
        });

        // Duree configuration
        modelBuilder.Entity<Duree>(entity =>
        {
            entity.HasKey(e => e.IdDuree).HasName("pk_duree");
        });

        // EstProposePar configuration
        modelBuilder.Entity<EstProposePar>(entity =>
        {
            entity.HasKey(e => new { e.Idpartenaire, e.Idactivite, e.Idadresse }).HasName("pk_est_propose_par");

            entity.HasOne(d => d.IdactiviteNavigation)
                .WithMany(p => p.EstProposePars)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_propose__propose_5_activite");

            entity.HasOne(d => d.IdadresseNavigation)
                .WithMany(p => p.EstProposePars)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_propose__propose_6_adresse");

            entity.HasOne(d => d.IdpartenaireNavigation)
                .WithMany(p => p.EstProposePars)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_propose__est_propose_par_autresoc");
        });

        // Etape configuration
        modelBuilder.Entity<Etape>(entity =>
        {
            entity.HasKey(e => e.IdEtape).HasName("pk_etape");

            entity.HasOne(d => d.Hebergement)
                .WithMany(p => p.Etapes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_etape_appartien_hebergem");

            entity.HasOne(d => d.Sejour)
                .WithMany(p => p.Etapes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_etape_possede_sejour");
        });

        // Hebergement configuration
        modelBuilder.Entity<Hebergement>(entity =>
        {
            entity.HasKey(e => e.IdHebergement).HasName("pk_hebergement");

            entity.HasOne(d => d.HebergementHotel)
                .WithMany(p => p.HotelHebergements)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_hebergem_propose_3_hotel");
        });

        // Hotel configuration
        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.IdPartenaire).HasName("pk_hotel");
            entity.Property(e => e.IdPartenaire).ValueGeneratedNever();
            entity.Property(e => e.TelPartenaire).IsFixedLength();

            entity.HasOne(d => d.Partenaire)
                .WithOne(p => p.HotelPartenaire)
                .HasForeignKey<Hotel>(d => d.IdPartenaire)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_hotel_heritage__partenai");
        });

        // Localite configuration
        modelBuilder.Entity<Localite>(entity =>
        {
            entity.HasKey(e => e.IdLocalite).HasName("pk_localite");

            entity.HasOne(d => d.CategoriesVignoble)
                .WithMany(p => p.Localites)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_localite_a_categori");
        });

        // Panier configuration
        modelBuilder.Entity<Panier>(entity =>
        {
            entity.HasKey(e => e.IdPanier).HasName("pk_panier");

            entity.HasOne(d => d.CodesPromos)
                .WithMany(p => p.Paniers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_panier_reduit_codeprom");
        });

        // Partenaire configuration
        modelBuilder.Entity<Partenaire>(entity =>
        {
            entity.HasKey(e => e.IdPartenaire).HasName("pk_partenaire");
            entity.Property(e => e.TelPartenaire).IsFixedLength();
        });

        // Photo configuration
        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.IdPhoto).HasName("pk_photos");

            entity.HasOne(d => d.Sejour)
                .WithMany(p => p.Photos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_photos_associati_sejour");
        });

        // Repas configuration
        modelBuilder.Entity<Repas>(entity =>
        {
            entity.HasKey(e => e.IdRepas).HasName("pk_repas");

            entity.HasOne(d => d.RestaurantRepas)
                .WithMany(p => p.RepasCollection)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_repas_propose_2_restaura");
        });

        // Reponse configuration
        modelBuilder.Entity<Reponse>(entity =>
        {
            entity.HasKey(e => e.IdReponse).HasName("pk_reponse");

            entity.HasOne(d => d.Avis)
                .WithMany(p => p.Reponses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_reponse_repond_avis");
        });

        // Restaurant configuration
        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.IdPartenaire).HasName("pk_restaurant");
            entity.Property(e => e.IdPartenaire).ValueGeneratedNever();
            entity.Property(e => e.TelPartenaire).IsFixedLength();

            entity.HasOne(d => d.Partenaire)
                .WithOne(p => p.Restaurants)
                .HasForeignKey<Restaurant>(d => d.IdPartenaire)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_restaura_heritage__partenai");

            entity.HasOne(d => d.TypeCuisine)
                .WithMany(p => p.Restaurants)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_restaura_cuisine_typecuis");
        });

        // Role configuration
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("pk_roles");
        });

        // RouteDesVins configuration
        modelBuilder.Entity<RouteDesVins>(entity =>
        {
            entity.HasKey(e => e.IdRoute).HasName("pk_route_des_vins");
        });

        // Sejour configuration
        modelBuilder.Entity<Sejour>(entity =>
        {
            entity.HasKey(e => e.Idsejour).HasName("pk_sejour");
            entity.Property(e => e.Publie).HasDefaultValue(false);

            entity.HasOne(d => d.IdcategorieparticipantNavigation)
                .WithMany(p => p.Sejours)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sejour_destine_a_categori");

            entity.HasOne(d => d.IdcategoriesejourNavigation)
                .WithMany(p => p.Sejours)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sejour_regroupe_categori");

            entity.HasOne(d => d.IdcategorievignobleNavigation)
                .WithMany(p => p.Sejours)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sejour_categoris_categori");

            entity.HasOne(d => d.IddureeNavigation)
                .WithMany(p => p.Sejours)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sejour_dure_duree");

            entity.HasOne(d => d.IdlocaliteNavigation)
                .WithMany(p => p.Sejours)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sejour_se_situe_localite");

            entity.HasOne(d => d.IdthemeNavigation)
                .WithMany(p => p.Sejours)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sejour_definit_theme");
        });

        // Theme configuration
        modelBuilder.Entity<Theme>(entity =>
        {
            entity.HasKey(e => e.IdTheme).HasName("pk_theme");
        });

        // TypeCuisine configuration
        modelBuilder.Entity<TypeCuisine>(entity =>
        {
            entity.HasKey(e => e.IdTypeCuisine).HasName("pk_typecuisine");
        });

        // TypeDegustation configuration
        modelBuilder.Entity<TypeDegustation>(entity =>
        {
            entity.HasKey(e => e.IdTypeDegustation).HasName("pk_typedegustation");
        });

        // Visite configuration
        modelBuilder.Entity<Visite>(entity =>
        {
            entity.HasKey(e => e.IdVisite).HasName("pk_visite");

            entity.HasOne(d => d.Cave)
                .WithMany(p => p.Visites)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_visite_propose_1_cave");
        });

        // Join table configurations

        // Possede (join table) configuration
        modelBuilder.Entity<Inclus>()
            .HasKey(e => new { e.idactivite, e.iddescriptioncommande })
            .HasName("pk_possede");

        modelBuilder.Entity<Inclus>()
            .ToTable("possede");

        modelBuilder.Entity<Inclus>()
            .HasOne(p => p.Activite)
            .WithMany()
            .HasForeignKey(p => p.idactivite)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_associat_associati_activite");

        modelBuilder.Entity<Inclus>()
            .HasOne(p => p.DescriptionCommande)
            .WithMany()
            .HasForeignKey(p => p.iddescriptioncommande)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_associat_associati_descript");

        // Comporte (join table) configuration
        modelBuilder.Entity<Comporte>()
            .HasKey(e => new { e.IdActivite, e.IdDescriptionPanier })
            .HasName("pk_comporte");

        modelBuilder.Entity<Comporte>()
            .ToTable("comporte");

        modelBuilder.Entity<Comporte>()
            .HasOne(c => c.Activite)
            .WithMany()
            .HasForeignKey(c => c.idactivite)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_associat_associati_activite");

        modelBuilder.Entity<Comporte>()
            .HasOne(c => c.DescriptionPanierComporte)
            .WithMany()
            .HasForeignKey(c => c.IdDescriptionPanier)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_associat_associati_descript");

        // Constitue (join table) configuration
        modelBuilder.Entity<Constitue>()
            .HasKey(c => new { c.IdActivite, c.idetape })
            .HasName("pk_constitue");

        modelBuilder.Entity<Constitue>()
            .ToTable("constitue");

        modelBuilder.Entity<Constitue>()
            .HasOne(c => c.Activite)
            .WithMany()
            .HasForeignKey(c => c.idactivite)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_appartie_appartien_activite");

        modelBuilder.Entity<Constitue>()
            .HasOne(c => c.Etape)
            .WithMany()
            .HasForeignKey(c => c.idetape)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_appartie_appartien_etape");

        // Favori (join table) configuration
        modelBuilder.Entity<Favoris>()
            .HasKey(f => new { f.idclient, f.idsejour })
            .HasName("pk_favoris");

        modelBuilder.Entity<Favoris>()
            .ToTable("favoris");

        modelBuilder.Entity<Favoris>()
            .HasOne(f => f.Client)
            .WithMany()
            .HasForeignKey(f => f.idclient)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_favoris_favoris_client");

        modelBuilder.Entity<Favoris>()
            .HasOne(f => f.Sejour)
            .WithMany()
            .HasForeignKey(f => f.idsejour)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_favoris_favoris2_sejour");

        // Mange1 (join table) configuration
        modelBuilder.Entity<Mange1>()
            .HasKey(m => new { m.idrepas, m.iddescriptioncommande })
            .HasName("pk_contient");

        modelBuilder.Entity<Mange1>()
            .ToTable("mange1");

        modelBuilder.Entity<Mange1>()
            .HasOne(m => m.Repas)
            .WithMany()
            .HasForeignKey(m => m.idrepas)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_associat_associati_repas");

        modelBuilder.Entity<Mange1>()
            .HasOne(m => m.DescriptionCommande)
            .WithMany()
            .HasForeignKey(m => m.iddescriptioncommande)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_associat_associati_descript");

        // Detient (join table) configuration
        modelBuilder.Entity<Detient>()
            .HasKey(d => new { d.IdRepas, d.DescriptionPanierDetient })
            .HasName("pk_detient");

        modelBuilder.Entity<Detient>()
            .ToTable("detient");

        modelBuilder.Entity<Detient>()
            .HasOne(d => d.RepasDetient)
            .WithMany()
            .HasForeignKey(d => d.IdRepas)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_associat_associati_repas");

        modelBuilder.Entity<Detient>()
            .HasOne(d => d.DescriptionPanierDetient)
            .WithMany()
            .HasForeignKey(d => d.IdDescriptionPanier)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_associat_associati_descript");

        // Inclus (join table) configuration
        modelBuilder.Entity<Inclus>()
            .HasKey(i => new { i.IdRepas, i.IdEtape })
            .HasName("pk_inclus");

        modelBuilder.Entity<Inclus>()
            .ToTable("inclus");

        modelBuilder.Entity<Inclus>()
            .HasOne(i => i.Repas)
            .WithMany()
            .HasForeignKey(i => i.IdRepas)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_appartie_appartien_repas");

        modelBuilder.Entity<Inclus>()
            .HasOne(i => i.Etape)
            .WithMany()
            .HasForeignKey(i => i.IdEtape)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_appartie_appartien_etape");

        // SeLocalise (join table) configuration
        modelBuilder.Entity<SeLocalise>()
            .HasKey(s => new { s.IdRoute, s.IdCategorieVignoble })
            .HasName("pk_se_localise");

        modelBuilder.Entity<SeLocalise>()
            .ToTable("se_localise");

        modelBuilder.Entity<SeLocalise>()
            .HasOne(s => s.Route)
            .WithMany()
            .HasForeignKey(s => s.IdRoute)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_se_local_se_locali_route_de");

        modelBuilder.Entity<SeLocalise>()
            .HasOne(s => s.CategorieVignoble)
            .WithMany()
            .HasForeignKey(s => s.IdCategorieVignoble)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_se_local_se_locali_categori");

        // Appartient (join table) configuration
        modelBuilder.Entity<Appartient>()
            .HasKey(a => new { a.IdVisite, a.IdEtape })
            .HasName("pk_appartient");

        modelBuilder.Entity<Appartient>()
            .ToTable("appartient");

        modelBuilder.Entity<Appartient>()
            .HasOne(a => a.Visite)
            .WithMany()
            .HasForeignKey(a => a.IdVisite)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_appartie_appartien_visite");

        modelBuilder.Entity<Appartient>()
            .HasOne(a => a.Etape)
            .WithMany()
            .HasForeignKey(a => a.IdEtape)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_appartie_appartien_etape");

        OnModelCreatingPartial(modelBuilder);
    }
partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}