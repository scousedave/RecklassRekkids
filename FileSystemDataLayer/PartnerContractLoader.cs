using System;
using System.Collections.Generic;
using System.IO;

namespace RecklassRekkids.FileSystemDataLayer
{
	public static class PartnerContractLoader
	{
		internal static Dictionary<string, string> Load(string partnerContractPath)
		{
			var contracts = new Dictionary<string, string>();
			 string[] lines = File.ReadAllLines(partnerContractPath);

			if(lines.Length == 0) throw new FileLoadException($"Data file at {partnerContractPath} is empty of data");
			for (int i = 1; i < lines.Length; i++)
			{
				string[] parts = lines[i].Split('|');
				if (parts.Length != 2) continue;
				if(contracts.ContainsKey(parts[0])) continue;
				contracts.Add(parts[0], parts[1]);
			}
			return contracts;
		}
	}
}
