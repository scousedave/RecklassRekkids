using System.Collections.Generic;
using RecklassRekkids.Common.Interfaces.DomainObjects;

namespace RecklassRekkids.Common.Interfaces.Mappers
{
	public interface IPartnerMapper
	{
		Dictionary<string, IPartner> Map(IEnumerable<string> partnerNames);
	}
}