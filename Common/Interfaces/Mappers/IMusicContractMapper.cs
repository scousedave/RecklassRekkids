using System.Collections.Generic;
using RecklassRekkids.Common.Interfaces.DomainObjects;

namespace RecklassRekkids.Common.Interfaces.Mappers
{
	public interface IMusicContractMapper
	{
		Dictionary<string, List<IMusicContract>> Map(
			Dictionary<string, Dictionary<string, Dictionary<string, string>>> musicContractData,
			Dictionary<string, IArtist> artists,
			Dictionary<string, IMusicTitle> musicTitles
		);
	}
}