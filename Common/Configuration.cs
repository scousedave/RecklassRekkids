using System.Configuration;

namespace RecklassRekkids.Common
{
	public static class Configuration
	{
		public static string MusicDataLocation
		{
			get
			{
				if(ConfigurationManager.AppSettings["MusicDataLocation"] == null) throw new ConfigurationErrorsException("MusicDataLocation missing from configuration");
				string musicDataLocation = ConfigurationManager.AppSettings["MusicDataLocation"];
				if(string.IsNullOrWhiteSpace(musicDataLocation)) throw new ConfigurationErrorsException("MusicDataLocation missing from configuration");
				return musicDataLocation;
			}
		}
		public static string PartnerDataLocation
		{
			get
			{
				if (ConfigurationManager.AppSettings["PartnerDataLocation"] == null) throw new ConfigurationErrorsException("PartnerDataLocation missing from configuration");
				string partnerDataLocation = ConfigurationManager.AppSettings["PartnerDataLocation"];
				if (string.IsNullOrWhiteSpace(partnerDataLocation)) throw new ConfigurationErrorsException("PartnerDataLocation missing from configuration");
				return partnerDataLocation;
			}
		}

	}
}
