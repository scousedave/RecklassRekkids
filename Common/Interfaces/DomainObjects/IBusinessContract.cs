using System.Collections.Generic;

namespace RecklassRekkids.Common.Interfaces.DomainObjects
{
	public interface IBusinessContract
	{
		IPartner Partner { get; set; }
		List<DistributionUse> DistributionUsage { get; set; }
	}
}