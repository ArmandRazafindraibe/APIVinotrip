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
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IDataRepository<Client> _dataRepository;
        private readonly IConfiguration _config;

        private readonly List<Role> _roles = new List<Role>{
            new Role(1, "Client"),
            new Role(2, "Service Vente"),
            new Role(3, "DPO"),
            new Role(4, "Dirigeant")
        };

        public LoginController(IConfiguration config, IDataRepository<Client> dataRepo)
        {
            _config = config;
            _dataRepository = dataRepo;
        }

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

        private async Task<Client> AuthenticateClient(Client loginClient)
        {
            var clients = await _dataRepository.GetAll();
            // Rechercher le client par email uniquement (sans vérifier le mot de passe encore)
            var client = clients.Value.SingleOrDefault(x => x.EmailClient.ToUpper() == loginClient.EmailClient.ToUpper());

            if (client == null)
                return null;

            // Vérifier le mot de passe haché avec BCrypt
            if (!PasswordHasher.VerifyPassword(loginClient.MdpClient, client.MdpClient))
                return null;

            return client;
        }
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