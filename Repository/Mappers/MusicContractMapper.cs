using System;
using System.Collections.Generic;
using System.Globalization;
using RecklassRekkids.Common;
using RecklassRekkids.Common.Interfaces.DomainObjects;
using RecklassRekkids.Common.Interfaces.Mappers;
using RecklassRekkids.DomainRepository.DomainObjects;

namespace RecklassRekkids.DomainRepository.Mappers
{
	public class MusicContractMapper : IMusicContractMapper
	{
		public Dictionary<string, List<IMusicContract>> Map(
			Dictionary<string, Dictionary<string, Dictionary<string, string>>> musicContractData,
			Dictionary<string, IArtist> artists,
			Dictionary<string, IMusicTitle> musicTitles
		)
		{
			var musicContracts = new Dictionary<string, List<IMusicContract>>();

			foreach (string artistName in musicContractData.Keys)
			{
				foreach ( string titleName in musicContractData[artistName].Keys)
				{
					Dictionary<string, string> musicData = musicContractData[artistName][titleName];
					var artist = artists[artistName];
					var title = musicTitles[titleName];

					string[] usages = musicData["Usages"].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					if (usages.Length == 0) continue;
					var uses = new List<DistributionUse>();
					foreach (string usage in usages)
					{
						if (Enum.TryParse(usage, out DistributionUse use))
						{
							uses.Add(use);
						}
					}
					if (!DateTime.TryParseExact(
						musicData["StartDate"]
						.Replace("st","")
						.Replace("th","")
						.Replace("June", "Jun"),
						"dMMMyyyy",
						DateTimeFormatInfo.InvariantInfo,
						DateTimeStyles.None,
						out DateTime startDate))
					continue;

					DateTime? endDate = null;
					if (musicData.Count > 4 && musicData.ContainsKey("EndDate") && musicData["EndDate"] != null)
					{
						if (DateTime.TryParseExact(
							musicData["EndDate"]
							.Replace("st", "")
							.Replace("th", "")
							.Replace("June", "Jun"),
							"dMMMyyyy",
							DateTimeFormatInfo.InvariantInfo,
							DateTimeStyles.None,
							out DateTime endDate2))
						endDate = endDate2;
					}

					var musicContract = new MusicContract(artist, title, uses, startDate, endDate);
					if (musicContracts.ContainsKey(artistName))
					{
						musicContracts[artistName].Add(musicContract);}
					else
					{
						musicContracts.Add(artistName, new List <IMusicContract>(new[] { musicContract }));
					};
				}
			}
			return musicContracts;
		}
	}
}
