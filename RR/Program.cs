using System;
using RecklassRekkids.Business;
using RecklassRekkids.Common;
using RecklassRekkids.Common.Interfaces.DomainObjects;
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
			args = new string[]{ "'YouTube 27th Dec 2012'" };
			if (args.Length == 1) args = normaliseArgs(args);
			if (args.Length < 2)
			{
				Console.WriteLine("Not enough arguments");
				Environment.Exit(0);
			}

			_contractManager = new ContractManager(new DataProducer());

			string partner = args[0];
			string date = coalesceArgs(args);

			var contracts = _contractManager.GetAllowedMusicTitles(partner, date);

			if (contracts.Length == 0)
			{
				Console.WriteLine("No contracts found");
				Environment.Exit(0);
			}
			printResults(contracts);
		}

		static string[] normaliseArgs(string[] args)
		{
			var output = args[0].Replace("'", "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			return output;
		}
		static string coalesceArgs(string[] args)
		{
			string arg = String.Empty;
			;
			for (int i = 1; i < args.Length; i++)
			{
				arg = $"{arg} {args[i]}";
			}
			return arg;
		}
		static void printResults(IMusicContract[] contracts)
		{
			foreach(IMusicContract contract in contracts) Console.WriteLine(contract);
		}
	}
}
