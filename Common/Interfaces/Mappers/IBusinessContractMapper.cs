using System.Collections.Generic;
using RecklassRekkids.Common.Interfaces.DomainObjects;

namespace RecklassRekkids.Common.Interfaces.Mappers
{
	public interface IBusinessContractMapper
	{
		Dictionary<string, IBusinessContract> Map(Dictionary<string, IPartner> partners,
			Dictionary<string, string> businessContracts);
	}
}