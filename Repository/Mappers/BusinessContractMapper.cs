using System;
using System.Collections.Generic;
using RecklassRekkids.Common;
using RecklassRekkids.Common.Interfaces.DomainObjects;
using RecklassRekkids.Common.Interfaces.Mappers;
using RecklassRekkids.DomainRepository.DomainObjects;

namespace RecklassRekkids.DomainRepository.Mappers
{
	public class BusinessContractMapper : IBusinessContractMapper
	{
		public Dictionary<string, IBusinessContract> Map(Dictionary<string, IPartner> partners,
			Dictionary<string, string> businessContracts)
		{
			var contracts = new Dictionary<string, IBusinessContract>();

			foreach (string partner in businessContracts.Keys)
			{
				string[] usages = businessContracts[partner].Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
				if (usages.Length == 0) continue;
				var uses = new List<DistributionUse>();
				foreach (string usage in usages)
				{
					if(Enum.TryParse(usage, out DistributionUse use))
					{
						uses.Add(use);
					}
				}
				if (uses.Count > 0 && partners.ContainsKey(partner))
				{
					contracts.Add(partner, new BusinessContract(partners[partner], uses));
				}
			}
			return contracts;
		}
	}
}
