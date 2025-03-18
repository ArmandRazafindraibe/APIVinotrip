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
                name: "activite",
                columns: table => new
                {
                    idactivite = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelleactivite = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    prixactivite = table.Column<decimal>(type: "numeric(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_activite", x => x.idactivite);
                });

            migrationBuilder.CreateTable(
                name: "categorieeparticipant",
                columns: table => new
                {
                    idcategorieparticipant = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libellecategorieparticipant = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categorieparticipant", x => x.idcategorieparticipant);
                });

            migrationBuilder.CreateTable(
                name: "categoriesejour",
                columns: table => new
                {
                    idcategoriesejour = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libellecategoriessejour = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categoriesejour", x => x.idcategoriesejour);
                });

            migrationBuilder.CreateTable(
                name: "categorievignoble",
                columns: table => new
                {
                    idcategorievignoble = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libellecategorievignoble = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categorievignoble", x => x.idcategorievignoble);
                });

            migrationBuilder.CreateTable(
                name: "codepromo",
                columns: table => new
                {
                    idcodepromo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libellecodepromo = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    reduction = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_codepromo", x => x.idcodepromo);
                });

            migrationBuilder.CreateTable(
                name: "duree",
                columns: table => new
                {
                    idduree = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelleduree = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_duree", x => x.idduree);
                });

            migrationBuilder.CreateTable(
                name: "partenaire",
                columns: table => new
                {
                    idpartenaire = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nompartenaire = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    mailpartenaire = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    telpartenaire = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_partenaire", x => x.idpartenaire);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    idrole = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libellerole = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.idrole);
                });

            migrationBuilder.CreateTable(
                name: "route_des_vins",
                columns: table => new
                {
                    idroute = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libroute = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    descriptionroute = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    photoroute = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_route_des_vins", x => x.idroute);
                });

            migrationBuilder.CreateTable(
                name: "theme",
                columns: table => new
                {
                    idtheme = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelletheme = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_theme", x => x.idtheme);
                });

            migrationBuilder.CreateTable(
                name: "typecuisine",
                columns: table => new
                {
                    idtypecuisine = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelletypecuisine = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typecuisine", x => x.idtypecuisine);
                });

            migrationBuilder.CreateTable(
                name: "typedegustation",
                columns: table => new
                {
                    idtypedegustation = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelletypedegustation = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typedegustation", x => x.idtypedegustation);
                });

            migrationBuilder.CreateTable(
                name: "localite",
                columns: table => new
                {
                    idlocalite = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libellelocalite = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    idcategorievignoble = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_localite", x => x.idlocalite);
                    table.ForeignKey(
                        name: "fk_localite_a_categori",
                        column: x => x.idcategorievignoble,
                        principalTable: "categorievignoble",
                        principalColumn: "idcategorievignoble",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "panier",
                columns: table => new
                {
                    idpanier = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idcodepromo = table.Column<int>(type: "integer", nullable: true),
                    dateajoutpanier = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_panier", x => x.idpanier);
                    table.ForeignKey(
                        name: "fk_panier_reduit_codeprom",
                        column: x => x.idcodepromo,
                        principalTable: "codepromo",
                        principalColumn: "idcodepromo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "autresociete",
                columns: table => new
                {
                    idpartenaire = table.Column<int>(type: "integer", nullable: false),
                    nompartenaire = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    mailpartenaire = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    telpartenaire = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_autresociete", x => x.idpartenaire);
                    table.ForeignKey(
                        name: "fk_autresoc_heritage__partenai",
                        column: x => x.idpartenaire,
                        principalTable: "partenaire",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hotel",
                columns: table => new
                {
                    idpartenaire = table.Column<int>(type: "integer", nullable: false),
                    nompartenaire = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    mailpartenaire = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    telpartenaire = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    nombrechambreshotel = table.Column<int>(type: "integer", nullable: true),
                    categoriehotel = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hotel", x => x.idpartenaire);
                    table.ForeignKey(
                        name: "fk_hotel_heritage__partenai",
                        column: x => x.idpartenaire,
                        principalTable: "partenaire",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    idclient = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    civiliteclient = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    nomclient = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    prenomclient = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    emailclient = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    mdpclient = table.Column<string>(type: "character varying(50)", maxLength: 500, nullable: true),
                    datenaissanceclient = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    datecreationcompteclient = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    telclient = table.Column<string>(type: "character(12)", fixedLength: true, maxLength: 12, nullable: true),
                    datederniereactiviteclient = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    a2f = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    offrespromotionnellesclient= table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    idrole = table.Column<int>(type: "integer", nullable: true),
                    bloquingclient = table.Column<bool>(type: "boolean", nullable: true),
                    tokenresetmdp = table.Column<string>(type: "character(50)", fixedLength: true, maxLength: 50, nullable: true, defaultValueSql: "NULL::bpchar"),
                    datecreationtoken = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client", x => x.idclient);
                    table.ForeignKey(
                        name: "fk_client_associati_roles",
                        column: x => x.idrole,
                        principalTable: "roles",
                        principalColumn: "idrole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "se_localise",
                columns: table => new
                {
                    idroute = table.Column<int>(type: "integer", nullable: false),
                    idcategorievignoble = table.Column<int>(type: "integer", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_se_localise", x => new { x.idroute, x.idcategorievignoble });
                    table.ForeignKey(
                        name: "fk_se_local_se_locali_categori",
                        column: x => x.idcategorievignoble,
                        principalTable: "categorievignoble",
                        principalColumn: "idcategorievignoble",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_se_local_se_locali_route_de",
                        column: x => x.idroute,
                        principalTable: "route_des_vins",
                        principalColumn: "idroute",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "restaurant",
                columns: table => new
                {
                    idpartenaire = table.Column<int>(type: "integer", nullable: false),
                    idtypecuisine = table.Column<int>(type: "integer", nullable: true),
                    nompartenaire = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    mailpartenaire = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    telpartenaire = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    nombreetoilesrestaurant = table.Column<int>(type: "integer", nullable: true),
                    specialiterestaurant = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_restaurant", x => x.idpartenaire);
                    table.ForeignKey(
                        name: "fk_restaura_cuisine_typecuis",
                        column: x => x.idtypecuisine,
                        principalTable: "typecuisine",
                        principalColumn: "idtypecuisine",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_restaura_heritage__partenai",
                        column: x => x.idpartenaire,
                        principalTable: "partenaire",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cave",
                columns: table => new
                {
                    idpartenaire = table.Column<int>(type: "integer", nullable: false),
                    idtypedegustation = table.Column<int>(type: "integer", nullable: true),
                    nompartenaire = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    mailpartenaire = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    telpartenaire = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cave", x => x.idpartenaire);
                    table.ForeignKey(
                        name: "fk_cave_fait_degu_typedegu",
                        column: x => x.idtypedegustation,
                        principalTable: "typedegustation",
                        principalColumn: "idtypedegustation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cave_heritage__partenai",
                        column: x => x.idpartenaire,
                        principalTable: "partenaire",
                        principalColumn: "idpartenaire",
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
                        principalTable: "categorievignoble",
                        principalColumn: "idcategorievignoble",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_definit_theme",
                        column: x => x.idtheme,
                        principalTable: "theme",
                        principalColumn: "idtheme",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_destine_a_categori",
                        column: x => x.idcategorieparticipant,
                        principalTable: "categorieeparticipant",
                        principalColumn: "idcategorieparticipant",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_dure_duree",
                        column: x => x.idduree,
                        principalTable: "duree",
                        principalColumn: "idduree",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_regroupe_categori",
                        column: x => x.idcategoriesejour,
                        principalTable: "categoriesejour",
                        principalColumn: "idcategoriesejour",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_se_situe_localite",
                        column: x => x.idlocalite,
                        principalTable: "localite",
                        principalColumn: "idlocalite",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hebergement",
                columns: table => new
                {
                    idhebergement = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idpartenaire = table.Column<int>(type: "integer", nullable: false),
                    descriptionhebergement = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    photohebergement = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    lienhebergement = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    prixhebergement = table.Column<decimal>(type: "numeric(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hebergement", x => x.idhebergement);
                    table.ForeignKey(
                        name: "fk_hebergem_propose_3_hotel",
                        column: x => x.idpartenaire,
                        principalTable: "hotel",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "adresse",
                columns: table => new
                {
                    idadresse = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nadresse = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    idclient = table.Column<int>(type: "integer", nullable: true),
                    idpartenaire = table.Column<int>(type: "integer", nullable: true),
                    prenomadressedestination = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    nomadressedestinataire = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    rueadresse = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    villeadresse = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    paysadresse = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, defaultValueSql: "'France'::character varying"),
                    cpadresse = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    numadresse = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adresse", x => x.idadresse);
                    table.ForeignKey(
                        name: "fk_adresse_associati_client",
                        column: x => x.idclient,
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_adresse_localise_partenai",
                        column: x => x.idpartenaire,
                        principalTable: "partenaire",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "carte_bancaire",
                columns: table => new
                {
                    idcb = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idclient = table.Column<int>(type: "integer", nullable: true),
                    titulairecb = table.Column<string>(type: "character varying(100)",  maxLength: 100, nullable: true),
                    numerocb = table.Column<string>(type: "character(50)", fixedLength: true, maxLength: 50, nullable: true),
                    numerocvccarte = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    dateexpirationcreditcard = table.Column<DateTime>(type: "timestamp with time zone", fixedLength: true, nullable: true),
                    actif = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_carte_bancaire", x => x.idcb);
                    table.ForeignKey(
                        name: "fk_carte_ba_associati_client",
                        column: x => x.idclient,
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "repas",
                columns: table => new
                {
                    idrepas = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idpartenaire = table.Column<int>(type: "integer", nullable: true),
                    descriptionrepas = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    photorepas = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    prixrepas = table.Column<decimal>(type: "numeric(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_repas", x => x.idrepas);
                    table.ForeignKey(
                        name: "fk_repas_propose_2_restaura",
                        column: x => x.idpartenaire,
                        principalTable: "restaurant",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "visite",
                columns: table => new
                {
                    idvisite = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idpartenaire = table.Column<int>(type: "integer", nullable: true),
                    descriptionvisite = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    photoVisite = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    lienVisite = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_visite", x => x.idvisite);
                    table.ForeignKey(
                        name: "fk_visite_propose_1_cave",
                        column: x => x.idpartenaire,
                        principalTable: "cave",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "avis",
                columns: table => new
                {
                    idavis = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idsejour = table.Column<int>(type: "integer", nullable: true),
                    idclient = table.Column<int>(type: "integer", nullable: true),
                    dateavis = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    titreavis = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    descriptionavis = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    noteavis = table.Column<int>(type: "integer", nullable: true),
                    photoavis = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_avis", x => x.idavis);
                    table.ForeignKey(
                        name: "fk_avis_associati_client",
                        column: x => x.idclient,
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_avis_critique_sejour",
                        column: x => x.idsejour,
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "favoris",
                columns: table => new
                {
                    idclient = table.Column<int>(type: "integer", nullable: false),
                    idsejour = table.Column<int>(type: "integer", nullable: false),
                 
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_favoris", x => new { x.idclient, x.idsejour });
                    table.ForeignKey(
                        name: "fk_favoris_favoris2_sejour",
                        column: x => x.idsejour,
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_favoris_favoris_client",
                        column: x => x.idclient,
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "photo",
                columns: table => new
                {
                    idphoto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idsejour = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_photos", x => x.idphoto);
                    table.ForeignKey(
                        name: "fk_photos_associati_sejour",
                        column: x => x.idsejour,
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "descriptionpanier",
                columns: table => new
                {
                    iddescriptionpanier = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idsejour = table.Column<int>(type: "integer", nullable: true),
                    idpanier = table.Column<int>(type: "integer", nullable: true),
                    idhebergement = table.Column<int>(type: "integer", nullable: true),
                    quantite = table.Column<int>(type: "integer", nullable: true),
                    datedebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    datefin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    nbadultes = table.Column<int>(type: "integer", nullable: true),
                    nbenfants = table.Column<int>(type: "integer", nullable: true),
                    nbchambressimple = table.Column<int>(type: "integer", nullable: true),
                    nbchambresdouble = table.Column<int>(type: "integer", nullable: true),
                    nbchambrestriple = table.Column<int>(type: "integer", nullable: true),
                    offrir = table.Column<bool>(type: "boolean", nullable: true),
                    ecoffret = table.Column<bool>(type: "boolean", nullable: true),
                    disponibilitehebergement = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_descriptionpanier", x => x.iddescriptionpanier);
                    table.ForeignKey(
                        name: "fk_descript_associati_hebergem",
                        column: x => x.idhebergement,
                        principalTable: "hebergement",
                        principalColumn: "idhebergement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_decrit_pa_panier",
                        column: x => x.idpanier,
                        principalTable: "panier",
                        principalColumn: "idpanier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_decrit_se_sejour",
                        column: x => x.idsejour,
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "etape",
                columns: table => new
                {
                    idetape = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idsejour = table.Column<int>(type: "integer", nullable: true),
                    idhebergement = table.Column<int>(type: "integer", nullable: true),
                    titreetape = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    descriptionetape = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    photoetape = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    urletape = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    videoetape = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_etape", x => x.idetape);
                    table.ForeignKey(
                        name: "fk_etape_appartien_hebergem",
                        column: x => x.idhebergement,
                        principalTable: "hebergement",
                        principalColumn: "idhebergement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_etape_possede_sejour",
                        column: x => x.idsejour,
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "estproposepar",
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
                        principalTable: "autresociete",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_propose__propose_5_activite",
                        column: x => x.idactivite,
                        principalTable: "activite",
                        principalColumn: "idactivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_propose__propose_6_adresse",
                        column: x => x.idadresse,
                        principalTable: "adresse",
                        principalColumn: "idadresse",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "commande",
                columns: table => new
                {
                    idcommande = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idcodepromo = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    idcb = table.Column<int>(type: "integer", nullable: true),
                    idadressefacturation = table.Column<int>(type: "integer", nullable: true),
                    idclientacheteur = table.Column<int>(type: "integer", nullable: true),
                    idclientbeneficiaire = table.Column<int>(type: "integer", nullable: true),
                    idadresselivraison = table.Column<int>(type: "integer", nullable: true),
                    idpanier = table.Column<int>(type: "integer", nullable: true),
                    validationClient = table.Column<bool>(type: "boolean", nullable: false),
                    codereduction = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    etatcommande = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, defaultValueSql: "'En attente de validation'::character varying"),
                    typepayementcommande = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    datecommande = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "'2025-01-01'::date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_commande", x => x.idcommande);
                    table.ForeignKey(
                        name: "fk_commande_associati_adresse",
                        column: x => x.idadresselivraison,
                        principalTable: "adresse",
                        principalColumn: "idadresse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associati_adresse2",
                        column: x => x.idadressefacturation,
                        principalTable: "adresse",
                        principalColumn: "idadresse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associati_carte_ba",
                        column: x => x.idcb,
                        principalTable: "carte_bancaire",
                        principalColumn: "idcb",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associati_client",
                        column: x => x.idclientbeneficiaire,
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associati_client2",
                        column: x => x.idclientacheteur,
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associe_panier",
                        column: x => x.idpanier,
                        principalTable: "panier",
                        principalColumn: "idpanier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_diminue_codeprom",
                        column: x => x.idcodepromo,
                        principalTable: "codepromo",
                        principalColumn: "idcodepromo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reponse",
                columns: table => new
                {
                    idreponse = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idavis = table.Column<int>(type: "integer", nullable: true),
                    descriptionreponse = table.Column<string>(type: "character varying(2056)", maxLength: 2056, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reponse", x => x.idreponse);
                    table.ForeignKey(
                        name: "fk_reponse_repond_avis",
                        column: x => x.idavis,
                        principalTable: "avis",
                        principalColumn: "idavis",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comporte",
                columns: table => new
                {
                    idactivite = table.Column<int>(type: "integer", nullable: false),
                    iddescriptionpanier = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comporte", x => new { x.idactivite, x.iddescriptionpanier });
                    table.ForeignKey(
                        name: "fk_associat_associati_activite",
                        column: x => x.idactivite,
                        principalTable: "activite",
                        principalColumn: "idactivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_associat_associati_descript",
                        column: x => x.iddescriptionpanier,
                        principalTable: "descriptionpanier",
                        principalColumn: "iddescriptionpanier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detient",
                columns: table => new
                {
                    idrepas = table.Column<int>(type: "integer", nullable: false),
                    iddescriptionpanier = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_detient", x => new { x.idrepas, x.iddescriptionpanier });
                    table.ForeignKey(
                        name: "fk_associat_associati_descript",
                        column: x => x.iddescriptionpanier,
                        principalTable: "descriptionpanier",
                        principalColumn: "iddescriptionpanier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_associat_associati_repas",
                        column: x => x.idrepas,
                        principalTable: "repas",
                        principalColumn: "idrepas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "appartient",
                columns: table => new
                {
                    idvisite = table.Column<int>(type: "integer", nullable: false),
                    idetape = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appartient", x => new { x.idvisite, x.idetape });
                    table.ForeignKey(
                        name: "fk_appartie_appartien_etape",
                        column: x => x.idetape,
                        principalTable: "etape",
                        principalColumn: "idetape",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_appartie_appartien_visite",
                        column: x => x.idvisite,
                        principalTable: "visite",
                        principalColumn: "idvisite",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "constitue",
                columns: table => new
                {
                    idactivite = table.Column<int>(type: "integer", nullable: false),
                    idetape = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_constitue", x => new { x.idactivite, x.idetape });
                    table.ForeignKey(
                        name: "fk_appartie_appartien_activite",
                        column: x => x.idactivite,
                        principalTable: "activite",
                        principalColumn: "idactivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_appartie_appartien_etape",
                        column: x => x.idetape,
                        principalTable: "etape",
                        principalColumn: "idetape",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inclus",
                columns: table => new
                {
                    idrepas = table.Column<int>(type: "integer", nullable: false),
                    idetape = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inclus", x => new { x.idrepas, x.idetape });
                    table.ForeignKey(
                        name: "fk_appartie_appartien_etape",
                        column: x => x.idetape,
                        principalTable: "etape",
                        principalColumn: "idetape",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_appartie_appartien_repas",
                        column: x => x.idrepas,
                        principalTable: "repas",
                        principalColumn: "idrepas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "descriptioncommande",
                columns: table => new
                {
                    iddescriptioncommande = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idcommande = table.Column<int>(type: "integer", nullable: true),
                    idhebergement = table.Column<int>(type: "integer", nullable: true),
                    idpassegeiment = table.Column<int>(type: "integer", nullable: true),
                    idsejour = table.Column<int>(type: "integer", nullable: true),
                    quantite = table.Column<int>(type: "integer", nullable: true),
                    idcb = table.Column<int>(type: "integer", nullable: true),
                    prixoeuf = table.Column<int>(type: "integer", nullable: true),
                    datefin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    nbadultes = table.Column<int>(type: "integer", nullable: true),
                    nbenfants = table.Column<int>(type: "integer", nullable: true),
                    nbchambressimple = table.Column<int>(type: "integer", nullable: true),
                    nbchambresdouble = table.Column<int>(type: "integer", nullable: true),
                    nbchambrestriple = table.Column<int>(type: "integer", nullable: true),
                    pdej = table.Column<bool>(type: "boolean", nullable: true),
                    ispdej = table.Column<bool>(type: "boolean", nullable: true),
                    encaissementmangement = table.Column<bool>(type: "boolean", nullable: true),
                    validationclient = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_descriptioncommande", x => x.iddescriptioncommande);
                    table.ForeignKey(
                        name: "fk_descript_associati_carte_ba",
                        column: x => x.idcb,
                        principalTable: "carte_bancaire",
                        principalColumn: "idcb",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_associati_commande",
                        column: x => x.idcommande,
                        principalTable: "commande",
                        principalColumn: "idcommande",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_associati_hebergem",
                        column: x => x.idhebergement,
                        principalTable: "hebergement",
                        principalColumn: "idhebergement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_associati_sejour",
                        column: x => x.idsejour,
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mange1",
                columns: table => new
                {
                    idrepas = table.Column<int>(type: "integer", nullable: false),
                    iddescriptioncommande = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contient", x => new { x.idrepas, x.iddescriptioncommande });
                    table.ForeignKey(
                        name: "fk_associat_associati_descript",
                        column: x => x.iddescriptioncommande,
                        principalTable: "descriptioncommande",
                        principalColumn: "iddescriptioncommande",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_associat_associati_repas",
                        column: x => x.idrepas,
                        principalTable: "repas",
                        principalColumn: "idrepas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "possede",
                columns: table => new
                {
                    idactivite = table.Column<int>(type: "integer", nullable: false),
                    iddescriptioncommande = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_possede", x => new { x.idactivite, x.iddescriptioncommande });
                    table.ForeignKey(
                        name: "fk_associat_associati_activite",
                        column: x => x.idactivite,
                        principalTable: "activite",
                        principalColumn: "idactivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_associat_associati_descript",
                        column: x => x.iddescriptioncommande,
                        principalTable: "descriptioncommande",
                        principalColumn: "iddescriptioncommande",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adresse_idclient",
                table: "adresse",
                column: "idclient");

            migrationBuilder.CreateIndex(
                name: "IX_adresse_idpartenaire",
                table: "adresse",
                column: "idpartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_appartient_idetape",
                table: "appartient",
                column: "idetape");

            migrationBuilder.CreateIndex(
                name: "IX_avis_idclient",
                table: "avis",
                column: "idclient");

            migrationBuilder.CreateIndex(
                name: "IX_avis_idsejour",
                table: "avis",
                column: "idsejour");

            migrationBuilder.CreateIndex(
                name: "IX_carte_bancaire_idclient",
                table: "carte_bancaire",
                column: "idclient");

            migrationBuilder.CreateIndex(
                name: "IX_cave_idtypedegustation",
                table: "cave",
                column: "idtypedegustation");

            migrationBuilder.CreateIndex(
                name: "IX_client_idrole",
                table: "client",
                column: "idrole");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idadressefacturation",
                table: "commande",
                column: "idadressefacturation");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idadresselivraison",
                table: "commande",
                column: "idadresselivraison");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idcb",
                table: "commande",
                column: "idcb");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idclientacheteur",
                table: "commande",
                column: "idclientacheteur");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idclientbeneficiaire",
                table: "commande",
                column: "idclientbeneficiaire");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idcodepromo",
                table: "commande",
                column: "idcodepromo");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idpanier",
                table: "commande",
                column: "idpanier");

            migrationBuilder.CreateIndex(
                name: "IX_comporte_iddescriptionpanier",
                table: "comporte",
                column: "iddescriptionpanier");

            migrationBuilder.CreateIndex(
                name: "IX_constitue_idetape",
                table: "constitue",
                column: "idetape");

            migrationBuilder.CreateIndex(
                name: "IX_descriptioncommande_idcb",
                table: "descriptioncommande",
                column: "idcb");

            migrationBuilder.CreateIndex(
                name: "IX_descriptioncommande_idcommande",
                table: "descriptioncommande",
                column: "idcommande");

            migrationBuilder.CreateIndex(
                name: "IX_descriptioncommande_idhebergement",
                table: "descriptioncommande",
                column: "idhebergement");

            migrationBuilder.CreateIndex(
                name: "IX_descriptioncommande_idsejour",
                table: "descriptioncommande",
                column: "idsejour");

            migrationBuilder.CreateIndex(
                name: "IX_descriptionpanier_idhebergement",
                table: "descriptionpanier",
                column: "idhebergement");

            migrationBuilder.CreateIndex(
                name: "IX_descriptionpanier_idpanier",
                table: "descriptionpanier",
                column: "idpanier");

            migrationBuilder.CreateIndex(
                name: "IX_descriptionpanier_idsejour",
                table: "descriptionpanier",
                column: "idsejour");

            migrationBuilder.CreateIndex(
                name: "IX_detient_iddescriptionpanier",
                table: "detient",
                column: "iddescriptionpanier");

            migrationBuilder.CreateIndex(
                name: "IX_estproposepar_idactivite",
                table: "estproposepar",
                column: "idactivite");

            migrationBuilder.CreateIndex(
                name: "IX_estproposepar_idadresse",
                table: "estproposepar",
                column: "idadresse");

            migrationBuilder.CreateIndex(
                name: "IX_etape_idhebergement",
                table: "etape",
                column: "idhebergement");

            migrationBuilder.CreateIndex(
                name: "IX_etape_idsejour",
                table: "etape",
                column: "idsejour");

            migrationBuilder.CreateIndex(
                name: "IX_favoris_idsejour",
                table: "favoris",
                column: "idsejour");

            migrationBuilder.CreateIndex(
                name: "IX_hebergement_idpartenaire",
                table: "hebergement",
                column: "idpartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_inclus_idetape",
                table: "inclus",
                column: "idetape");

            migrationBuilder.CreateIndex(
                name: "IX_localite_idcategorievignoble",
                table: "localite",
                column: "idcategorievignoble");

            migrationBuilder.CreateIndex(
                name: "IX_mange1_iddescriptioncommande",
                table: "mange1",
                column: "iddescriptioncommande");

            migrationBuilder.CreateIndex(
                name: "IX_panier_idcodepromo",
                table: "panier",
                column: "idcodepromo");

            migrationBuilder.CreateIndex(
                name: "IX_photo_idsejour",
                table: "photo",
                column: "idsejour");

            migrationBuilder.CreateIndex(
                name: "IX_possede_iddescriptioncommande",
                table: "possede",
                column: "iddescriptioncommande");

            migrationBuilder.CreateIndex(
                name: "IX_repas_idpartenaire",
                table: "repas",
                column: "idpartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_reponse_idavis",
                table: "reponse",
                column: "idavis");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_idtypecuisine",
                table: "restaurant",
                column: "idtypecuisine");

            migrationBuilder.CreateIndex(
                name: "IX_se_localise_idcategorievignoble",
                table: "se_localise",
                column: "idcategorievignoble");

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
                name: "IX_visite_idpartenaire",
                table: "visite",
                column: "idpartenaire");
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
                name: "estproposepar");

            migrationBuilder.DropTable(
                name: "favoris");

            migrationBuilder.DropTable(
                name: "inclus");

            migrationBuilder.DropTable(
                name: "mange1");

            migrationBuilder.DropTable(
                name: "photo");

            migrationBuilder.DropTable(
                name: "possede");

            migrationBuilder.DropTable(
                name: "reponse");

            migrationBuilder.DropTable(
                name: "se_localise");

            migrationBuilder.DropTable(
                name: "visite");

            migrationBuilder.DropTable(
                name: "descriptionpanier");

            migrationBuilder.DropTable(
                name: "autresociete");

            migrationBuilder.DropTable(
                name: "etape");

            migrationBuilder.DropTable(
                name: "repas");

            migrationBuilder.DropTable(
                name: "activite");

            migrationBuilder.DropTable(
                name: "descriptioncommande");

            migrationBuilder.DropTable(
                name: "avis");

            migrationBuilder.DropTable(
                name: "route_des_vins");

            migrationBuilder.DropTable(
                name: "cave");

            migrationBuilder.DropTable(
                name: "restaurant");

            migrationBuilder.DropTable(
                name: "commande");

            migrationBuilder.DropTable(
                name: "hebergement");

            migrationBuilder.DropTable(
                name: "sejour");

            migrationBuilder.DropTable(
                name: "typedegustation");

            migrationBuilder.DropTable(
                name: "typecuisine");

            migrationBuilder.DropTable(
                name: "adresse");

            migrationBuilder.DropTable(
                name: "carte_bancaire");

            migrationBuilder.DropTable(
                name: "panier");

            migrationBuilder.DropTable(
                name: "hotel");

            migrationBuilder.DropTable(
                name: "theme");

            migrationBuilder.DropTable(
                name: "categorieeparticipant");

            migrationBuilder.DropTable(
                name: "duree");

            migrationBuilder.DropTable(
                name: "categoriesejour");

            migrationBuilder.DropTable(
                name: "localite");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "codepromo");

            migrationBuilder.DropTable(
                name: "partenaire");

            migrationBuilder.DropTable(
                name: "categorievignoble");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
