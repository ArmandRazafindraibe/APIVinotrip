using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using APIVinotrip.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordResetController : ControllerBase
    {
        private readonly IDataRepository<Client> _dataRepository;
       
        private readonly IConfiguration _config;

        public PasswordResetController(
            IDataRepository<Client> dataRepository,
            // IEmailService emailService,
            IConfiguration config)
        {
            _dataRepository = dataRepository;
            // _emailService = emailService;
            _config = config;
        }

        // Demande de réinitialisation de mot de passe
        [HttpPost("request")]
        [AllowAnonymous]
        public async Task<IActionResult> RequestPasswordReset([FromBody] PasswordResetRequestModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
                return BadRequest("L'adresse email est requise.");

            // Rechercher le client par email
            var clients = await _dataRepository.GetAll();
            var client = clients.Value.FirstOrDefault(c => c.EmailClient.ToUpper() == model.Email.ToUpper());

            if (client == null)
            {
                // Ne pas indiquer que l'email n'existe pas (sécurité)
                return Ok(new { message = "Si cette adresse email existe dans notre système, un email de réinitialisation sera envoyé." });
            }

            // Générer un token unique
            string token = GenerateResetToken();
            DateTime tokenExpiry = DateTime.UtcNow.AddHours(24); // Valide pendant 24 heures

      

            // Envoyer l'email avec le lien de réinitialisation
            string resetLink = $"{_config["AppSettings:FrontendUrl"]}/reset-password?token={token}&email={model.Email}";
            
            // _emailService.SendPasswordResetEmail(model.Email, resetLink);

            // Pour le développement, renvoyer le lien
            if (_config["Environment"] == "Development")
            {
                return Ok(new { 
                    message = "Email de réinitialisation envoyé", 
                    debug_link = resetLink 
                });
            }

            return Ok(new { message = "Si cette adresse email existe dans notre système, un email de réinitialisation sera envoyé." });
        }

        [HttpPost("reset")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] PasswordResetModel model)
        {
            if (string.IsNullOrEmpty(model.Token) || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.NewPassword))
                return BadRequest("Tous les champs sont requis.");

            // Vérifier le format du mot de passe
            if (!IsValidPassword(model.NewPassword))
                return BadRequest("Le format du mot de passe est invalide.");

            // Rechercher le client par email
            var clients = await _dataRepository.GetAll();
            var client = clients.Value.FirstOrDefault(c => c.EmailClient.ToUpper() == model.Email.ToUpper());
            var userToUpdate = await _dataRepository.GetById(client.IdClient);
            if (client == null)
                return NotFound("Client non trouvé.");

            // Vérifier le token et sa validité
            // if (client.ResetToken != model.Token || client.ResetTokenExpiry < DateTime.UtcNow)
            //    return BadRequest("Token invalide ou expiré.");

            // Hacher le nouveau mot de passe avant de l'enregistrer
            client.MdpClient = PasswordHasher.HashPassword(model.NewPassword);

            // Effacer le token
            // client.ResetToken = null;
            // client.ResetTokenExpiry = null;

            await _dataRepository.Update(userToUpdate.Value, client);

            return Ok(new { message = "Mot de passe réinitialisé avec succès." });
        }

        // Générer un token aléatoire
        private string GenerateResetToken()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var tokenData = new byte[32]; // 256 bits
                rng.GetBytes(tokenData);
                return Convert.ToBase64String(tokenData);
            }
        }

        // Vérifier que le mot de passe répond aux exigences de sécurité
        private bool IsValidPassword(string password)
        {
            // Doit contenir au moins une majuscule, une minuscule, un chiffre, un caractère spécial
            // et faire au moins 12 caractères
            var passwordRegex = new System.Text.RegularExpressions.Regex(
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{12,}$");
            
            return passwordRegex.IsMatch(password);
        }
    }

    public class PasswordResetRequestModel
    {
        public string Email { get; set; }
    }

    public class PasswordResetModel
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}