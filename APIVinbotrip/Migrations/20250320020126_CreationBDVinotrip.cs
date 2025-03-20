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
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "activite",
                schema: "public",
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
                schema: "public",
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
                schema: "public",
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
                schema: "public",
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
                schema: "public",
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
                schema: "public",
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
                schema: "public",
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
                schema: "public",
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
                schema: "public",
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
                schema: "public",
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
                schema: "public",
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
                schema: "public",
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
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "categorievignoble",
                        principalColumn: "idcategorievignoble",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "panier",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "codepromo",
                        principalColumn: "idcodepromo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "autresociete",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "partenaire",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hotel",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "partenaire",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "client",
                schema: "public",
                columns: table => new
                {
                    idclient = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    civiliteclient = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    nomclient = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    prenomclient = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    emailclient = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    mdpclient = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    datenaissanceclient = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    datecreationcompteclient = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    telclient = table.Column<string>(type: "character(12)", fixedLength: true, maxLength: 12, nullable: true),
                    datederniereactiviteclient = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    a2f = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    offrespromotionnellesclient = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
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
                        principalSchema: "public",
                        principalTable: "roles",
                        principalColumn: "idrole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "se_localise",
                schema: "public",
                columns: table => new
                {
                    idroute = table.Column<int>(type: "integer", nullable: false),
                    idcategorievignoble = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_se_localise", x => new { x.idroute, x.idcategorievignoble });
                    table.ForeignKey(
                        name: "fk_se_local_se_locali_categori",
                        column: x => x.idcategorievignoble,
                        principalSchema: "public",
                        principalTable: "categorievignoble",
                        principalColumn: "idcategorievignoble",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_se_local_se_locali_route",
                        column: x => x.idroute,
                        principalSchema: "public",
                        principalTable: "route_des_vins",
                        principalColumn: "idroute",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "restaurant",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "typecuisine",
                        principalColumn: "idtypecuisine",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_restaura_heritage__partenai",
                        column: x => x.idpartenaire,
                        principalSchema: "public",
                        principalTable: "partenaire",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cave",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "typedegustation",
                        principalColumn: "idtypedegustation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cave_heritage__partenai",
                        column: x => x.idpartenaire,
                        principalSchema: "public",
                        principalTable: "partenaire",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sejour",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "categorievignoble",
                        principalColumn: "idcategorievignoble",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_definit_theme",
                        column: x => x.idtheme,
                        principalSchema: "public",
                        principalTable: "theme",
                        principalColumn: "idtheme",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_destine_a_categori",
                        column: x => x.idcategorieparticipant,
                        principalSchema: "public",
                        principalTable: "categorieeparticipant",
                        principalColumn: "idcategorieparticipant",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_dure_duree",
                        column: x => x.idduree,
                        principalSchema: "public",
                        principalTable: "duree",
                        principalColumn: "idduree",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_regroupe_categori",
                        column: x => x.idcategoriesejour,
                        principalSchema: "public",
                        principalTable: "categoriesejour",
                        principalColumn: "idcategoriesejour",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sejour_se_situe_localite",
                        column: x => x.idlocalite,
                        principalSchema: "public",
                        principalTable: "localite",
                        principalColumn: "idlocalite",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hebergement",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "hotel",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "adresse",
                schema: "public",
                columns: table => new
                {
                    idadresse = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idclient = table.Column<int>(type: "integer", nullable: true),
                    idpartenaire = table.Column<int>(type: "integer", nullable: true),
                    nomadressedestination = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    prenomadressedestinataire = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    rueadresse = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    villeadresse = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    paysadresse = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, defaultValueSql: "'France'::character varying"),
                    cpadresse = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    nomadresse = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    numadresse = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adresse", x => x.idadresse);
                    table.ForeignKey(
                        name: "fk_adresse_associati_client",
                        column: x => x.idclient,
                        principalSchema: "public",
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_adresse_localise_partenai",
                        column: x => x.idpartenaire,
                        principalSchema: "public",
                        principalTable: "partenaire",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "carte_bancaire",
                schema: "public",
                columns: table => new
                {
                    idcb = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idclient = table.Column<int>(type: "integer", nullable: true),
                    titulairecb = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
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
                        principalSchema: "public",
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "visite",
                schema: "public",
                columns: table => new
                {
                    idvisite = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idpartenaire = table.Column<int>(type: "integer", nullable: true),
                    descriptionvisite = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    photovisite = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    lienvisite = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_visite", x => x.idvisite);
                    table.ForeignKey(
                        name: "fk_visite_propose_1_cave",
                        column: x => x.idpartenaire,
                        principalSchema: "public",
                        principalTable: "cave",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "avis",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_avis_critique_sejour",
                        column: x => x.idsejour,
                        principalSchema: "public",
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "favoris",
                schema: "public",
                columns: table => new
                {
                    idClient = table.Column<int>(type: "integer", nullable: false),
                    idSejour = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_favoris", x => new { x.idClient, x.idSejour });
                    table.ForeignKey(
                        name: "fk_favoris_favoris2_sejour",
                        column: x => x.idSejour,
                        principalSchema: "public",
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_favoris_favoris_client",
                        column: x => x.idClient,
                        principalSchema: "public",
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "photo",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "descriptionpanier",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "hebergement",
                        principalColumn: "idhebergement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_decrit_pa_panier",
                        column: x => x.idpanier,
                        principalSchema: "public",
                        principalTable: "panier",
                        principalColumn: "idpanier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_decrit_se_sejour",
                        column: x => x.idsejour,
                        principalSchema: "public",
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "etape",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "hebergement",
                        principalColumn: "idhebergement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_etape_possede_sejour",
                        column: x => x.idsejour,
                        principalSchema: "public",
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "estproposepar",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "autresociete",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_propose__propose_5_activite",
                        column: x => x.idactivite,
                        principalSchema: "public",
                        principalTable: "activite",
                        principalColumn: "idactivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_propose__propose_6_adresse",
                        column: x => x.idadresse,
                        principalSchema: "public",
                        principalTable: "adresse",
                        principalColumn: "idadresse",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "commande",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "adresse",
                        principalColumn: "idadresse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associati_adresse2",
                        column: x => x.idadressefacturation,
                        principalSchema: "public",
                        principalTable: "adresse",
                        principalColumn: "idadresse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associati_carte_ba",
                        column: x => x.idcb,
                        principalSchema: "public",
                        principalTable: "carte_bancaire",
                        principalColumn: "idcb",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associati_client",
                        column: x => x.idclientbeneficiaire,
                        principalSchema: "public",
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associati_client2",
                        column: x => x.idclientacheteur,
                        principalSchema: "public",
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_associe_panier",
                        column: x => x.idpanier,
                        principalSchema: "public",
                        principalTable: "panier",
                        principalColumn: "idpanier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commande_diminue_codeprom",
                        column: x => x.idcodepromo,
                        principalSchema: "public",
                        principalTable: "codepromo",
                        principalColumn: "idcodepromo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reponse",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "avis",
                        principalColumn: "idavis",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comporte",
                schema: "public",
                columns: table => new
                {
                    idactivite = table.Column<int>(type: "integer", nullable: false),
                    iddescriptionpanier = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comporte", x => new { x.idactivite, x.iddescriptionpanier });
                    table.ForeignKey(
                        name: "fk_activite_comprise",
                        column: x => x.idactivite,
                        principalSchema: "public",
                        principalTable: "activite",
                        principalColumn: "idactivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_associat_associati_descript",
                        column: x => x.iddescriptionpanier,
                        principalSchema: "public",
                        principalTable: "descriptionpanier",
                        principalColumn: "iddescriptionpanier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "appartient",
                schema: "public",
                columns: table => new
                {
                    idvisite = table.Column<int>(type: "integer", nullable: false),
                    idetape = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appartient", x => new { x.idvisite, x.idetape });
                    table.ForeignKey(
                        name: "fk_appartenace_visite",
                        column: x => x.idvisite,
                        principalSchema: "public",
                        principalTable: "visite",
                        principalColumn: "idvisite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_appartenance_etape",
                        column: x => x.idetape,
                        principalSchema: "public",
                        principalTable: "etape",
                        principalColumn: "idetape",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "constitue",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "activite",
                        principalColumn: "idactivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_appartie_appartien_etape",
                        column: x => x.idetape,
                        principalSchema: "public",
                        principalTable: "etape",
                        principalColumn: "idetape",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "descriptioncommande",
                schema: "public",
                columns: table => new
                {
                    iddescriptioncommande = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idcommande = table.Column<int>(type: "integer", nullable: true),
                    idhebergement = table.Column<int>(type: "integer", nullable: true),
                    idsejour = table.Column<int>(type: "integer", nullable: true),
                    idcb = table.Column<int>(type: "integer", nullable: true),
                    quantite = table.Column<int>(type: "integer", nullable: true),
                    datedebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    datefin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    nbadultes = table.Column<int>(type: "integer", nullable: true),
                    nbenfants = table.Column<int>(type: "integer", nullable: true),
                    nbchambressimple = table.Column<int>(type: "integer", nullable: true),
                    nbchambresdouble = table.Column<int>(type: "integer", nullable: true),
                    nbchambrestriple = table.Column<int>(type: "integer", nullable: true),
                    ecoffret = table.Column<bool>(type: "boolean", nullable: true),
                    offrir = table.Column<bool>(type: "boolean", nullable: true),
                    disponibiliteHebergement = table.Column<bool>(type: "boolean", nullable: true),
                    validationclient = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_descriptioncommande", x => x.iddescriptioncommande);
                    table.ForeignKey(
                        name: "fk_descript_associati_carte_ba",
                        column: x => x.idcb,
                        principalSchema: "public",
                        principalTable: "carte_bancaire",
                        principalColumn: "idcb",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_associati_commande",
                        column: x => x.idcommande,
                        principalSchema: "public",
                        principalTable: "commande",
                        principalColumn: "idcommande",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_associati_hebergem",
                        column: x => x.idhebergement,
                        principalSchema: "public",
                        principalTable: "hebergement",
                        principalColumn: "idhebergement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_descript_associati_sejour",
                        column: x => x.idsejour,
                        principalSchema: "public",
                        principalTable: "sejour",
                        principalColumn: "idsejour",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "possede",
                schema: "public",
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
                        principalSchema: "public",
                        principalTable: "activite",
                        principalColumn: "idactivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_associat_associati_descript",
                        column: x => x.iddescriptioncommande,
                        principalSchema: "public",
                        principalTable: "descriptioncommande",
                        principalColumn: "iddescriptioncommande",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detient",
                schema: "public",
                columns: table => new
                {
                    idRepas = table.Column<int>(type: "integer", nullable: false),
                    idDescriptionPanier = table.Column<int>(type: "integer", nullable: false),
                    DescriptionPanierIdDescriptionPanier = table.Column<int>(type: "integer", nullable: true),
                    RepasIdRepas = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_detient", x => new { x.idRepas, x.idDescriptionPanier });
                    table.ForeignKey(
                        name: "FK_detient_descriptionpanier_DescriptionPanierIdDescriptionPan~",
                        column: x => x.DescriptionPanierIdDescriptionPanier,
                        principalSchema: "public",
                        principalTable: "descriptionpanier",
                        principalColumn: "iddescriptionpanier");
                    table.ForeignKey(
                        name: "fk_associat_associati_descript",
                        column: x => x.idDescriptionPanier,
                        principalSchema: "public",
                        principalTable: "descriptionpanier",
                        principalColumn: "iddescriptionpanier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inclus",
                schema: "public",
                columns: table => new
                {
                    idrepas = table.Column<int>(type: "integer", nullable: false),
                    idetape = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inclus", x => new { x.idrepas, x.idetape });
                    table.ForeignKey(
                        name: "fk_inclusion_etape",
                        column: x => x.idetape,
                        principalSchema: "public",
                        principalTable: "etape",
                        principalColumn: "idetape",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "repas",
                schema: "public",
                columns: table => new
                {
                    idrepas = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idpartenaire = table.Column<int>(type: "integer", nullable: true),
                    descriptionrepas = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    photorepas = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    prixrepas = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    InclusionsIdRepas = table.Column<int>(type: "integer", nullable: true),
                    InclusionsIdEtape = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_repas", x => x.idrepas);
                    table.ForeignKey(
                        name: "FK_repas_inclus_InclusionsIdRepas_InclusionsIdEtape",
                        columns: x => new { x.InclusionsIdRepas, x.InclusionsIdEtape },
                        principalSchema: "public",
                        principalTable: "inclus",
                        principalColumns: new[] { "idrepas", "idetape" });
                    table.ForeignKey(
                        name: "fk_repas_propose_2_restaura",
                        column: x => x.idpartenaire,
                        principalSchema: "public",
                        principalTable: "restaurant",
                        principalColumn: "idpartenaire",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mange1",
                schema: "public",
                columns: table => new
                {
                    idrepas = table.Column<int>(type: "integer", nullable: false),
                    iddescriptioncommande = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contient", x => new { x.idrepas, x.iddescriptioncommande });
                    table.ForeignKey(
                        name: "fk_descriptioncommande_mange1",
                        column: x => x.iddescriptioncommande,
                        principalSchema: "public",
                        principalTable: "descriptioncommande",
                        principalColumn: "iddescriptioncommande",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_repas_mange",
                        column: x => x.idrepas,
                        principalSchema: "public",
                        principalTable: "repas",
                        principalColumn: "idrepas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adresse_idclient",
                schema: "public",
                table: "adresse",
                column: "idclient");

            migrationBuilder.CreateIndex(
                name: "IX_adresse_idpartenaire",
                schema: "public",
                table: "adresse",
                column: "idpartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_appartient_idetape",
                schema: "public",
                table: "appartient",
                column: "idetape");

            migrationBuilder.CreateIndex(
                name: "IX_avis_idclient",
                schema: "public",
                table: "avis",
                column: "idclient");

            migrationBuilder.CreateIndex(
                name: "IX_avis_idsejour",
                schema: "public",
                table: "avis",
                column: "idsejour");

            migrationBuilder.CreateIndex(
                name: "IX_carte_bancaire_idclient",
                schema: "public",
                table: "carte_bancaire",
                column: "idclient");

            migrationBuilder.CreateIndex(
                name: "IX_cave_idtypedegustation",
                schema: "public",
                table: "cave",
                column: "idtypedegustation");

            migrationBuilder.CreateIndex(
                name: "IX_client_idrole",
                schema: "public",
                table: "client",
                column: "idrole");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idadressefacturation",
                schema: "public",
                table: "commande",
                column: "idadressefacturation");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idadresselivraison",
                schema: "public",
                table: "commande",
                column: "idadresselivraison");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idcb",
                schema: "public",
                table: "commande",
                column: "idcb");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idclientacheteur",
                schema: "public",
                table: "commande",
                column: "idclientacheteur");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idclientbeneficiaire",
                schema: "public",
                table: "commande",
                column: "idclientbeneficiaire");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idcodepromo",
                schema: "public",
                table: "commande",
                column: "idcodepromo");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idpanier",
                schema: "public",
                table: "commande",
                column: "idpanier");

            migrationBuilder.CreateIndex(
                name: "IX_comporte_iddescriptionpanier",
                schema: "public",
                table: "comporte",
                column: "iddescriptionpanier");

            migrationBuilder.CreateIndex(
                name: "IX_constitue_idetape",
                schema: "public",
                table: "constitue",
                column: "idetape");

            migrationBuilder.CreateIndex(
                name: "IX_descriptioncommande_idcb",
                schema: "public",
                table: "descriptioncommande",
                column: "idcb");

            migrationBuilder.CreateIndex(
                name: "IX_descriptioncommande_idcommande",
                schema: "public",
                table: "descriptioncommande",
                column: "idcommande");

            migrationBuilder.CreateIndex(
                name: "IX_descriptioncommande_idhebergement",
                schema: "public",
                table: "descriptioncommande",
                column: "idhebergement");

            migrationBuilder.CreateIndex(
                name: "IX_descriptioncommande_idsejour",
                schema: "public",
                table: "descriptioncommande",
                column: "idsejour");

            migrationBuilder.CreateIndex(
                name: "IX_descriptionpanier_idhebergement",
                schema: "public",
                table: "descriptionpanier",
                column: "idhebergement");

            migrationBuilder.CreateIndex(
                name: "IX_descriptionpanier_idpanier",
                schema: "public",
                table: "descriptionpanier",
                column: "idpanier");

            migrationBuilder.CreateIndex(
                name: "IX_descriptionpanier_idsejour",
                schema: "public",
                table: "descriptionpanier",
                column: "idsejour");

            migrationBuilder.CreateIndex(
                name: "IX_detient_DescriptionPanierIdDescriptionPanier",
                schema: "public",
                table: "detient",
                column: "DescriptionPanierIdDescriptionPanier");

            migrationBuilder.CreateIndex(
                name: "IX_detient_idDescriptionPanier",
                schema: "public",
                table: "detient",
                column: "idDescriptionPanier");

            migrationBuilder.CreateIndex(
                name: "IX_detient_RepasIdRepas",
                schema: "public",
                table: "detient",
                column: "RepasIdRepas");

            migrationBuilder.CreateIndex(
                name: "IX_estproposepar_idactivite",
                schema: "public",
                table: "estproposepar",
                column: "idactivite");

            migrationBuilder.CreateIndex(
                name: "IX_estproposepar_idadresse",
                schema: "public",
                table: "estproposepar",
                column: "idadresse");

            migrationBuilder.CreateIndex(
                name: "IX_etape_idhebergement",
                schema: "public",
                table: "etape",
                column: "idhebergement");

            migrationBuilder.CreateIndex(
                name: "IX_etape_idsejour",
                schema: "public",
                table: "etape",
                column: "idsejour");

            migrationBuilder.CreateIndex(
                name: "IX_favoris_idSejour",
                schema: "public",
                table: "favoris",
                column: "idSejour");

            migrationBuilder.CreateIndex(
                name: "IX_hebergement_idpartenaire",
                schema: "public",
                table: "hebergement",
                column: "idpartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_inclus_idetape",
                schema: "public",
                table: "inclus",
                column: "idetape");

            migrationBuilder.CreateIndex(
                name: "IX_localite_idcategorievignoble",
                schema: "public",
                table: "localite",
                column: "idcategorievignoble");

            migrationBuilder.CreateIndex(
                name: "IX_mange1_iddescriptioncommande",
                schema: "public",
                table: "mange1",
                column: "iddescriptioncommande");

            migrationBuilder.CreateIndex(
                name: "IX_panier_idcodepromo",
                schema: "public",
                table: "panier",
                column: "idcodepromo");

            migrationBuilder.CreateIndex(
                name: "IX_photo_idsejour",
                schema: "public",
                table: "photo",
                column: "idsejour");

            migrationBuilder.CreateIndex(
                name: "IX_possede_iddescriptioncommande",
                schema: "public",
                table: "possede",
                column: "iddescriptioncommande");

            migrationBuilder.CreateIndex(
                name: "IX_repas_idpartenaire",
                schema: "public",
                table: "repas",
                column: "idpartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_repas_InclusionsIdRepas_InclusionsIdEtape",
                schema: "public",
                table: "repas",
                columns: new[] { "InclusionsIdRepas", "InclusionsIdEtape" });

            migrationBuilder.CreateIndex(
                name: "IX_reponse_idavis",
                schema: "public",
                table: "reponse",
                column: "idavis");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_idtypecuisine",
                schema: "public",
                table: "restaurant",
                column: "idtypecuisine");

            migrationBuilder.CreateIndex(
                name: "IX_se_localise_idcategorievignoble",
                schema: "public",
                table: "se_localise",
                column: "idcategorievignoble");

            migrationBuilder.CreateIndex(
                name: "IX_sejour_idcategorieparticipant",
                schema: "public",
                table: "sejour",
                column: "idcategorieparticipant");

            migrationBuilder.CreateIndex(
                name: "IX_sejour_idcategoriesejour",
                schema: "public",
                table: "sejour",
                column: "idcategoriesejour");

            migrationBuilder.CreateIndex(
                name: "IX_sejour_idcategorievignoble",
                schema: "public",
                table: "sejour",
                column: "idcategorievignoble");

            migrationBuilder.CreateIndex(
                name: "IX_sejour_idduree",
                schema: "public",
                table: "sejour",
                column: "idduree");

            migrationBuilder.CreateIndex(
                name: "IX_sejour_idlocalite",
                schema: "public",
                table: "sejour",
                column: "idlocalite");

            migrationBuilder.CreateIndex(
                name: "IX_sejour_idtheme",
                schema: "public",
                table: "sejour",
                column: "idtheme");

            migrationBuilder.CreateIndex(
                name: "IX_visite_idpartenaire",
                schema: "public",
                table: "visite",
                column: "idpartenaire");

            migrationBuilder.AddForeignKey(
                name: "FK_detient_repas_RepasIdRepas",
                schema: "public",
                table: "detient",
                column: "RepasIdRepas",
                principalSchema: "public",
                principalTable: "repas",
                principalColumn: "idrepas");

            migrationBuilder.AddForeignKey(
                name: "fk_associat_associati_repas",
                schema: "public",
                table: "detient",
                column: "idRepas",
                principalSchema: "public",
                principalTable: "repas",
                principalColumn: "idrepas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_inclus_repas",
                schema: "public",
                table: "inclus",
                column: "idrepas",
                principalSchema: "public",
                principalTable: "repas",
                principalColumn: "idrepas",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_hotel_heritage__partenai",
                schema: "public",
                table: "hotel");

            migrationBuilder.DropForeignKey(
                name: "fk_restaura_heritage__partenai",
                schema: "public",
                table: "restaurant");

            migrationBuilder.DropForeignKey(
                name: "fk_inclusion_etape",
                schema: "public",
                table: "inclus");

            migrationBuilder.DropForeignKey(
                name: "fk_inclus_repas",
                schema: "public",
                table: "inclus");

            migrationBuilder.DropTable(
                name: "appartient",
                schema: "public");

            migrationBuilder.DropTable(
                name: "comporte",
                schema: "public");

            migrationBuilder.DropTable(
                name: "constitue",
                schema: "public");

            migrationBuilder.DropTable(
                name: "detient",
                schema: "public");

            migrationBuilder.DropTable(
                name: "estproposepar",
                schema: "public");

            migrationBuilder.DropTable(
                name: "favoris",
                schema: "public");

            migrationBuilder.DropTable(
                name: "mange1",
                schema: "public");

            migrationBuilder.DropTable(
                name: "photo",
                schema: "public");

            migrationBuilder.DropTable(
                name: "possede",
                schema: "public");

            migrationBuilder.DropTable(
                name: "reponse",
                schema: "public");

            migrationBuilder.DropTable(
                name: "se_localise",
                schema: "public");

            migrationBuilder.DropTable(
                name: "visite",
                schema: "public");

            migrationBuilder.DropTable(
                name: "descriptionpanier",
                schema: "public");

            migrationBuilder.DropTable(
                name: "autresociete",
                schema: "public");

            migrationBuilder.DropTable(
                name: "activite",
                schema: "public");

            migrationBuilder.DropTable(
                name: "descriptioncommande",
                schema: "public");

            migrationBuilder.DropTable(
                name: "avis",
                schema: "public");

            migrationBuilder.DropTable(
                name: "route_des_vins",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cave",
                schema: "public");

            migrationBuilder.DropTable(
                name: "commande",
                schema: "public");

            migrationBuilder.DropTable(
                name: "typedegustation",
                schema: "public");

            migrationBuilder.DropTable(
                name: "adresse",
                schema: "public");

            migrationBuilder.DropTable(
                name: "carte_bancaire",
                schema: "public");

            migrationBuilder.DropTable(
                name: "panier",
                schema: "public");

            migrationBuilder.DropTable(
                name: "client",
                schema: "public");

            migrationBuilder.DropTable(
                name: "codepromo",
                schema: "public");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "partenaire",
                schema: "public");

            migrationBuilder.DropTable(
                name: "etape",
                schema: "public");

            migrationBuilder.DropTable(
                name: "hebergement",
                schema: "public");

            migrationBuilder.DropTable(
                name: "sejour",
                schema: "public");

            migrationBuilder.DropTable(
                name: "hotel",
                schema: "public");

            migrationBuilder.DropTable(
                name: "theme",
                schema: "public");

            migrationBuilder.DropTable(
                name: "categorieeparticipant",
                schema: "public");

            migrationBuilder.DropTable(
                name: "duree",
                schema: "public");

            migrationBuilder.DropTable(
                name: "categoriesejour",
                schema: "public");

            migrationBuilder.DropTable(
                name: "localite",
                schema: "public");

            migrationBuilder.DropTable(
                name: "categorievignoble",
                schema: "public");

            migrationBuilder.DropTable(
                name: "repas",
                schema: "public");

            migrationBuilder.DropTable(
                name: "inclus",
                schema: "public");

            migrationBuilder.DropTable(
                name: "restaurant",
                schema: "public");

            migrationBuilder.DropTable(
                name: "typecuisine",
                schema: "public");
        }
    }
}
