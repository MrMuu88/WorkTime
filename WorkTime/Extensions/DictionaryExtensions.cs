using System.Collections.Generic;

namespace WorkTime.Extensions
{
	public static class DictionaryExtensions
	{
		public static void Upsert<Tkey, Tvalue>(this IDictionary<Tkey, Tvalue> dict, Tkey key, Tvalue value) {
			if (dict.ContainsKey(key))
				dict[key] = value;
			else
				dict.Add(key, value);
		}
	}
}
