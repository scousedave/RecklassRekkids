using System.Collections.Generic;
using RecklassRekkids.Common.Interfaces.DomainObjects;
using RecklassRekkids.Common.Interfaces.Mappers;
using RecklassRekkids.DomainRepository.DomainObjects;

namespace RecklassRekkids.DomainRepository.Mappers
{
	public class MusicTitleMapper : IMusicTitleMapper
	{
		public Dictionary<string, IMusicTitle> Map(IEnumerable<string> musicTitleNames)
		{
			var titles = new Dictionary<string, IMusicTitle>();
			foreach (string name in musicTitleNames)
			{
				if (!string.IsNullOrWhiteSpace(name) && !titles.ContainsKey(name))
				{
					titles.Add(name, new MusicTitle(name));
				}
			}
			return titles;
		}
	}
}
