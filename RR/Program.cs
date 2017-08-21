using RecklassRekkids.Business;
using RecklassRekkids.FileSystemDataLayer;

namespace RecklassRekkids.RR
{
	public class Program
	{
		private static IContractManager _contractManager;
		Program()
		{
		}
		static void Main(string[] args)
		{
			_contractManager = new ContractManager(new DataProducer());

		}
	}
}
