using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Client.Models
{   
	public  class ViewContactRepository : EFRepository<ViewContact>, IViewContactRepository
	{

	}

	public  interface IViewContactRepository : IRepository<ViewContact>
	{

	}
}