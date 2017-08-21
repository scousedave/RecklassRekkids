using System.Collections.Generic;
using RecklassRekkids.Common.Interfaces.DomainObjects;

namespace RecklassRekkids.Common.Interfaces.Mappers
{
	public interface IMusicTitleMapper
	{
		Dictionary<string, IMusicTitle> Map(IEnumerable<string> musicTitleNames);
	}
}