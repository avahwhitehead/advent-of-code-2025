namespace Day5;

public class Task1Solver {
	public int Solve(string input) {
		var lines = input
			.Trim()
			.Split('\n')
			.Select(l => l.Trim([' ', '\t']));

		var ranges = new List<ProductRange>();

		var freshProductsCount = 0;

		var isInRangesDefinition = true;
		foreach (var line in lines) {
			if (line == "") {
				isInRangesDefinition = false;
				continue;
			}

			if (isInRangesDefinition) {
				ranges.Add(ProductRange.FromString(line));
				continue;
			}

			if (IsProductFresh(long.Parse(line), ranges)) {
				freshProductsCount++;
			}
		}

		return freshProductsCount;
	}

	private bool IsProductFresh(long productId, List<ProductRange> ranges) {
		return ranges.Any(r => r.Contains(productId));
	}
}
