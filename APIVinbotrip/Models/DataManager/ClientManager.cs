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
        public ActionResult<IEnumerable<Client>> GetAll()
        {
            return vinotripDBContext.Clients.ToList();
        }
        public async Task<ActionResult<Client>> GetByIdAsync(int id)
        {
            return await vinotripDBContext.Clients.FirstOrDefaultAsync(u => u.IdClient == id);
        }
        public async Task<ActionResult<Client>> GetByStringAsync(string mail)
        {
            return await vinotripDBContext.Clients.FirstOrDefaultAsync(u => u.EmailClient.ToUpper() == mail.ToUpper());
        }
        public async Task AddAsync(Client entity)
        {
            await vinotripDBContext.Clients.AddAsync(entity);
            await vinotripDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Client client, Client entity)
        {
            vinotripDBContext.Entry(client).State = EntityState.Modified;
            client.IdClient = entity.IdClient;
            client.NomClient = entity.NomClient;
            client.PrenomClient = entity.PrenomClient;
            client.EmailClient = entity.EmailClient;
            client.MdpClient = entity.MdpClient;
            client.DateNaissanceClient = entity.DateNaissanceClient;
            client.DateCreationCompteClient = entity.DateCreationCompteClient;
            client.TelClient = entity.TelClient;
            client.DateDerniereActiviteClient = entity.DateDerniereActiviteClient;
            client.A2f = entity.A2f;
            client.IdRole = entity.IdRole;
            client.BloquingClient = entity.BloquingClient;
            client.TokenResetMDP = entity.TokenResetMDP;
            client.DateCreationToken = entity.DateCreationToken;
            await vinotripDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Client client)
        {
            vinotripDBContext.Clients.Remove(client);
            await vinotripDBContext.SaveChangesAsync();
        }
    }
}
