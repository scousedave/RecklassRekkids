using System;
using System.Collections.Generic;
using RecklassRekkids.Common.Interfaces.DomainObjects;

namespace RecklassRekkids.Common.Interfaces
{
	public interface IRepository
	{
		IPartner GetPartnerByName(string name);
		IMusicContract[] GetMusicContracts(IPartner partner, DateTime date);

	}
}
