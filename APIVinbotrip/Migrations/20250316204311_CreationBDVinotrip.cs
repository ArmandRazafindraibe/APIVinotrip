using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APIVinotrip.Migrations
{
    /// <inheritdoc />
    public partial class CreationBDVinotrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACTIVITE",
                columns: table => new
                {
                    idActivite = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelleActivite = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    prixActivite = table.Column<decimal>(type: "numeric(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_activite", x => x.idActivite);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIEEPARTICIPANT",
                columns: table => new
                {
                    idCategorieParticipant = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelleCategorieParticipant = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categorieparticipant", x => x.idCategorieParticipant);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIESEJOUR",
                columns: table => new
                {
                    idCategorieSejour = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelleCategoriesSejour = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categoriesejour", x => x.idCategorieSejour);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIEVIGNOBLE",
                columns: table => new
                {
                    idCategorieVignoble = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelleCategorieVignoble = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categorievignoble", x => x.idCategorieVignoble);
                });

            migrationBuilder.CreateTable(
                name: "CODEPROMO",
                columns: table => new
                {
                    idCodePromo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelleCodePromo = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    reduction = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_codepromo", x => x.idCodePromo);
                });

            migrationBuilder.CreateTable(
                name: "DUREE",
                columns: table => new
                {
                    idDuree = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelleDuree = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_duree", x => x.idDuree);
                });

            migrationBuilder.CreateTable(
                name: "PARTENAIRE",
                columns: table => new
                {
                    idPartenaire = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomPartenaire = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    mailPartenaire = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    telPartenaire = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_partenaire", x => x.idPartenaire);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    idRole = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelleRole = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.idRole);
                });

            migrationBuilder.CreateTable(
                name: "ROUTE_DES_VINS",
                columns: table => new
                {
                    idRoute = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libRoute = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    descriptionRoute = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    photoRoute = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_route_des_vins", x => x.idRoute);
                });

            migrationBuilder.CreateTable(
                name: "THEME",
                columns: table => new
                {
                    idTheme = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelleTheme = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_theme", x => x.idTheme);
                });

            migrationBuilder.CreateTable(
                name: "TYPECUISINE",
                columns: table => new
                {
                    idTypeCuisine = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelleTypeCuisine = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typecuisine", x => x.idTypeCuisine);
                });

            migrationBuilder.CreateTable(
                name: "TYPEDEGUSTATION",
                columns: table => new
                {
                    idTypeDegustation = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelleTypeDegustation = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typedegustation", x => x.idTypeDegustation);
                });

            migrationBuilder.CreateTable(
                name: "LOCALITE",
                columns: table => new
                {
                    idLocalite = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelleLocalite = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    idCategorieVignoble = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_localite", x => x.idLocalite);
                    table.ForeignKey(
                        name: "fk_localite_a_categori",
                        column: x => x.idCategorieVignoble,
                        principalTable: "CATEGORIEVIGNOBLE",
                        principalColumn: "idCategorieVignoble",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PANIER",
                columns: table => new
                {
                    idPanier = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idCodePromo = table.Column<int>(type: "integer", nullable: true),
                    dateAjoutPanier = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_panier", x => x.idPanier);
                    table.ForeignKey(
                        name: "fk_panier_reduit_codeprom",
                        column: x => x.idCodePromo,
                        principalTable: "CODEPROMO",
                        principalColumn: "idCodePromo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AUTRESOCIETE",
                columns: table => new
                {
                    idPartenaire = table.Column<int>(type: "integer", nullable: false),
                    nomPartenaire = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    mailPartenaire = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    telpartenaire = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_autresociete", x => x.idPartenaire);
                    table.ForeignKey(
                        name: "fk_autresoc_heritage__partenai",
                        column: x => x.idPartenaire,
                        principalTable: "PARTENAIRE",
                        principalColumn: "idPartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HOTEL",
                columns: table => new
                {
                    idPartenaire = table.Column<int>(type: "integer", nullable: false),
                    nomPartenaire = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    mailPartenaire = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    telPartenaire = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    nombreChambresHotel = table.Column<int>(type: "integer", nullable: true),
                    categorieHotel = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hotel", x => x.idPartenaire);
                    table.ForeignKey(
                        name: "fk_hotel_heritage__partenai",
                        column: x => x.idPartenaire,
                        principalTable: "PARTENAIRE",
                        principalColumn: "idPartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT",
                columns: table => new
                {
                    idClient = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomClient = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    prenomClient = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    emailClient = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    mdpClient = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    dateNaissanceClient = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    dateCreationCompteClient = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    telClient = table.Column<string>(type: "character(12)", fixedLength: true, maxLength: 12, nullable: true),
                    dateDerniereActiviteClient = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    a2f = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    idRole = table.Column<int>(type: "integer", nullable: true),
                    bloquingClient = table.Column<bool>(type: "boolean", nullable: true),
                    tokenResetMDP = table.Column<string>(type: "character(50)", fixedLength: true, maxLength: 50, nullable: true, defaultValueSql: "NULL::bpchar"),
                    dateCreationToken = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client", x => x.idClient);
                    table.ForeignKey(
                        name: "fk_client_associati_roles",
                        column: x => x.idRole,
                        principalTable: "ROLES",
                        principalColumn: "idRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "se_localise",
                columns: table => new
                {
                    Idroute = table.Column<int>(type: "integer", nullable: false),
                    Idcategorievignoble = table.Column<int>(type: "integer", nullable: false),
                    IdCategorieVignoble = table.Column<int>(type: "integer", nullable: false),
                    IdRoute = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_se_localise", x => new { x.Idroute, x.Idcategorievignoble });
                    table.ForeignKey(
                        name: "fk_se_local_se_locali_categori",
                        column: x => x.Idcategorievignoble,
                        principalTable: "CATEGORIEVIGNOBLE",
                        principalColumn: "idCategorieVignoble",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_se_local_se_locali_route_de",
                        column: x => x.Idroute,
                        principalTable: "ROUTE_DES_VINS",
                        principalColumn: "idRoute",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESTAURANT",
                columns: table => new
                {
                    idPartenaire = table.Column<int>(type: "integer", nullable: false),
                    idTypeCuisine = table.Column<int>(type: "integer", nullable: true),
                    nomPartenaire = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    mailPartenaire = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    telPartenaire = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    nombreEtoilesRestaurant = table.Column<int>(type: "integer", nullable: true),
                    specialiteRestaurant = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_restaurant", x => x.idPartenaire);
                    table.ForeignKey(
                        name: "fk_restaura_cuisine_typecuis",
                        column: x => x.idTypeCuisine,
                        principalTable: "TYPECUISINE",
                        principalColumn: "idTypeCuisine",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_restaura_heritage__partenai",
                        column: x => x.idPartenaire,
                        principalTable: "PARTENAIRE",
                        principalColumn: "idPartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CAVE",
                columns: table => new
                {
                    idPartenaire = table.Column<int>(type: "integer", nullable: false),
                    idTypeDegustation = table.Column<int>(type: "integer", nullable: true),
                    nomPartenaire = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    mailPartenaire = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    telPartenaire = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cave", x => x.idPartenaire);
                    table.ForeignKey(
                        name: "fk_cave_fait_degu_typedegu",
                        column: x => x.idTypeDegustation,
                        principalTable: "TYPEDEGUSTATION",
                        principalColumn: "idTypeDegustation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cave_heritage__partenai",
                        column: x => x.idPartenaire,
                        principalTable: "PARTENAIRE",
                        principalColumn: "idPartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sejour",
                columns: table => new
                {
                    idsejour = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idduree = table.Column<int>(type: "integer", nullable: false),
                    idcategorievignoble = table.Column<int>(type: "integer", nullable: false),
                    idcategoriesejour = table.Column<int>(type: "integer", nullable: false),
                    idlocalite = table.Column<int>(type: "integer", nullable: true),
                    idtheme = table.Column<int>(type: "integer", nullable: false),
                    idcategorieparticipant = table.Column<int>(type: "integer", nullable: false),
                    titresejour = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    photosejour = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    descriptionsejour = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    prixsejour = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    publie = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    nouveauprixsejour = table.Column<decimal>(type: "numeric(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sejour", x => x.idsejour);
                    table.ForeignKey(
                        name: "fk_sejour_categoris_categori",
                        column: x => x.idcategorievignoble,
                        principalTable: "CATEGORIEVIGNOBLE",
                        principalColumn: "idCategorieVignoble",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_definit_theme",
                        column: x => x.idtheme,
                        principalTable: "THEME",
                        principalColumn: "idTheme",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_destine_a_categori",
                        column: x => x.idcategorieparticipant,
                        principalTable: "CATEGORIEEPARTICIPANT",
                        principalColumn: "idCategorieParticipant",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_dure_duree",
                        column: x => x.idduree,
                        principalTable: "DUREE",
                        principalColumn: "idDuree",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_regroupe_categori",
                        column: x => x.idcategoriesejour,
                        principalTable: "CATEGORIESEJOUR",
                        principalColumn: "idCategorieSejour",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_se_situe_localite",
                        column: x => x.idlocalite,
                        principalTable: "LOCALITE",
                        principalColumn: "idLocalite",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HEBERGEMENT",
                columns: table => new
                {
                    idHebergement = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idPartenaire = table.Column<int>(type: "integer", nullable: false),
                    descriptionHebergement = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    photoHebergement = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    lienHebergement = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    prixHebergement = table.Column<decimal>(type: "numeric(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hebergement", x => x.idHebergement);
                    table.ForeignKey(
                        name: "fk_hebergem_propose_3_hotel",
                        column: x => x.idPartenaire,
                        principalTable: "HOTEL",
                        principalColumn: "idPartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ADRESSE",
                columns: table => new
                {
                    idAdresse = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nAdresse = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    idClient = table.Column<int>(type: "integer", nullable: true),
                    idPartenaire = table.Column<int>(type: "integer", nullable: true),
                    nomAdresseDestinationFacture = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    nomAdresseDestinataire = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    rueAdresse = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    villeAdresse = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    paysAdresse = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, defaultValueSql: "'France'::character varying"),
                    cpAdresse = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    nomAdresse = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adresse", x => x.idAdresse);
                    table.ForeignKey(
                        name: "fk_adresse_associati_client",
                        column: x => x.idClient,
                        principalTable: "CLIENT",
                        principalColumn: "idClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_adresse_localise_partenai",
                        column: x => x.idPartenaire,
                        principalTable: "PARTENAIRE",
                        principalColumn: "idPartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CARTE_BANCAIRE",
                columns: table => new
                {
                    idCB = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idClient = table.Column<int>(type: "integer", nullable: true),
                    numeroCB = table.Column<string>(type: "character(50)", fixedLength: true, maxLength: 50, nullable: true),
                    numeroCVCCarte = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    dateExpirationCreditCard = table.Column<DateTime>(type: "timestamp with time zone", fixedLength: true, nullable: true),
                    actif = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_carte_bancaire", x => x.idCB);
                    table.ForeignKey(
                        name: "fk_carte_ba_associati_client",
                        column: x => x.idClient,
                        principalTable: "CLIENT",
                        principalColumn: "idClient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REPAS",
                columns: table => new
                {
                    idRepas = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idPartenaire = table.Column<int>(type: "integer", nullable: true),
                    descriptionRepas = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    photoRepas = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    prixRepas = table.Column<decimal>(type: "numeric(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_repas", x => x.idRepas);
                    table.ForeignKey(
                        name: "fk_repas_propose_2_restaura",
                        column: x => x.idPartenaire,
                        principalTable: "RESTAURANT",
                        principalColumn: "idPartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VISITE",
                columns: table => new
                {
                    idVisite = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idPartenaire = table.Column<int>(type: "integer", nullable: true),
                    descriptionVisite = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    photoVisite = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    lienVisite = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_visite", x => x.idVisite);
                    table.ForeignKey(
                        name: "fk_visite_propose_1_cave",
                        column: x => x.idPartenaire,
                        principalTable: "CAVE",
                        principalColumn: "idPartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AVIS",
                columns: table => new
                {
                    idAvis = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idSejour = table.Column<int>(type: "integer", nullable: true),
                    idClient = table.Column<int>(type: "integer", nullable: true),
                    dateAvis = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    titreAvis = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    descriptionAvis = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    noteAvis = table.Column<int>(type: "integer", nullable: true),
                    photoAvis = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_avis", x => x.idAvis);
                    table.ForeignKey(
                        name: "fk_avis_associati_client",
                        column: x => x.idClient,
                        principalTable: "CLIENT",
                        principalColumn: "idClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_avis_critique_sejour",
                        column: x => x.idSejour,
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "favoris",
                columns: table => new
                {
                    Idclient = table.Column<int>(type: "integer", nullable: false),
                    Idsejour = table.Column<int>(type: "integer", nullable: false),
                    IdClient = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_favoris", x => new { x.Idclient, x.Idsejour });
                    table.ForeignKey(
                        name: "fk_favoris_favoris2_sejour",
                        column: x => x.Idsejour,
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_favoris_favoris_client",
                        column: x => x.Idclient,
                        principalTable: "CLIENT",
                        principalColumn: "idClient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHOTO",
                columns: table => new
                {
                    idPhoto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idSejour = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_photos", x => x.idPhoto);
                    table.ForeignKey(
                        name: "fk_photos_associati_sejour",
                        column: x => x.idSejour,
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DESCRIPTIONPANIER",
                columns: table => new
                {
                    idDescriptionPanier = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idSejour = table.Column<int>(type: "integer", nullable: true),
                    idPanier = table.Column<int>(type: "integer", nullable: true),
                    idHebergement = table.Column<int>(type: "integer", nullable: true),
                    quantite = table.Column<int>(type: "integer", nullable: true),
                    dateDebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    dateFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    nbAdultes = table.Column<int>(type: "integer", nullable: true),
                    nbEnfants = table.Column<int>(type: "integer", nullable: true),
                    nbChambresSimple = table.Column<int>(type: "integer", nullable: true),
                    nbChambresDouble = table.Column<int>(type: "integer", nullable: true),
                    nbChambresTriple = table.Column<int>(type: "integer", nullable: true),
                    offrir = table.Column<bool>(type: "boolean", nullable: true),
                    eCoffret = table.Column<bool>(type: "boolean", nullable: true),
                    disponibiliteHebergement = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_descriptionpanier", x => x.idDescriptionPanier);
                    table.ForeignKey(
                        name: "fk_descript_associati_hebergem",
                        column: x => x.idHebergement,
                        principalTable: "HEBERGEMENT",
                        principalColumn: "idHebergement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_decrit_pa_panier",
                        column: x => x.idPanier,
                        principalTable: "PANIER",
                        principalColumn: "idPanier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_decrit_se_sejour",
                        column: x => x.idSejour,
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ETAPE",
                columns: table => new
                {
                    idEtape = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idSejour = table.Column<int>(type: "integer", nullable: true),
                    idHebergement = table.Column<int>(type: "integer", nullable: true),
                    titreEtape = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    descriptionEtape = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    photoEtape = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    URLEtape = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    videoEtape = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_etape", x => x.idEtape);
                    table.ForeignKey(
                        name: "fk_etape_appartien_hebergem",
                        column: x => x.idHebergement,
                        principalTable: "HEBERGEMENT",
                        principalColumn: "idHebergement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_etape_possede_sejour",
                        column: x => x.idSejour,
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstProposePars",
                columns: table => new
                {
                    idpartenaire = table.Column<int>(type: "integer", nullable: false),
                    idactivite = table.Column<int>(type: "integer", nullable: false),
                    idadresse = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_est_propose_par", x => new { x.idpartenaire, x.idactivite, x.idadresse });
                    table.ForeignKey(
                        name: "fk_propose__est_propose_par_autresoc",
                        column: x => x.idpartenaire,
                        principalTable: "AUTRESOCIETE",
                        principalColumn: "idPartenaire",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_propose__propose_5_activite",
                        column: x => x.idactivite,
                        principalTable: "ACTIVITE",
                        principalColumn: "idActivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_propose__propose_6_adresse",
                        column: x => x.idadresse,
                        principalTable: "ADRESSE",
                        principalColumn: "idAdresse",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COMMANDE",
                columns: table => new
                {
                    idCommande = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idCodePromo = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    idCB = table.Column<int>(type: "integer", nullable: true),
                    idAdresseFacturation = table.Column<int>(type: "integer", nullable: true),
                    idClientAcheteur = table.Column<int>(type: "integer", nullable: true),
                    idClientBeneficiaire = table.Column<int>(type: "integer", nullable: true),
                    idAdresseLivraison = table.Column<int>(type: "integer", nullable: true),
                    idPanier = table.Column<int>(type: "integer", nullable: true),
                    validationClient = table.Column<bool>(type: "boolean", nullable: false),
                    codeReduction = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    etatCommande = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, defaultValueSql: "'En attente de validation'::character varying"),
                    typePayementCommande = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    dateCommande = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "'2025-01-01'::date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_commande", x => x.idCommande);
                    table.ForeignKey(
                        name: "fk_commande_associati_adresse",
                        column: x => x.idAdresseLivraison,
                        principalTable: "ADRESSE",
                        principalColumn: "idAdresse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associati_adresse2",
                        column: x => x.idAdresseFacturation,
                        principalTable: "ADRESSE",
                        principalColumn: "idAdresse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associati_carte_ba",
                        column: x => x.idCB,
                        principalTable: "CARTE_BANCAIRE",
                        principalColumn: "idCB",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associati_client",
                        column: x => x.idClientBeneficiaire,
                        principalTable: "CLIENT",
                        principalColumn: "idClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associati_client2",
                        column: x => x.idClientAcheteur,
                        principalTable: "CLIENT",
                        principalColumn: "idClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associe_panier",
                        column: x => x.idPanier,
                        principalTable: "PANIER",
                        principalColumn: "idPanier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_diminue_codeprom",
                        column: x => x.idCodePromo,
                        principalTable: "CODEPROMO",
                        principalColumn: "idCodePromo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REPONSE",
                columns: table => new
                {
                    idReponse = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idAvis = table.Column<int>(type: "integer", nullable: true),
                    descriptionReponse = table.Column<string>(type: "character varying(2056)", maxLength: 2056, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reponse", x => x.idReponse);
                    table.ForeignKey(
                        name: "fk_reponse_repond_avis",
                        column: x => x.idAvis,
                        principalTable: "AVIS",
                        principalColumn: "idAvis",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comporte",
                columns: table => new
                {
                    Idactivite = table.Column<int>(type: "integer", nullable: false),
                    Iddescriptionpanier = table.Column<int>(type: "integer", nullable: false),
                    IdActivite = table.Column<int>(type: "integer", nullable: false),
                    IdDescriptionPanier = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comporte", x => new { x.Idactivite, x.Iddescriptionpanier });
                    table.ForeignKey(
                        name: "fk_associat_associati_activite",
                        column: x => x.Idactivite,
                        principalTable: "ACTIVITE",
                        principalColumn: "idActivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_associat_associati_descript",
                        column: x => x.Iddescriptionpanier,
                        principalTable: "DESCRIPTIONPANIER",
                        principalColumn: "idDescriptionPanier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detient",
                columns: table => new
                {
                    Idrepas = table.Column<int>(type: "integer", nullable: false),
                    Iddescriptionpanier = table.Column<int>(type: "integer", nullable: false),
                    IdDescriptionPanier = table.Column<int>(type: "integer", nullable: false),
                    IdRepas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_detient", x => new { x.Idrepas, x.Iddescriptionpanier });
                    table.ForeignKey(
                        name: "fk_associat_associati_descript",
                        column: x => x.Iddescriptionpanier,
                        principalTable: "DESCRIPTIONPANIER",
                        principalColumn: "idDescriptionPanier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_associat_associati_repas",
                        column: x => x.Idrepas,
                        principalTable: "REPAS",
                        principalColumn: "idRepas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "appartient",
                columns: table => new
                {
                    Idvisite = table.Column<int>(type: "integer", nullable: false),
                    Idetape = table.Column<int>(type: "integer", nullable: false),
                    IdEtape = table.Column<int>(type: "integer", nullable: false),
                    IdVisite = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appartient", x => new { x.Idvisite, x.Idetape });
                    table.ForeignKey(
                        name: "fk_appartie_appartien_etape",
                        column: x => x.Idetape,
                        principalTable: "ETAPE",
                        principalColumn: "idEtape",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_appartie_appartien_visite",
                        column: x => x.Idvisite,
                        principalTable: "VISITE",
                        principalColumn: "idVisite",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "constitue",
                columns: table => new
                {
                    Idactivite = table.Column<int>(type: "integer", nullable: false),
                    Idetape = table.Column<int>(type: "integer", nullable: false),
                    IdActivite = table.Column<int>(type: "integer", nullable: false),
                    IdEtape = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_constitue", x => new { x.Idactivite, x.Idetape });
                    table.ForeignKey(
                        name: "fk_appartie_appartien_activite",
                        column: x => x.Idactivite,
                        principalTable: "ACTIVITE",
                        principalColumn: "idActivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_appartie_appartien_etape",
                        column: x => x.Idetape,
                        principalTable: "ETAPE",
                        principalColumn: "idEtape",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inclus",
                columns: table => new
                {
                    Idrepas = table.Column<int>(type: "integer", nullable: false),
                    Idetape = table.Column<int>(type: "integer", nullable: false),
                    IdEtape = table.Column<int>(type: "integer", nullable: false),
                    IdRepas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inclus", x => new { x.Idrepas, x.Idetape });
                    table.ForeignKey(
                        name: "fk_appartie_appartien_etape",
                        column: x => x.Idetape,
                        principalTable: "ETAPE",
                        principalColumn: "idEtape",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_appartie_appartien_repas",
                        column: x => x.Idrepas,
                        principalTable: "REPAS",
                        principalColumn: "idRepas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DESCRIPTIONCOMMANDE",
                columns: table => new
                {
                    idDescriptionCommande = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idCommande = table.Column<int>(type: "integer", nullable: true),
                    idHebergement = table.Column<int>(type: "integer", nullable: true),
                    idPassegeiment = table.Column<int>(type: "integer", nullable: true),
                    idSejour = table.Column<int>(type: "integer", nullable: true),
                    quantite = table.Column<int>(type: "integer", nullable: true),
                    idCB = table.Column<int>(type: "integer", nullable: true),
                    prixOeuf = table.Column<int>(type: "integer", nullable: true),
                    dateFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    nbAdultes = table.Column<int>(type: "integer", nullable: true),
                    nbEnfants = table.Column<int>(type: "integer", nullable: true),
                    nbChambresSimple = table.Column<int>(type: "integer", nullable: true),
                    nbChambresDouble = table.Column<int>(type: "integer", nullable: true),
                    nbChambresTriple = table.Column<int>(type: "integer", nullable: true),
                    pDej = table.Column<bool>(type: "boolean", nullable: true),
                    isPDej = table.Column<bool>(type: "boolean", nullable: true),
                    encaissementMangement = table.Column<bool>(type: "boolean", nullable: true),
                    validationClient = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_descriptioncommande", x => x.idDescriptionCommande);
                    table.ForeignKey(
                        name: "fk_descript_associati_carte_ba",
                        column: x => x.idCB,
                        principalTable: "CARTE_BANCAIRE",
                        principalColumn: "idCB",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_associati_commande",
                        column: x => x.idCommande,
                        principalTable: "COMMANDE",
                        principalColumn: "idCommande",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_associati_hebergem",
                        column: x => x.idHebergement,
                        principalTable: "HEBERGEMENT",
                        principalColumn: "idHebergement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_associati_sejour",
                        column: x => x.idSejour,
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mange1",
                columns: table => new
                {
                    Idrepas = table.Column<int>(type: "integer", nullable: false),
                    Iddescriptioncommande = table.Column<int>(type: "integer", nullable: false),
                    IdRepas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contient", x => new { x.Idrepas, x.Iddescriptioncommande });
                    table.ForeignKey(
                        name: "fk_associat_associati_descript",
                        column: x => x.Iddescriptioncommande,
                        principalTable: "DESCRIPTIONCOMMANDE",
                        principalColumn: "idDescriptionCommande",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_associat_associati_repas",
                        column: x => x.Idrepas,
                        principalTable: "REPAS",
                        principalColumn: "idRepas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "possede",
                columns: table => new
                {
                    Idactivite = table.Column<int>(type: "integer", nullable: false),
                    Iddescriptioncommande = table.Column<int>(type: "integer", nullable: false),
                    IdDescriptionCommande = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_possede", x => new { x.Idactivite, x.Iddescriptioncommande });
                    table.ForeignKey(
                        name: "fk_associat_associati_activite",
                        column: x => x.Idactivite,
                        principalTable: "ACTIVITE",
                        principalColumn: "idActivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_associat_associati_descript",
                        column: x => x.Iddescriptioncommande,
                        principalTable: "DESCRIPTIONCOMMANDE",
                        principalColumn: "idDescriptionCommande",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADRESSE_idClient",
                table: "ADRESSE",
                column: "idClient");

            migrationBuilder.CreateIndex(
                name: "IX_ADRESSE_idPartenaire",
                table: "ADRESSE",
                column: "idPartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_appartient_Idetape",
                table: "appartient",
                column: "Idetape");

            migrationBuilder.CreateIndex(
                name: "IX_AVIS_idClient",
                table: "AVIS",
                column: "idClient");

            migrationBuilder.CreateIndex(
                name: "IX_AVIS_idSejour",
                table: "AVIS",
                column: "idSejour");

            migrationBuilder.CreateIndex(
                name: "IX_CARTE_BANCAIRE_idClient",
                table: "CARTE_BANCAIRE",
                column: "idClient");

            migrationBuilder.CreateIndex(
                name: "IX_CAVE_idTypeDegustation",
                table: "CAVE",
                column: "idTypeDegustation");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_idRole",
                table: "CLIENT",
                column: "idRole");

            migrationBuilder.CreateIndex(
                name: "IX_COMMANDE_idAdresseFacturation",
                table: "COMMANDE",
                column: "idAdresseFacturation");

            migrationBuilder.CreateIndex(
                name: "IX_COMMANDE_idAdresseLivraison",
                table: "COMMANDE",
                column: "idAdresseLivraison");

            migrationBuilder.CreateIndex(
                name: "IX_COMMANDE_idCB",
                table: "COMMANDE",
                column: "idCB");

            migrationBuilder.CreateIndex(
                name: "IX_COMMANDE_idClientAcheteur",
                table: "COMMANDE",
                column: "idClientAcheteur");

            migrationBuilder.CreateIndex(
                name: "IX_COMMANDE_idClientBeneficiaire",
                table: "COMMANDE",
                column: "idClientBeneficiaire");

            migrationBuilder.CreateIndex(
                name: "IX_COMMANDE_idCodePromo",
                table: "COMMANDE",
                column: "idCodePromo");

            migrationBuilder.CreateIndex(
                name: "IX_COMMANDE_idPanier",
                table: "COMMANDE",
                column: "idPanier");

            migrationBuilder.CreateIndex(
                name: "IX_comporte_Iddescriptionpanier",
                table: "comporte",
                column: "Iddescriptionpanier");

            migrationBuilder.CreateIndex(
                name: "IX_constitue_Idetape",
                table: "constitue",
                column: "Idetape");

            migrationBuilder.CreateIndex(
                name: "IX_DESCRIPTIONCOMMANDE_idCB",
                table: "DESCRIPTIONCOMMANDE",
                column: "idCB");

            migrationBuilder.CreateIndex(
                name: "IX_DESCRIPTIONCOMMANDE_idCommande",
                table: "DESCRIPTIONCOMMANDE",
                column: "idCommande");

            migrationBuilder.CreateIndex(
                name: "IX_DESCRIPTIONCOMMANDE_idHebergement",
                table: "DESCRIPTIONCOMMANDE",
                column: "idHebergement");

            migrationBuilder.CreateIndex(
                name: "IX_DESCRIPTIONCOMMANDE_idSejour",
                table: "DESCRIPTIONCOMMANDE",
                column: "idSejour");

            migrationBuilder.CreateIndex(
                name: "IX_DESCRIPTIONPANIER_idHebergement",
                table: "DESCRIPTIONPANIER",
                column: "idHebergement");

            migrationBuilder.CreateIndex(
                name: "IX_DESCRIPTIONPANIER_idPanier",
                table: "DESCRIPTIONPANIER",
                column: "idPanier");

            migrationBuilder.CreateIndex(
                name: "IX_DESCRIPTIONPANIER_idSejour",
                table: "DESCRIPTIONPANIER",
                column: "idSejour");

            migrationBuilder.CreateIndex(
                name: "IX_detient_Iddescriptionpanier",
                table: "detient",
                column: "Iddescriptionpanier");

            migrationBuilder.CreateIndex(
                name: "IX_EstProposePars_idactivite",
                table: "EstProposePars",
                column: "idactivite");

            migrationBuilder.CreateIndex(
                name: "IX_EstProposePars_idadresse",
                table: "EstProposePars",
                column: "idadresse");

            migrationBuilder.CreateIndex(
                name: "IX_ETAPE_idHebergement",
                table: "ETAPE",
                column: "idHebergement");

            migrationBuilder.CreateIndex(
                name: "IX_ETAPE_idSejour",
                table: "ETAPE",
                column: "idSejour");

            migrationBuilder.CreateIndex(
                name: "IX_favoris_Idsejour",
                table: "favoris",
                column: "Idsejour");

            migrationBuilder.CreateIndex(
                name: "IX_HEBERGEMENT_idPartenaire",
                table: "HEBERGEMENT",
                column: "idPartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_inclus_Idetape",
                table: "inclus",
                column: "Idetape");

            migrationBuilder.CreateIndex(
                name: "IX_LOCALITE_idCategorieVignoble",
                table: "LOCALITE",
                column: "idCategorieVignoble");

            migrationBuilder.CreateIndex(
                name: "IX_mange1_Iddescriptioncommande",
                table: "mange1",
                column: "Iddescriptioncommande");

            migrationBuilder.CreateIndex(
                name: "IX_PANIER_idCodePromo",
                table: "PANIER",
                column: "idCodePromo");

            migrationBuilder.CreateIndex(
                name: "IX_PHOTO_idSejour",
                table: "PHOTO",
                column: "idSejour");

            migrationBuilder.CreateIndex(
                name: "IX_possede_Iddescriptioncommande",
                table: "possede",
                column: "Iddescriptioncommande");

            migrationBuilder.CreateIndex(
                name: "IX_REPAS_idPartenaire",
                table: "REPAS",
                column: "idPartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_REPONSE_idAvis",
                table: "REPONSE",
                column: "idAvis");

            migrationBuilder.CreateIndex(
                name: "IX_RESTAURANT_idTypeCuisine",
                table: "RESTAURANT",
                column: "idTypeCuisine");

            migrationBuilder.CreateIndex(
                name: "IX_se_localise_Idcategorievignoble",
                table: "se_localise",
                column: "Idcategorievignoble");

            migrationBuilder.CreateIndex(
                name: "IX_sejour_idcategorieparticipant",
                table: "sejour",
                column: "idcategorieparticipant");

            migrationBuilder.CreateIndex(
                name: "IX_sejour_idcategoriesejour",
                table: "sejour",
                column: "idcategoriesejour");

            migrationBuilder.CreateIndex(
                name: "IX_sejour_idcategorievignoble",
                table: "sejour",
                column: "idcategorievignoble");

            migrationBuilder.CreateIndex(
                name: "IX_sejour_idduree",
                table: "sejour",
                column: "idduree");

            migrationBuilder.CreateIndex(
                name: "IX_sejour_idlocalite",
                table: "sejour",
                column: "idlocalite");

            migrationBuilder.CreateIndex(
                name: "IX_sejour_idtheme",
                table: "sejour",
                column: "idtheme");

            migrationBuilder.CreateIndex(
                name: "IX_VISITE_idPartenaire",
                table: "VISITE",
                column: "idPartenaire");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appartient");

            migrationBuilder.DropTable(
                name: "comporte");

            migrationBuilder.DropTable(
                name: "constitue");

            migrationBuilder.DropTable(
                name: "detient");

            migrationBuilder.DropTable(
                name: "EstProposePars");

            migrationBuilder.DropTable(
                name: "favoris");

            migrationBuilder.DropTable(
                name: "inclus");

            migrationBuilder.DropTable(
                name: "mange1");

            migrationBuilder.DropTable(
                name: "PHOTO");

            migrationBuilder.DropTable(
                name: "possede");

            migrationBuilder.DropTable(
                name: "REPONSE");

            migrationBuilder.DropTable(
                name: "se_localise");

            migrationBuilder.DropTable(
                name: "VISITE");

            migrationBuilder.DropTable(
                name: "DESCRIPTIONPANIER");

            migrationBuilder.DropTable(
                name: "AUTRESOCIETE");

            migrationBuilder.DropTable(
                name: "ETAPE");

            migrationBuilder.DropTable(
                name: "REPAS");

            migrationBuilder.DropTable(
                name: "ACTIVITE");

            migrationBuilder.DropTable(
                name: "DESCRIPTIONCOMMANDE");

            migrationBuilder.DropTable(
                name: "AVIS");

            migrationBuilder.DropTable(
                name: "ROUTE_DES_VINS");

            migrationBuilder.DropTable(
                name: "CAVE");

            migrationBuilder.DropTable(
                name: "RESTAURANT");

            migrationBuilder.DropTable(
                name: "COMMANDE");

            migrationBuilder.DropTable(
                name: "HEBERGEMENT");

            migrationBuilder.DropTable(
                name: "sejour");

            migrationBuilder.DropTable(
                name: "TYPEDEGUSTATION");

            migrationBuilder.DropTable(
                name: "TYPECUISINE");

            migrationBuilder.DropTable(
                name: "ADRESSE");

            migrationBuilder.DropTable(
                name: "CARTE_BANCAIRE");

            migrationBuilder.DropTable(
                name: "PANIER");

            migrationBuilder.DropTable(
                name: "HOTEL");

            migrationBuilder.DropTable(
                name: "THEME");

            migrationBuilder.DropTable(
                name: "CATEGORIEEPARTICIPANT");

            migrationBuilder.DropTable(
                name: "DUREE");

            migrationBuilder.DropTable(
                name: "CATEGORIESEJOUR");

            migrationBuilder.DropTable(
                name: "LOCALITE");

            migrationBuilder.DropTable(
                name: "CLIENT");

            migrationBuilder.DropTable(
                name: "CODEPROMO");

            migrationBuilder.DropTable(
                name: "PARTENAIRE");

            migrationBuilder.DropTable(
                name: "CATEGORIEVIGNOBLE");

            migrationBuilder.DropTable(
                name: "ROLES");
        }
    }
}
