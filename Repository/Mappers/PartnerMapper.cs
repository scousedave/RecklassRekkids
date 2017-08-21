using System.Collections.Generic;
using RecklassRekkids.Common.Interfaces.DomainObjects;
using RecklassRekkids.Common.Interfaces.Mappers;
using RecklassRekkids.DomainRepository.DomainObjects;

namespace RecklassRekkids.DomainRepository.Mappers
{
	public class PartnerMapper : IPartnerMapper
	{
		public Dictionary<string, IPartner> Map(IEnumerable<string> partnerNames)
		{
			var partners = new Dictionary<string, IPartner>();
			foreach (string name in partnerNames)
			{
				if (!string.IsNullOrWhiteSpace(name) && !partners.ContainsKey(name))
				{
					partners.Add(name, new Partner(name));
				}
			}
			return partners;
		}
	}
}
