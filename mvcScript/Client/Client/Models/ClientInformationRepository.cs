using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Client.Models
{   
	public  class ClientInformationRepository : EFRepository<ClientInformation>, IClientInformationRepository
	{
        public ClientInformation Find(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
    }

	public  interface IClientInformationRepository : IRepository<ClientInformation>
	{

	}
}