using RecklassRekkids.Common.Interfaces;
using RecklassRekkids.DomainRepository;
using RecklassRekkids.DomainRepository.Mappers;

namespace RecklassRekkids.Business
{
	public class ContractManager : IContractManager
	{
		private readonly IRepository _domainRepoistory;
		public ContractManager(IDataProducer dataProducer)
		{
			_domainRepoistory = new Repository(
				dataProducer,
				new ArtistMapper(), 
				new PartnerMapper(), 
				new MusicTitleMapper(), 
				new BusinessContractMapper(), 
				new MusicContractMapper()
			);
		}
	}
}
