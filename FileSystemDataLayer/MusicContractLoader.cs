using System.Collections.Generic;
using System.IO;

namespace RecklassRekkids.FileSystemDataLayer
{
	internal static class MusicContractLoader
	{
		public static Dictionary<string, Dictionary<string, Dictionary<string, string>>> Load(string musicContractPath)
		{
			var contracts = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
			string[] lines = File.ReadAllLines(musicContractPath);
			if (lines.Length < 2) throw new FileLoadException($"Data file at {musicContractPath} is empty of data");

			string[] titles = lines[0].Split('|');
			for (int index = 1; index < lines.Length; index++)
			{
				string[] parts = lines[index].Split('|');
				if (parts.Length < 4) continue;
				if(!contracts.ContainsKey(parts[0])) contracts.Add(parts[0], new Dictionary<string, Dictionary<string, string>>());
				if (!contracts[parts[0]].ContainsKey(parts[1])) contracts[parts[0]].Add(parts[1], new Dictionary<string, string>());

				for (int titleIndex = 0; titleIndex < titles.Length; titleIndex++)
				{
					if(titleIndex < parts.Length && parts[titleIndex] != null) contracts[parts[0]][parts[1]].Add(titles[titleIndex], parts[titleIndex]);
				}
			}


			return contracts;
		}
	}
}
