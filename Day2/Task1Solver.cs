using Range = Day2.Tools.Range;

namespace Day2;

public class Task1Solver {
	public long Solve(string input) {
		var ranges = input
			.Trim(['\n', ' '])
			.Split(',', StringSplitOptions.RemoveEmptyEntries)
			.Select(l => l.Trim())
			.Select(l => l.Split('-'))
			.Select(l => new Range {
				Start = long.Parse(l[0]),
				End = long.Parse(l[1])
			});

		return ranges.Sum(FindCombinationsInRange);
	}

	private long FindCombinationsInRange(Range range) {
		var total = 0L;

		foreach (var i in range.Enumerate()) {
			var str = i.ToString();

			if (str.Length % 2 != 0) continue;

			var start = str[..(str.Length / 2)];
			var end = str[(str.Length / 2)..];

			if (start == end) {
				total += i;
			}
		}

		return total;
	}
}
