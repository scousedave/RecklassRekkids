using System;
using RecklassRekkids.Common;
using RecklassRekkids.Common.Interfaces;
using RecklassRekkids.Common.Interfaces.DomainObjects;
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

		public IPartner GetPartner(string partnerName)
		{
			return _domainRepoistory.GetPartnerByName(partnerName);
		}

		public IMusicContract[] GetAllowedMusicTitles(IPartner partner, DateTime startDate)
		{
			return _domainRepoistory.GetMusicContracts(partner, startDate);
		}

		public IMusicContract[] GetAllowedMusicTitles(string partnerName, string startDate)
		{
			var partner = GetPartner(partnerName);
			if (partner != null)
			{
				if (startDate.TryParseFromAnyDate(out DateTime parsedDate))
				{
					return _domainRepoistory.GetMusicContracts(partner, parsedDate);
				}
			}

			return new IMusicContract[0];
		}

	}
}
