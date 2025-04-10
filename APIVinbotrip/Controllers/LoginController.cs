using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APIVinotrip.Helpers;

namespace APIVinotrip.Controllers
{
    /// <summary>
    /// Contrôleur permettant de gérer l'authentification des utilisateurs
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Interface du repository pour accéder aux données des clients
        /// </summary>
        private readonly IDataRepository<Client> _dataRepository;

        /// <summary>
        /// Configuration de l'application pour accéder aux paramètres JWT
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// Liste des rôles disponibles dans l'application
        /// </summary>
        private readonly List<Role> _roles = new List<Role>{
            new Role(1, "Client"),
            new Role(2, "Service Vente"),
            new Role(3, "DPO"),
            new Role(4, "Dirigeant")
        };

        /// <summary>
        /// Constructeur du contrôleur LoginController
        /// </summary>
        /// <param name="config">Configuration de l'application</param>
        /// <param name="dataRepo">Repository d'accès aux données clients</param>
        public LoginController(IConfiguration config, IDataRepository<Client> dataRepo)
        {
            _config = config;
            _dataRepository = dataRepo;
        }

        /// <summary>
        /// Authentifie un client et génère un token JWT
        /// </summary>
        /// <param name="loginClient">Informations d'identification du client (email/téléphone et mot de passe)</param>
        /// <returns>Un token JWT et les détails de l'utilisateur si l'authentification réussit, ou Unauthorized si échec</returns>
        /// <remarks>Cette méthode est accessible sans authentification préalable</remarks>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] Client loginClient)
        {
            IActionResult response = Unauthorized();
            Client user = await AuthenticateClient(loginClient);
            if (user != null)
            {
                var tokenString = GenerateJwtToken(user);
                // Ne pas renvoyer le mot de passe dans la réponse
                user.MdpClient = null;
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }
            return response;
        }

        /// <summary>
        /// Authentifie un client en vérifiant ses identifiants
        /// </summary>
        /// <param name="loginClient">Informations d'identification du client</param>
        /// <returns>L'objet Client si l'authentification réussit, null sinon</returns>
        private async Task<Client> AuthenticateClient(Client loginClient)
        {
            var clients = await _dataRepository.GetAll();
            // Vérifier si les propriétés sont null avant d'appeler ToUpper()
            // et utiliser des vérifications de null sécurisées
            var client = clients.Value.SingleOrDefault(x =>
                (!string.IsNullOrEmpty(x.EmailClient) && !string.IsNullOrEmpty(loginClient.EmailClient) &&
                 x.EmailClient.ToUpper() == loginClient.EmailClient.ToUpper()) ||
                (x.TelClient == loginClient.TelClient && loginClient.TelClient != null));
            if (client == null)
                return null;
            if (!PasswordHasher.VerifyPassword(loginClient.MdpClient, client.MdpClient))
                return null;
            return client;
        }

        /// <summary>
        /// Génère un token JWT pour un client authentifié
        /// </summary>
        /// <param name="userInfo">Informations du client pour lequel générer le token</param>
        /// <returns>Token JWT sous forme de chaîne de caractères</returns>
        private string GenerateJwtToken(Client userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.IdClient.ToString()),
                new Claim("IdClient", userInfo.IdClient.ToString()),
                new Claim("NomClient", userInfo.NomClient),
                new Claim("EmailClient", userInfo.EmailClient),
                new Claim(ClaimTypes.Role, _roles.FirstOrDefault(r => r.IdRole == userInfo.IdRole)?.LibelleRole ?? "Client"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120), // Durée de validité du token: 2 heures
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}