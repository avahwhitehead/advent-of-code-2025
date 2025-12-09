namespace Day8;

public static class DictionaryExtensions {
	public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, Func<TValue> valueFactory) where TKey: notnull {
		if (dict.TryGetValue(key, out var actualValue)) return actualValue;

		var val = valueFactory();
		dict.Add(key, val);
		return val;
	}
}
