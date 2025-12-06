namespace Day5;

public class Task2Solver {
	public long Solve(string input) {
		var lines = input
			.Trim()
			.Split('\n')
			.Select(l => l.Trim(' ', '\t'));

		var ranges = new List<ProductRange>();
		foreach (var line in lines) {
			if (line == "") {
				break;
			}

			ranges.Add(ProductRange.FromString(line));
		}
		ranges = ranges.OrderBy(r => r.Min).ToList();

		var combinedRanges = new List<ProductRange>();
		ProductRange? lastRange = null;
		foreach (var range in ranges) {
			if (lastRange == null) {
				combinedRanges.Add(range);
				lastRange = range;
				continue;
			}

			if (lastRange.OverlapsWith(range)) {
				lastRange.Min = Math.Min(lastRange.Min, range.Min);
				lastRange.Max = Math.Max(lastRange.Max, range.Max);
				continue;
			}

			combinedRanges.Add(range);
			lastRange = range;
		}

		return combinedRanges.Sum(c => c.Length);
	}

	private bool IsProductFresh(long productId, List<ProductRange> ranges) {
		return ranges.Any(r => r.Contains(productId));
	}
}
