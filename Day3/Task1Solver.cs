namespace Day3;

public class Task1Solver {
	public int Solve(string input) {
		return input
			.Split('\n', StringSplitOptions.RemoveEmptyEntries)
			.Select(v => v.Trim())
			.Select(FindJoltage)
			.Sum();
	}

	private int FindJoltage(string battery) {
		var largestValue = FindLargestValue(battery, 0, battery.Length - 1);

		var nextLargest = FindLargestValue(battery, largestValue.Pos + 1, battery.Length - 1 - largestValue.Pos);

		return (largestValue.Val * 10) + nextLargest.Val;
	}

	private (int Pos, int Val) FindLargestValue(string battery, int start, int length) {
		int largestValue = int.Parse(battery[start].ToString());
		int largestValueIndex = start;

		for (var currentIndex = start; currentIndex < start + length; currentIndex++){
			var currentValue = int.Parse(battery[currentIndex].ToString());

			if (largestValue < currentValue) {
				largestValue = currentValue;
				largestValueIndex = currentIndex;
			}
		}

		return (largestValueIndex, largestValue);
	}
}
