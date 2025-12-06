namespace Day5;

public class ProductRange {
	public long Min { get; set; }
	public long Max { get; set; }

	public bool Contains(long value) {
		return value >= Min && value <= Max;
	}

	public bool OverlapsWith(ProductRange other) {
		if (Contains(other.Min) || Contains(other.Max)) return true;
		return other.Contains(Min) || other.Contains(Max);
	}

	public long Length => Max - Min + 1;

	public static ProductRange FromString(string input) {
		var segments = input.Split('-');
		if (segments.Length != 2) throw new ArgumentException("Invalid input");

		return new ProductRange {
			Min = long.Parse(segments[0]),
			Max = long.Parse(segments[1])
		};
	}
}
