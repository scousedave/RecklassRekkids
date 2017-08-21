using RecklassRekkids.Common.Interfaces.DomainObjects;

namespace RecklassRekkids.DomainRepository.DomainObjects
{
	public class Partner : IPartner
	{
		public Partner(string name)
		{
			Name = name;
		}
		public string Name { get; set; }
	}
}
