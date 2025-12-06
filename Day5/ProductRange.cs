namespace Day5;

public class ProductRange {
	public long Min { get; init; }
	public long Max { get; init; }

	public bool Contains(long value) {
		return value >= Min && value <= Max;
	}

	public static ProductRange FromString(string input) {
		var segments = input.Split('-');
		if (segments.Length != 2) throw new ArgumentException("Invalid input");

		return new ProductRange {
			Min = long.Parse(segments[0]),
			Max = long.Parse(segments[1])
		};
	}
}
