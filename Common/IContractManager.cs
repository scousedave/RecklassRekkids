using System;
using RecklassRekkids.Common.Interfaces.DomainObjects;

namespace RecklassRekkids.Common
{
	public interface IContractManager
	{
		IPartner GetPartner(string partnerName);

		IMusicContract[] GetAllowedMusicTitles(IPartner partner, DateTime startDate);
		IMusicContract[] GetAllowedMusicTitles(string partnerName, string startDate);


	}
}