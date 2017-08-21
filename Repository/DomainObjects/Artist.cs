using RecklassRekkids.Common.Interfaces.DomainObjects;

namespace RecklassRekkids.DomainRepository.DomainObjects
{
	public class Artist : IArtist
	{
		public Artist(string name)
		{
			Name = name;
		}

		public string Name { get; set; }
	}
}
