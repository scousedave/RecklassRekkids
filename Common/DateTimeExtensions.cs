using System;
using System.Globalization;

namespace RecklassRekkids.Common
{
	public static class DateTimeExtensions
	{
		public static bool TryParseFromAnyDate(this string date, out DateTime parsedDate)
		{
			if (DateTime.TryParseExact(
				date
				.Replace(" ", "")
					.Replace("st", "")
					.Replace("th", ""),
				"dMMMyyyy",
				DateTimeFormatInfo.InvariantInfo,
				DateTimeStyles.AllowWhiteSpaces,
				out parsedDate)) return true;
			if (DateTime.TryParseExact(
				date
					.Replace(" ", "")
					.Replace("st", "")
					.Replace("th", ""),
				"dMMMMyyyy",
				DateTimeFormatInfo.InvariantInfo,
				DateTimeStyles.AllowWhiteSpaces,
				out parsedDate)) return true;
			return false;

		}
	}
}
