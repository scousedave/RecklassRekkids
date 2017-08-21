using System;
using System.Collections.Generic;
using System.Linq;
using RecklassRekkids.Common;
using RecklassRekkids.Common.Interfaces;
using RecklassRekkids.Common.Interfaces.DomainObjects;
using RecklassRekkids.Common.Interfaces.Mappers;

namespace RecklassRekkids.DomainRepository
{
	public class Repository : IRepository
	{

		private Dictionary<string, IArtist> _artists { get; }
		private Dictionary<string, IBusinessContract> _businessContracts { get; }
		private Dictionary<string, List<IMusicContract>> _musicContracts { get; }
		private Dictionary<string, IMusicTitle> _musicTitles { get; }
		private Dictionary<string, IPartner> _partners { get; }

		public Repository(
			IDataProducer dataProducer, 
			IArtistMapper artistMapper,
			IPartnerMapper partnerMapper,
			IMusicTitleMapper musicTitleMapper,
			IBusinessContractMapper businessContractMapper,
			IMusicContractMapper musicContractMapper
		)
		{
			Dictionary<string, Dictionary<string, Dictionary<string, string>>> musicContracts = dataProducer.GetMusicContracts();
			Dictionary<string, string> partnerContracts = dataProducer.GetPartnerContracts();

			_artists = artistMapper.Map(musicContracts.Keys.ToArray());
			_partners = partnerMapper.Map(partnerContracts.Keys.ToArray());

			var titleNames = new List<string>();
			foreach (Dictionary<string, Dictionary<string, string>> titles in musicContracts.Values)
			{
				titleNames.AddRange(titles.Keys.ToArray());
			}
			_musicTitles = musicTitleMapper.Map(titleNames);

			_businessContracts = businessContractMapper.Map(_partners, partnerContracts);

			_musicContracts = musicContractMapper.Map(musicContracts, _artists, _musicTitles);
		}

		public IPartner GetPartnerByName(string name)
		{
			if (_partners.ContainsKey(name)) return _partners[name];
			return null;
		}

		public IMusicContract[] GetMusicContracts(IPartner partner, DateTime date)
		{
			var list = new List<IMusicContract>();
			List<DistributionUse> partnerDistribution = _businessContracts[partner.Name].DistributionUsage;
			foreach (List<IMusicContract> contracts in _musicContracts.Values)
			{
				list.AddRange(from contract in contracts
							  where contract.DistributionUsages
							  .Intersect(partnerDistribution)
							  .Any()
							  where contract.StartDate < date
							  where (!contract.EndDate.HasValue || contract.EndDate > date)
							  select contract
				);
			}
			return list.ToArray();
		}
	}
}
