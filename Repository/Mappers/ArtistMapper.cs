using System.Collections.Generic;
using RecklassRekkids.Common.Interfaces.DomainObjects;
using RecklassRekkids.Common.Interfaces.Mappers;
using RecklassRekkids.DomainRepository.DomainObjects;

namespace RecklassRekkids.DomainRepository.Mappers
{
	public class ArtistMapper : IArtistMapper
	{
		public Dictionary<string, IArtist> Map(IEnumerable<string> artistNames)
		{
			var artists = new Dictionary<string, IArtist>();
			foreach (string name in artistNames)
			{
				if (!string.IsNullOrWhiteSpace(name) && !artists.ContainsKey(name))
				{
					artists.Add(name, new Artist(name));
				}
			}
			return artists;
		}
	}
}
