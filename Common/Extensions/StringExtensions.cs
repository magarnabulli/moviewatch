
namespace Common.Extensions
{
	public static class StringExtensions
	{
		public static string Truncate(this string value, int maxLenght)
		{
			if(value == null) { return string.Empty; }
			if(value.Length <= maxLenght) { return value; }
			var result = value.Substring(0, maxLenght);
			return $"{result} ...";
		}
	}
}
