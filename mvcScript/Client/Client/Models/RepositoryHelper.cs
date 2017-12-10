namespace Client.Models
{
	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}		
		
		public static ClientContactRepository GetClientContactRepository()
		{
			var repository = new ClientContactRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ClientContactRepository GetClientContactRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ClientContactRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ClientDataRepository GetClientDataRepository()
		{
			var repository = new ClientDataRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ClientDataRepository GetClientDataRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ClientDataRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ClientInformationRepository GetClientInformationRepository()
		{
			var repository = new ClientInformationRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ClientInformationRepository GetClientInformationRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ClientInformationRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ViewContactRepository GetViewContactRepository()
		{
			var repository = new ViewContactRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ViewContactRepository GetViewContactRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ViewContactRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		
	}
}