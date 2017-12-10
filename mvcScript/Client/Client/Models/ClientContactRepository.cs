using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Client.Models
{   
	public  class ClientContactRepository : EFRepository<ClientContact>, IClientContactRepository
	{
        public ClientContact Find(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
    }

	public  interface IClientContactRepository : IRepository<ClientContact>
	{

	}
}