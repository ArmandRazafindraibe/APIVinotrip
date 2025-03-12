//using System;
//using System.Collections.Generic;
//using APIVinbotrip.Models.Entity_Framework;
//using Microsoft.EntityFrameworkCore;

//namespace APIVinotrip.Models.Entity_Framework;
//public partial class DbtestContext : DbContext
//{
//    public DbtestContext()
//    {
//    }

//    public DbtestContext(DbContextOptions<DbtestContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Activite> Activites { get; set; }

//    public virtual DbSet<Adresse> Adresses { get; set; }

//    public virtual DbSet<AutreSociete> Autresocietes { get; set; }

//    public virtual DbSet<Avis> Avis { get; set; }

//    public virtual DbSet<CarteBancaire> CarteBancaires { get; set; }

//    public virtual DbSet<CategorieParticipant> Categorieparticipants { get; set; }

//    public virtual DbSet<CategorieSejour> Categoriesejours { get; set; }

//    public virtual DbSet<CategorieVignoble> Categorievignobles { get; set; }

//    public virtual DbSet<Cave> Caves { get; set; }


//    public virtual DbSet<Client> Clients { get; set; }

//    public virtual DbSet<CodePromo> Codepromos { get; set; }

//    public virtual DbSet<Commande> Commandes { get; set; }

//    public virtual DbSet<DescriptionCommande> Descriptioncommandes { get; set; }

//    public virtual DbSet<DescriptionPanier> Descriptionpaniers { get; set; }

//    public virtual DbSet<Duree> Durees { get; set; }

//    public virtual DbSet<EstProposePar> EstProposePars { get; set; }

//    public virtual DbSet<Etape> Etapes { get; set; }

//    public virtual DbSet<Hebergement> Hebergements { get; set; }

//    public virtual DbSet<Hotel> Hotels { get; set; }

//    public virtual DbSet<Localite> Localites { get; set; }

//    public virtual DbSet<Panier> Paniers { get; set; }

//    public virtual DbSet<Partenaire> Partenaires { get; set; }

//    public virtual DbSet<Photo> Photos { get; set; }

//    public virtual DbSet<Repas> Repas { get; set; }

//    public virtual DbSet<Reponse> Reponses { get; set; }

//    public virtual DbSet<Restaurant> Restaurants { get; set; }

//    public virtual DbSet<Role> Roles { get; set; }

//    public virtual DbSet<RouteDesVins> RouteDesVins { get; set; }

//    public virtual DbSet<Sejour> Sejours { get; set; }

//    public virtual DbSet<Theme> Themes { get; set; }

//    public virtual DbSet<TypeCuisine> Typecuisines { get; set; }

//    public virtual DbSet<TypeDegustation> Typedegustations { get; set; }


//    public virtual DbSet<Visite> Visites { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=DBTest; uid=postgres; password=postgres;");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Activite>(entity =>
//        {
//            entity.HasKey(e => e.IdActivite).HasName("pk_activite");

//            entity.HasMany(d => d.Iddescriptioncommandes).WithMany(p => p.Idactivites)
//                .UsingEntity<Dictionary<string, object>>(
//                    "Possede",
//                    r => r.HasOne<Descriptioncommande>().WithMany()
//                        .HasForeignKey("Iddescriptioncommande")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_associat_associati_descript"),
//                    l => l.HasOne<Activite>().WithMany()
//                        .HasForeignKey("Idactivite")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_associat_associati_activite"),
//                    j =>
//                    {
//                        j.HasKey("Idactivite", "Iddescriptioncommande").HasName("pk_possede");
//                        j.ToTable("possede");
//                    });

//            entity.HasMany(d => d.Iddescriptionpaniers).WithMany(p => p.Idactivites)
//                .UsingEntity<Dictionary<string, object>>(
//                    "Comporte",
//                    r => r.HasOne<Descriptionpanier>().WithMany()
//                        .HasForeignKey("Iddescriptionpanier")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_associat_associati_descript"),
//                    l => l.HasOne<Activite>().WithMany()
//                        .HasForeignKey("Idactivite")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_associat_associati_activite"),
//                    j =>
//                    {
//                        j.HasKey("Idactivite", "Iddescriptionpanier").HasName("pk_comporte");
//                        j.ToTable("comporte");
//                    });

//            entity.HasMany(d => d.Idetapes).WithMany(p => p.Idactivites)
//                .UsingEntity<Dictionary<string, object>>(
//                    "Constitue",
//                    r => r.HasOne<Etape>().WithMany()
//                        .HasForeignKey("Idetape")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_appartie_appartien_etape"),
//                    l => l.HasOne<Activite>().WithMany()
//                        .HasForeignKey("Idactivite")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_appartie_appartien_activite"),
//                    j =>
//                    {
//                        j.HasKey("Idactivite", "Idetape").HasName("pk_constitue");
//                        j.ToTable("constitue");
//                    });
//        });

//        modelBuilder.Entity<Adresse>(entity =>
//        {
//            entity.HasKey(e => e.Idadresse).HasName("pk_adresse");

//            entity.Property(e => e.Paysadresse).HasDefaultValueSql("'France'::character varying");

//            entity.HasOne(d => d.IdclientNavigation).WithMany(p => p.Adresses)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_adresse_associati_client");

//            entity.HasOne(d => d.IdpartenaireNavigation).WithMany(p => p.Adresses)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_adresse_localise_partenai");
//        });

//        modelBuilder.Entity<Autresociete>(entity =>
//        {
//            entity.HasKey(e => e.Idpartenaire).HasName("pk_autresociete");

//            entity.Property(e => e.Idpartenaire).ValueGeneratedNever();
//            entity.Property(e => e.Telpartenaire).IsFixedLength();

//            entity.HasOne(d => d.IdpartenaireNavigation).WithOne(p => p.Autresociete)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_autresoc_heritage__partenai");
//        });

//        modelBuilder.Entity<Avi>(entity =>
//        {
//            entity.HasKey(e => e.Idavis).HasName("pk_avis");

//            entity.HasOne(d => d.IdclientNavigation).WithMany(p => p.Avis)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_avis_associati_client");

//            entity.HasOne(d => d.IdsejourNavigation).WithMany(p => p.Avis)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_avis_critique_sejour");
//        });

//        modelBuilder.Entity<CarteBancaire>(entity =>
//        {
//            entity.HasKey(e => e.Idcb).HasName("pk_carte_bancaire");

//            entity.Property(e => e.Actif).HasDefaultValue(true);
//            entity.Property(e => e.Dateexpirationcbclient).IsFixedLength();
//            entity.Property(e => e.Numerocbclient).IsFixedLength();

//            entity.HasOne(d => d.IdclientNavigation).WithMany(p => p.CarteBancaires)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_carte_ba_associati_client");
//        });

//        modelBuilder.Entity<Categorieparticipant>(entity =>
//        {
//            entity.HasKey(e => e.Idcategorieparticipant).HasName("pk_categorieparticipant");
//        });

//        modelBuilder.Entity<Categoriesejour>(entity =>
//        {
//            entity.HasKey(e => e.Idcategoriesejour).HasName("pk_categoriesejour");
//        });

//        modelBuilder.Entity<Categorievignoble>(entity =>
//        {
//            entity.HasKey(e => e.Idcategorievignoble).HasName("pk_categorievignoble");
//        });

//        modelBuilder.Entity<Cave>(entity =>
//        {
//            entity.HasKey(e => e.Idpartenaire).HasName("pk_cave");

//            entity.Property(e => e.Idpartenaire).ValueGeneratedNever();
//            entity.Property(e => e.Telpartenaire).IsFixedLength();

//            entity.HasOne(d => d.IdpartenaireNavigation).WithOne(p => p.Cave)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_cave_heritage__partenai");

//            entity.HasOne(d => d.IdtypedegustationNavigation).WithMany(p => p.Caves)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_cave_fait_degu_typedegu");
//        });

//        modelBuilder.Entity<Chatbot>(entity =>
//        {
//            entity.HasKey(e => e.Idchat).HasName("pk_chatbot");
//        });

//        modelBuilder.Entity<Client>(entity =>
//        {
//            entity.HasKey(e => e.Idclient).HasName("pk_client");

//            entity.Property(e => e.A2f).HasDefaultValue(false);
//            entity.Property(e => e.Telephoneclient).IsFixedLength();
//            entity.Property(e => e.Tokenresetmdp)
//                .HasDefaultValueSql("NULL::bpchar")
//                .IsFixedLength();

//            entity.HasOne(d => d.IdroleNavigation).WithMany(p => p.Clients)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_client_associati_roles");

//            entity.HasMany(d => d.Idsejours).WithMany(p => p.Idclients)
//                .UsingEntity<Dictionary<string, object>>(
//                    "Favori",
//                    r => r.HasOne<Sejour>().WithMany()
//                        .HasForeignKey("Idsejour")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_favoris_favoris2_sejour"),
//                    l => l.HasOne<Client>().WithMany()
//                        .HasForeignKey("Idclient")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_favoris_favoris_client"),
//                    j =>
//                    {
//                        j.HasKey("Idclient", "Idsejour").HasName("pk_favoris");
//                        j.ToTable("favoris");

//                    });
//        });

//        modelBuilder.Entity<CodePromo>(entity =>
//        {
//            entity.HasKey(e => e.Idcodepromo).HasName("pk_codepromo");
//        });

//        modelBuilder.Entity<Commande>(entity =>
//        {
//            entity.HasKey(e => e.Idcommande).HasName("pk_commande");

//            entity.Property(e => e.Datecommande).HasDefaultValueSql("'2025-01-01'::date");
//            entity.Property(e => e.Etatcommande).HasDefaultValueSql("'En attente de validation'::character varying");

//            entity.HasOne(d => d.IdadressefacturationNavigation).WithMany(p => p.CommandeIdadressefacturationNavigations)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_commande_associati_adresse2");

//            entity.HasOne(d => d.IdadresselivraisonNavigation).WithMany(p => p.CommandeIdadresselivraisonNavigations)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_commande_associati_adresse");

//            entity.HasOne(d => d.IdcbNavigation).WithMany(p => p.Commandes)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_commande_associati_carte_ba");

//            entity.HasOne(d => d.IdclientacheteurNavigation).WithMany(p => p.CommandeIdclientacheteurNavigations)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_commande_associati_client2");

//            entity.HasOne(d => d.IdclientbeneficiaireNavigation).WithMany(p => p.CommandeIdclientbeneficiaireNavigations)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_commande_associati_client");

//            entity.HasOne(d => d.IdcodepromoNavigation).WithMany(p => p.Commandes)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_commande_diminue_codeprom");

//            entity.HasOne(d => d.IdpanierNavigation).WithMany(p => p.Commandes)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_commande_associe_panier");
//        });

//        modelBuilder.Entity<DescriptionCommande>(entity =>
//        {
//            entity.HasKey(e => e.Iddescriptioncommande).HasName("pk_descriptioncommande");

//            entity.Property(e => e.Validationclient).HasDefaultValue(false);

//            entity.HasOne(d => d.IdcbNavigation).WithMany(p => p.Descriptioncommandes)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_descript_associati_carte_ba");

//            entity.HasOne(d => d.IdcommandeNavigation).WithMany(p => p.Descriptioncommandes)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_descript_associati_commande");

//            entity.HasOne(d => d.IdhebergementNavigation).WithMany(p => p.Descriptioncommandes)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_descript_associati_hebergem");

//            entity.HasOne(d => d.IdsejourNavigation).WithMany(p => p.Descriptioncommandes)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_descript_associati_sejour");
//        });

//        modelBuilder.Entity<DescriptionPanier>(entity =>
//        {
//            entity.HasKey(e => e.Iddescriptionpanier).HasName("pk_descriptionpanier");

//            entity.HasOne(d => d.IdhebergementNavigation).WithMany(p => p.Descriptionpaniers)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_descript_associati_hebergem");

//            entity.HasOne(d => d.IdpanierNavigation).WithMany(p => p.Descriptionpaniers)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_descript_decrit_pa_panier");

//            entity.HasOne(d => d.IdsejourNavigation).WithMany(p => p.Descriptionpaniers)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_descript_decrit_se_sejour");
//        });

//        modelBuilder.Entity<Duree>(entity =>
//        {
//            entity.HasKey(e => e.Idduree).HasName("pk_duree");
//        });

//        modelBuilder.Entity<EstProposePar>(entity =>
//        {
//            entity.HasKey(e => new { e.Idpartenaire, e.Idactivite, e.Idadresse }).HasName("pk_est_propose_par");

//            entity.HasOne(d => d.IdactiviteNavigation).WithMany(p => p.EstProposePars)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_propose__propose_5_activite");

//            entity.HasOne(d => d.IdadresseNavigation).WithMany(p => p.EstProposePars)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_propose__propose_6_adresse");

//            entity.HasOne(d => d.IdpartenaireNavigation).WithMany(p => p.EstProposePars)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_propose__est_propose_par_autresoc");
//        });

//        modelBuilder.Entity<Etape>(entity =>
//        {
//            entity.HasKey(e => e.Idetape).HasName("pk_etape");

//            entity.HasOne(d => d.IdhebergementNavigation).WithMany(p => p.Etapes)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_etape_appartien_hebergem");

//            entity.HasOne(d => d.IdsejourNavigation).WithMany(p => p.Etapes)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_etape_possede_sejour");
//        });

//        modelBuilder.Entity<Hebergement>(entity =>
//        {
//            entity.HasKey(e => e.Idhebergement).HasName("pk_hebergement");

//            entity.HasOne(d => d.IdpartenaireNavigation).WithMany(p => p.Hebergements)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_hebergem_propose_3_hotel");
//        });

//        modelBuilder.Entity<Hotel>(entity =>
//        {
//            entity.HasKey(e => e.Idpartenaire).HasName("pk_hotel");

//            entity.Property(e => e.Idpartenaire).ValueGeneratedNever();
//            entity.Property(e => e.Telpartenaire).IsFixedLength();

//            entity.HasOne(d => d.IdpartenaireNavigation).WithOne(p => p.Hotel)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_hotel_heritage__partenai");
//        });

//        modelBuilder.Entity<Localite>(entity =>
//        {
//            entity.HasKey(e => e.Idlocalite).HasName("pk_localite");

//            entity.HasOne(d => d.IdcategorievignobleNavigation).WithMany(p => p.Localites)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_localite_a_categori");
//        });

//        modelBuilder.Entity<Panier>(entity =>
//        {
//            entity.HasKey(e => e.Idpanier).HasName("pk_panier");

//            entity.HasOne(d => d.IdcodepromoNavigation).WithMany(p => p.Paniers)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_panier_reduit_codeprom");
//        });

//        modelBuilder.Entity<Partenaire>(entity =>
//        {
//            entity.HasKey(e => e.IdPartenaire).HasName("pk_partenaire");

//            entity.Property(e => e.TelPartenaire).IsFixedLength();
//        });

//        modelBuilder.Entity<Photo>(entity =>
//        {
//            entity.HasKey(e => e.IdPhoto).HasName("pk_photos");

//            entity.HasOne(d => d.IdsejourNavigation).WithMany(p => p.Photos)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_photos_associati_sejour");
//        });

//        modelBuilder.Entity<Repas>(entity =>
//        {
//            entity.HasKey(e => e.Idrepas).HasName("pk_repas");

//            entity.HasOne(d => d.IdpartenaireNavigation).WithMany(p => p.Repas)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_repas_propose_2_restaura");

//            entity.HasMany(d => d.Iddescriptioncommandes).WithMany(p => p.Idrepas)
//                .UsingEntity<Dictionary<string, object>>(
//                    "Mange1",
//                    r => r.HasOne<Descriptioncommande>().WithMany()
//                        .HasForeignKey("Iddescriptioncommande")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_associat_associati_descript"),
//                    l => l.HasOne<Repa>().WithMany()
//                        .HasForeignKey("Idrepas")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_associat_associati_repas"),
//                    j =>
//                    {
//                        j.HasKey("Idrepas", "Iddescriptioncommande").HasName("pk_contient");
//                        j.ToTable("mange1");
//                    });

//            entity.HasMany(d => d.Iddescriptionpaniers).WithMany(p => p.Idrepas)
//                .UsingEntity<Dictionary<string, object>>(
//                    "Detient",
//                    r => r.HasOne<Descriptionpanier>().WithMany()
//                        .HasForeignKey("Iddescriptionpanier")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_associat_associati_descript"),
//                    l => l.HasOne<Repa>().WithMany()
//                        .HasForeignKey("Idrepas")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_associat_associati_repas"),
//                    j =>
//                    {
//                        j.HasKey("Idrepas", "Iddescriptionpanier").HasName("pk_detient");
//                        j.ToTable("detient");
//                    });

//            entity.HasMany(d => d.Idetapes).WithMany(p => p.Idrepas)
//                .UsingEntity<Dictionary<string, object>>(
//                    "Inclu",
//                    r => r.HasOne<Etape>().WithMany()
//                        .HasForeignKey("Idetape")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_appartie_appartien_etape"),
//                    l => l.HasOne<Repa>().WithMany()
//                        .HasForeignKey("Idrepas")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_appartie_appartien_repas"),
//                    j =>
//                    {
//                        j.HasKey("Idrepas", "Idetape").HasName("pk_inclus");
//                        j.ToTable("inclus");
//                    });
//        });

//        modelBuilder.Entity<Reponse>(entity =>
//        {
//            entity.HasKey(e => e.Idreponse).HasName("pk_reponse");

//            entity.HasOne(d => d.IdavisNavigation).WithMany(p => p.Reponses)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_reponse_repond_avis");
//        });

//        modelBuilder.Entity<Restaurant>(entity =>
//        {
//            entity.HasKey(e => e.Idpartenaire).HasName("pk_restaurant");

//            entity.Property(e => e.Idpartenaire).ValueGeneratedNever();
//            entity.Property(e => e.Telpartenaire).IsFixedLength();

//            entity.HasOne(d => d.IdpartenaireNavigation).WithOne(p => p.Restaurant)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_restaura_heritage__partenai");

//            entity.HasOne(d => d.IdTypeCuisine).WithMany(p => p.Restaurants)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_restaura_cuisine_typecuis");
//        });

//        modelBuilder.Entity<Role>(entity =>
//        {
//            entity.HasKey(e => e.IdRole).HasName("pk_roles");
//        });

//        modelBuilder.Entity<RouteDesVin>(entity =>
//        {
//            entity.HasKey(e => e.Idroute).HasName("pk_route_des_vins");

//            entity.HasMany(d => d.Idcategorievignobles).WithMany(p => p.Idroutes)
//                .UsingEntity<Dictionary<string, object>>(
//                    "SeLocalise",
//                    r => r.HasOne<Categorievignoble>().WithMany()
//                        .HasForeignKey("Idcategorievignoble")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_se_local_se_locali_categori"),
//                    l => l.HasOne<RouteDesVin>().WithMany()
//                        .HasForeignKey("Idroute")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_se_local_se_locali_route_de"),
//                    j =>
//                    {
//                        j.HasKey("Idroute", "Idcategorievignoble").HasName("pk_se_localise");
//                        j.ToTable("se_localise");
//                    });
//        });

//        modelBuilder.Entity<Sejour>(entity =>
//        {
//            entity.HasKey(e => e.Idsejour).HasName("pk_sejour");

//            entity.Property(e => e.Publie).HasDefaultValue(false);

//            entity.HasOne(d => d.IdcategorieparticipantNavigation).WithMany(p => p.Sejours)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_sejour_destine_a_categori");

//            entity.HasOne(d => d.IdcategoriesejourNavigation).WithMany(p => p.Sejours)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_sejour_regroupe_categori");

//            entity.HasOne(d => d.IdcategorievignobleNavigation).WithMany(p => p.Sejours)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_sejour_categoris_categori");

//            entity.HasOne(d => d.IddureeNavigation).WithMany(p => p.Sejours)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_sejour_dure_duree");

//            entity.HasOne(d => d.IdlocaliteNavigation).WithMany(p => p.Sejours)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_sejour_se_situe_localite");

//            entity.HasOne(d => d.IdthemeNavigation).WithMany(p => p.Sejours)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_sejour_definit_theme");
//        });

//        modelBuilder.Entity<Theme>(entity =>
//        {
//            entity.HasKey(e => e.Idtheme).HasName("pk_theme");
//        });

//        modelBuilder.Entity<Typecuisine>(entity =>
//        {
//            entity.HasKey(e => e.Idtypecuisine).HasName("pk_typecuisine");
//        });

//        modelBuilder.Entity<Typedegustation>(entity =>
//        {
//            entity.HasKey(e => e.Idtypedegustation).HasName("pk_typedegustation");
//        });

       

//        modelBuilder.Entity<Visite>(entity =>
//        {
//            entity.HasKey(e => e.Idvisite).HasName("pk_visite");

//            entity.HasOne(d => d.IdpartenaireNavigation).WithMany(p => p.Visites)
//                .OnDelete(DeleteBehavior.Restrict)
//                .HasConstraintName("fk_visite_propose_1_cave");

//            entity.HasMany(d => d.Idetapes).WithMany(p => p.Idvisites)
//                .UsingEntity<Dictionary<string, object>>(
//                    "Appartient",
//                    r => r.HasOne<Etape>().WithMany()
//                        .HasForeignKey("Idetape")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_appartie_appartien_etape"),
//                    l => l.HasOne<Visite>().WithMany()
//                        .HasForeignKey("Idvisite")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("fk_appartie_appartien_visite"),
//                    j =>
//                    {
//                        j.HasKey("Idvisite", "Idetape").HasName("pk_appartient");
//                        j.ToTable("appartient");
//                    });
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
