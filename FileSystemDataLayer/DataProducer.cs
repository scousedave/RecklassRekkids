using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using RecklassRekkids.Common;
using RecklassRekkids.Common.Interfaces;

namespace RecklassRekkids.FileSystemDataLayer
{
	public class DataProducer : IDataProducer
	{
		public Dictionary<string, Dictionary<string, Dictionary<string, string>>> GetMusicContracts()
		{
			string filePath = Configuration.MusicDataLocation;
			if(!File.Exists(filePath)) throw new FileNotFoundException($"Cannot find MusicContracts data file at location: {filePath}");
			var musicContractData = MusicContractLoader.Load(filePath);
			return musicContractData;
		}

		public Dictionary<string,string> GetPartnerContracts()
		{
			string filePath = Configuration.PartnerDataLocation;
			if (!File.Exists(filePath)) throw new FileNotFoundException($"Cannot find PartnerContracts data file at location: {filePath}");
			var partnerContractData = PartnerContractLoader.Load(filePath);
			return partnerContractData;
		}
	}
}
