using System.Collections.Generic;
using RecklassRekkids.Common.Interfaces.DomainObjects;

namespace RecklassRekkids.Common.Interfaces.Mappers
{
	public interface IArtistMapper
	{
		Dictionary<string, IArtist> Map(IEnumerable<string> artistNames);
	}
}