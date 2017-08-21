using System.Collections.Generic;
using RecklassRekkids.Common;
using RecklassRekkids.Common.Interfaces.DomainObjects;

namespace RecklassRekkids.DomainRepository.DomainObjects
{
	public class BusinessContract : IBusinessContract
	{
		public BusinessContract(IPartner partner, IEnumerable<DistributionUse> distributionUsage)
		{
			Partner = partner;
			DistributionUsage = new List<DistributionUse>(distributionUsage);
		}
		public IPartner Partner { get; set; }
		public List<DistributionUse> DistributionUsage { get; set; }
	}
}
