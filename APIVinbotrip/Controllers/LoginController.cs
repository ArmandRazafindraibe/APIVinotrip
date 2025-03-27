using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIVinotrip.Controllers
{

     [Route("api/[controller]")]
     [ApiController]
     public class LoginController : ControllerBase
     {
        private readonly IDataRepository<Client> data;
        private readonly IConfiguration _config;
        
        private readonly List<Role> roles = new List<Role>{
            new Role(1,"Client"),
            new Role(2 , "Service Vente"),
            new Role(3 , "DPO"),
            new Role(4,  "Dirigeant")

        };
        
        public LoginController(IConfiguration config, IDataRepository<Client> dataRepo)
         {
           _config = config;
            data = dataRepo;
        }
        
         [HttpPost]
         [AllowAnonymous]
         public IActionResult Login([FromBody] Client login)
         {
             IActionResult response = Unauthorized();
             Client user = AuthenticateClient(login);
             if (user != null)
             {
                 var tokenString = GenerateJwtToken(user);
                 response = Ok(new
                 {
                     token = tokenString,
                     userDetails = user,
                 });
             }
             return response;
         }
         private  Client AuthenticateClient(Client user)
         {
            List<Client> appClients = data.GetAll().Result.Value.ToList();
            
            return appClients.SingleOrDefault(x => x.EmailClient.ToUpper() == user.EmailClient.ToUpper() && x.MdpClient == user.MdpClient);
         }
         private string GenerateJwtToken(Client userInfo)
         {
             var securityKey = new
             SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
             var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
             var claims = new[]
             {
                 new Claim(JwtRegisteredClaimNames.Sub, userInfo.NomClient),
                 new Claim("NomClient", userInfo.NomClient.ToString()),
                 new Claim(ClaimTypes.Role,roles.FirstOrDefault(r => r.IdRole == userInfo.IdRole)?.LibelleRole ?? "Client"),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };
             var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
             );
             return new JwtSecurityTokenHandler().WriteToken(token);
         }
     }
}

        
