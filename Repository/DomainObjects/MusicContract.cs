using System;
using System.Collections.Generic;
using RecklassRekkids.Common;
using RecklassRekkids.Common.Interfaces.DomainObjects;

namespace RecklassRekkids.DomainRepository.DomainObjects
{
	public class MusicContract : IMusicContract
	{
		public MusicContract(
			IArtist artist,
			IMusicTitle musicTitle,
			IEnumerable<DistributionUse> distributionUsages,
			DateTime startDate,
			DateTime? endDate
		)
		{
			Artist = artist;
			MusicTitle = musicTitle;
			DistributionUsages = new List<DistributionUse>(distributionUsages);
			StartDate = startDate;
			EndDate = endDate;
		}

		public IArtist Artist { get; set; }
		public IMusicTitle MusicTitle { get; set; }
		public List<DistributionUse> DistributionUsages { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public override string ToString()
		{
			var output = $"{Artist.Name} | {MusicTitle.Name} | ({getDistributionString()} | {StartDate.Date} | {EndDate})";
			return output;
		}

		private string getDistributionString()
		{
			var uses = new List<string>();
			foreach(DistributionUse use in DistributionUsages) uses.Add(use.ToString());
			return String.Join(",", uses);
		}
	}
}
