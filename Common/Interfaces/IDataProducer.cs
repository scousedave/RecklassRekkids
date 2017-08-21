namespace RecklassRekkids.Common.Interfaces
{
	using System.Collections.Generic;

	public interface IDataProducer
	{
		Dictionary<string, Dictionary<string, Dictionary<string, string>>> GetMusicContracts();
		Dictionary<string, string> GetPartnerContracts();

	}
}
