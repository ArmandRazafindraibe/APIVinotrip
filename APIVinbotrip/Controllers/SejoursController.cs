using Microsoft.AspNetCore.Mvc;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Authorization;

namespace APIVinotrip.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SejourController : ControllerBase
    {
        private readonly ISejourRepository _sejourRepository;
        private readonly IHebergementRepository _hebergementRepository;
        private readonly IEtapeRepository _etapeRepository;
        private readonly ICategorieRepository _categorieRepository;
        private readonly ILocaliteRepository _localiteRepository;
        private readonly IDureeRepository _dureeRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IDescriptionCommandeRepository _descriptionCommandeRepository;
        

        public SejourController(
            ISejourRepository sejourRepository,
            IHebergementRepository hebergementRepository,
            IEtapeRepository etapeRepository,
            ICategorieRepository categorieRepository,
            ILocaliteRepository localiteRepository,
            IDureeRepository dureeRepository,
            IPhotoRepository photoRepository,
            IDescriptionCommandeRepository descriptionCommandeRepository
           )
        {
            _sejourRepository = sejourRepository;
            _hebergementRepository = hebergementRepository;
            _etapeRepository = etapeRepository;
            _categorieRepository = categorieRepository;
            _localiteRepository = localiteRepository;
            _dureeRepository = dureeRepository;
            _photoRepository = photoRepository;
            _descriptionCommandeRepository = descriptionCommandeRepository;
      
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sejour>>> GetSejours()
        {
            var result = await _sejourRepository.GetAllPublishedAsync();
            var categories = await _categorieRepository.GetAllCategorieSejourAsync();
            var categoryParticipants = await _categorieRepository.GetAllCategorieParticipantAsync();
            var vignobles = await _categorieRepository.GetAllCategorieVignobleAsync();
            var localites = await _localiteRepository.GetAllAsync();
            var durees = await _dureeRepository.GetAllAsync();

            return Ok(new
            {
                sejours = result,
                categoriesejour = categories,
                categorieparticipant = categoryParticipants,
                categoriesvignoble = vignobles,
                localites = localites,
                durees = durees
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sejour>> GetSejour(int id)
        {
            var sejour = await _sejourRepository.GetByIdAsync(id);

            if (sejour == null || (!sejour.Publie && !User.IsInRole(Policies.ServiceVente) && !User.IsInRole(Policies.Dirigeant)))
            {
                return NotFound();
            }

            // History management would typically be handled by client-side
            // For API usage, we don't manipulate cookies in the same way

            var hebergements = await _hebergementRepository.GetAllAsync();
            var visites = await _hebergementRepository.GetAllVisitesAsync();
            var hotels = await _hebergementRepository.GetAllHotelsAsync();
            var caves = await _hebergementRepository.GetAllCavesAsync();

            // Get related sejours
            var sejoursAimes = await _sejourRepository.GetRelatedSejoursAsync(
                sejour.Idcategorievignoble,
                sejour.Idcategoriesejour,
                sejour.Idsejour,
                4);

            return Ok(new
            {
                sejour,
                hebergement = hebergements,
                visite = visites,
                hotel = hotels,
                cave = caves,
                sejouraime = sejoursAimes
            });
        }

        [HttpGet("edit/{id}")]
        [Authorize(Roles = "ServiceVente,Dirigeant")]
        public async Task<ActionResult<Sejour>> EditSejour(int id)
        {
            var sejour = await _sejourRepository.GetByIdAsync(id);

            if (sejour == null)
            {
                return NotFound();
            }

            var hebergements = await _hebergementRepository.GetAllAsync();
            var visites = await _hebergementRepository.GetAllVisitesAsync();
            var hotels = await _hebergementRepository.GetAllHotelsAsync();
            var caves = await _hebergementRepository.GetAllCavesAsync();

            return Ok(new
            {
                sejour,
                hebergement = hebergements,
                visite = visites,
                hotel = hotels,
                cave = caves,
                editing = true
            });
        }

        [HttpPost("hebergement/{idSejour}/{idEtape}")]
        [Authorize(Roles = "ServiceVente,Dirigeant")]
        public async Task<ActionResult> UpdateHebergement(int idSejour, int idEtape, [FromBody] HebergementUpdateDto model)
        {
            var sejour = await _sejourRepository.GetByIdAsync(idSejour);
            var etape = await _etapeRepository.GetByIdAndSejourAsync(idEtape, idSejour);

            int newIdHebergement = model.NewIdHebergement;

            if (sejour == null || etape == null || newIdHebergement <= 0)
            {
                return BadRequest();
            }

            if (model.IdDescriptionCommande.HasValue)
            {
                var descriptionCommande = await _descriptionCommandeRepository.GetByIdAsync(model.IdDescriptionCommande.Value);

                if (descriptionCommande != null)
                {
                    string titreHotelAncien = descriptionCommande.Hebergement.Hotel.NomPartenaire;

                    await _descriptionCommandeRepository.UpdateHebergementAsync(
                        model.IdDescriptionCommande.Value,
                        newIdHebergement,
                        false);

                    var hebergement = await _hebergementRepository.GetByIdWithHotelAsync(newIdHebergement);
                    string titreHotelNouveau = hebergement.HebergementHotel.NomPartenaire;


                    return Ok(new { redirectTo = "reservation" });
                }
            }
            else
            {
                await _etapeRepository.UpdateHebergementAsync(idEtape, newIdHebergement);
                return Ok(new { redirectTo = $"sejour/edit/{idSejour}" });
            }

            return BadRequest();
        }

        [HttpGet("choix-hebergement/{idSejour}/{idEtape}")]
        [Authorize(Roles = "ServiceVente,Dirigeant")]
        public async Task<ActionResult> ChoixHebergement(int idSejour, int idEtape, [FromQuery] int? idDescriptionCommande, [FromQuery] int idHebergement)
        {
            var sejour = await _sejourRepository.GetByIdAsync(idSejour);
            var etape = await _etapeRepository.GetByIdAndSejourAsync(idEtape, idSejour);

            if (idHebergement <= 0 || sejour == null || etape == null ||
                (idDescriptionCommande.HasValue && await _descriptionCommandeRepository.GetByIdAndEtapeAsync(idDescriptionCommande.Value, idEtape) == null))
            {
                return BadRequest();
            }

            var hebergements = await _hebergementRepository.GetAllAsync();

            return Ok(new
            {
                sejour,
                etape,
                hebergements,
                idDescriptionCommande,
                idHebergement
            });
        }

        [HttpGet("create")]
        [Authorize(Roles = "Dirigeant")]
        public async Task<ActionResult> CreateView()
        {
            var placeholder = await _sejourRepository.GetRandomAsync();
            var hebergements = await _hebergementRepository.GetAllAsync();
            var categoriesParticipant = await _categorieRepository.GetAllCategorieParticipantAsync();
            var categoriesSejour = await _categorieRepository.GetAllCategorieSejourAsync();
            var themes = await _categorieRepository.GetAllThemesAsync();
            var durees = await _dureeRepository.GetAllAsync();
            var vignobles = await _categorieRepository.GetAllCategorieVignobleAsync();
            var localites = await _localiteRepository.GetAllAsync();

            return Ok(new
            {
                placeholder,
                hebergements,
                categoriesParticipant,
                categoriesSejour,
                themes,
                durees,
                vignobles,
                localites
            });
        }

        [HttpPost]
        [Authorize(Roles = "Dirigeant")]
        public async Task<ActionResult<Sejour>> Create([FromForm] SejourCreateDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var localites = await _localiteRepository.GetByVignobleAsync(model.Vignoble);

            if (model.Localite != null && model.Localite != "null" &&
                !localites.Any(l => l.IdLocalite.ToString() == model.Localite))
            {
                return BadRequest("Invalid localite selection");
            }

            // Create the sejour
            var sejour = new Sejour
            {
                Titresejour = model.Titre ?? "",
                Photosejour = "",
                Descriptionsejour = model.Description ?? "",
                Idcategoriesejour = model.CategorieSejour,
                Idduree = model.Duree,
                Idtheme = model.Theme,
                Idcategorievignoble = model.Vignoble,
                Idcategorieparticipant = model.CategorieParticipant,
                Idlocalite = model.Localite == "null" ? null : int.Parse(model.Localite),
                Prixsejour = model.Price ?? 0,
                Publie = false
            };

            await _sejourRepository.AddAsync(sejour);

            // Upload photo if provided
            if (model.Photo != null)
            {
                string extension = Path.GetExtension(model.Photo.FileName);
                string filename = $"sejour{sejour.Idsejour}{extension}";

                bool uploadSuccess = await _fileService.UploadAsync(model.Photo, filename, "sejour");

                if (uploadSuccess)
                {
                    sejour.Photosejour = filename;
                    await _sejourRepository.UpdateAsync(sejour);
                }
                else
                {
                    return BadRequest(new { photo = "Une erreur s'est produite lors de l'upload." });
                }
            }

            // Create etapes
            if (model.Etapes != null)
            {
                for (int i = 0; i < model.Etapes.Count; i++)
                {
                    var etapeModel = model.Etapes[i];

                    var etape = new Etape
                    {
                        IdHebergement = etapeModel.Hebergement,
                        IdSejour = sejour.Idsejour,
                        TitreEtape = etapeModel.Titre,
                        DescriptionEtape = etapeModel.Description,
                        PhotoEtape = "",
                        URLEtape = "",
                        VideoEtape = ""
                    };

                    await _etapeRepository.AddAsync(etape);

                    // Upload etape image
                    if (etapeModel.Image != null)
                    {
                        string extension = Path.GetExtension(etapeModel.Image.FileName);
                        string filename = $"etape{etape.IdEtape}{extension}";

                        //bool uploadSuccess = await _fileService.UploadAsync(etapeModel.Image, filename, "etape");

                        //if (uploadSuccess)
                        //{
                        //    etape.PhotoEtape = filename;
                        //    await _etapeRepository.UpdateAsync(etape);
                        //}
                        //else
                        //{
                        //    return BadRequest(new { [`etapes[${ i}].image`] = "Une erreur s'est produite lors de l'upload." });

                        //}

                        return CreatedAtAction(nameof(GetSejour), new { id = sejour.Idsejour }, sejour);
                    }
                }
            }
        }

        [HttpPost("update-photo/{id}")]
        [Authorize(Roles = "ServiceVente,Dirigeant")]
        public async Task<ActionResult> UpdatePhoto(int id, IFormFile photoUpload)
        {
            if (photoUpload == null)
            {
                return BadRequest(new { photoUpload = "La photo est requise." });
            }

            var sejour = await _sejourRepository.GetByIdAsync(id);
            if (sejour == null)
            {
                return NotFound();
            }

            var photo = new Photo
            {
                IdSejour = sejour.Idsejour,
                IdPhoto = 0
            };

            await _photoRepository.AddAsync(photo);

            string extension = Path.GetExtension(photoUpload.FileName);
            string filename = $"sejour{sejour.Idsejour}-{photo.IdPhoto}{extension}";

            bool uploadSuccess = await _fileService.UploadAsync(photoUpload, filename, "sejour");

            if (uploadSuccess)
            {
                photo.NomPhoto = filename;
                await _photoRepository.UpdateAsync(photo);
                return Ok(photo);
            }

            await _photoRepository.DeleteAsync(photo.IdPhoto);
            return BadRequest(new { photoUpload = "Une erreur s'est produite lors de l'upload." });
        }

        [HttpDelete("remove-photo/{idSejour}/{idPhoto}")]
        [Authorize(Roles = "ServiceVente,Dirigeant")]
        public async Task<ActionResult> RemovePhoto(int idSejour, int idPhoto)
        {
            var photo = await _photoRepository.GetByIdAndSejourAsync(idPhoto, idSejour);

            //if (photo != null)
            //{
            //    await _photoRepository.DeleteAsync(idPhoto);
            //    await _fileService.DeleteAsync(photo.PhotoName, "sejour");
            //}

            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ServiceVente,Dirigeant")]
        public async Task<ActionResult> Update(int id, [FromBody] SejourUpdateDto model)
        {
            var sejour = await _sejourRepository.GetByIdAsync(id);

            if (sejour == null)
            {
                return NotFound();
            }

            sejour.Titresejour = model.Titre ?? sejour.Titresejour;
            sejour.Descriptionsejour = model.Description ?? sejour.Descriptionsejour;
            sejour.Prixsejour = model.Prix ?? sejour.Prixsejour;

            await _sejourRepository.UpdateAsync(sejour);

            return Ok(sejour);
        }

        [HttpGet("validate")]
        [Authorize(Roles = "Dirigeant,ServiceVente")]
        public async Task<ActionResult> GetUnpublishedSejours()
        {
            var unpublishedSejours = await _sejourRepository.GetAllUnpublishedAsync();
            return Ok(new { sejours = unpublishedSejours });
        }

        [HttpPost("publier/{id}")]
        [Authorize(Roles = "Dirigeant")]
        public async Task<ActionResult> Publier(int id)
        {
            var sejour = await _sejourRepository.GetByIdAsync(id);

            if (sejour == null)
            {
                return NotFound();
            }

            sejour.Publie = true;
            await _sejourRepository.UpdateAsync(sejour);

            return Ok();
        }

        [HttpPost("discount/{id}")]
        [Authorize(Roles = "ServiceVente,Dirigeant")]
        public async Task<ActionResult> ApplyDiscount(int id, [FromBody] DiscountDto model)
        {
            var sejour = await _sejourRepository.GetByIdAsync(id);

            if (sejour == null)
            {
                return NotFound();
            }

            if (model.NouveauPrixSejour == sejour.Prixsejour)
            {
                sejour.Nouveauprixsejour = 0;
            }
            else
            {
                sejour.Nouveauprixsejour = model.NouveauPrixSejour;
            }

            await _sejourRepository.UpdateAsync(sejour);

            return Ok(sejour);
        }

        [HttpGet("editing")]
        [Authorize(Roles = "ServiceVente")]
        public async Task<ActionResult> GetUnpublishedSejoursForEditing()
        {
            var unpublishedSejours = await _sejourRepository.GetAllUnpublishedAsync();
            return Ok(new { sejours = unpublishedSejours });
        }

        [HttpPost("mail-possibilite/{id}")]
        public async Task<ActionResult> SendPossibiliteEmails(int id)
        {
            var sejour = await _sejourRepository.GetByIdWithEtapesAsync(id);

            if (sejour == null)
            {
                return NotFound();
            }

            //foreach (var etape in sejour.Etapes)
            //{
            //    var hotel = await _hebergementRepository.GetHotelByHebergementIdAsync(etape.IdHebergement);
            //    await _emailService.SendPossibiliteHebergementEmailAsync(
            //        "ppartenairehotel@gmail.com",
            //        hotel.NomPartenaire);
            //}

            return Ok(new { message = "Les hébergements ont bien été contactés." });
        }
    }
}
