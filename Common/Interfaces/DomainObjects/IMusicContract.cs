using System;
using System.Collections.Generic;

namespace RecklassRekkids.Common.Interfaces.DomainObjects
{
	public interface IMusicContract
	{
		IArtist Artist { get; set; }
		IMusicTitle MusicTitle { get; set; }
		List<DistributionUse> DistributionUsages { get; set; }
		DateTime StartDate { get; set; }
		DateTime? EndDate { get; set; }
	}
}