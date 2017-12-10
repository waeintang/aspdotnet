using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Client.Models
{   
	public  class ClientDataRepository : EFRepository<ClientData>, IClientDataRepository
	{
        public ClientData Find(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
    }

	public  interface IClientDataRepository : IRepository<ClientData>
	{

	}
}