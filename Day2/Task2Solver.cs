using Range = Day2.Tools.Range;

namespace Day2;

public class Task2Solver {
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
			if (IsStringRepeating(i.ToString())) {
				total += i;
			}
		}

		return total;
	}

	private bool IsStringRepeating(string str) {
		for (var partitionLength = 1; partitionLength <= str.Length / 2; partitionLength++) {
			if (str.Length % partitionLength != 0) continue;

			if (SplitToLengths(str, partitionLength).Distinct().Count() == 1) {
				return true;
			}
		}

		return false;
	}

	private IEnumerable<string> SplitToLengths(string str, int partitionLength) {
		for (int i = 0; i < str.Length; i += partitionLength) {
			yield return str[i .. (i + partitionLength)];
		}
	}
}
