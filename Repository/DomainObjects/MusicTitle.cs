using RecklassRekkids.Common.Interfaces.DomainObjects;

namespace RecklassRekkids.DomainRepository.DomainObjects
{
	public class MusicTitle : IMusicTitle
	{
		public MusicTitle(string name)
		{
			Name = name;
		}
		public string Name { get; set; }
	}
}
