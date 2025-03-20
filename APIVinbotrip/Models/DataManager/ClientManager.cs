using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class ClientManager:IDataRepository<Client>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public ClientManager() { }
        public ClientManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            return vinotripDBContext.Clients.ToList();
        }
        public  async Task<ActionResult<Client>> GetById(int id)
        {
            return  vinotripDBContext.Clients.FirstOrDefault(u => u.IdClient == id);
        }
        public  async Task<ActionResult<Client>> GetByString(string mail)
        {
            return  vinotripDBContext.Clients.FirstOrDefault(u => u.EmailClient.ToUpper() == mail.ToUpper());
        }
        public  async Task Add(Client entity)
        {
             vinotripDBContext.Clients.Add(entity);
             vinotripDBContext.SaveChanges();
        }
        public  async Task Update(Client client, Client entity)
        {
            vinotripDBContext.Entry(client).State = EntityState.Modified;
            client.IdClient = entity.IdClient;
            client.NomClient = entity.NomClient;
            client.PrenomClient = entity.PrenomClient;
            client.EmailClient = entity.EmailClient;
            client.MdpClient = entity.MdpClient;
            client.DateNaissanceClient = entity.DateNaissanceClient;
            client.TelClient = entity.TelClient;
            client.DateDerniereActiviteClient = entity.DateDerniereActiviteClient;
            client.A2f = entity.A2f;
            client.IdRole = entity.IdRole;
            client.TokenResetMDP = entity.TokenResetMDP;
            client.DateCreationToken = entity.DateCreationToken;
             vinotripDBContext.SaveChanges();
        }
        public  async Task Delete(Client client)
        {
            vinotripDBContext.Clients.Remove(client);
             vinotripDBContext.SaveChanges();
        }
    }
}
