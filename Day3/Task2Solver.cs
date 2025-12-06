namespace Day3;

public class Task2Solver {
	public long Solve(string input) {
		return input
			.Split('\n', StringSplitOptions.RemoveEmptyEntries)
			.Select(v => v.Trim())
			.Select(FindJoltage)
			.Sum();
	}

	private long FindJoltage(string battery) {
		const int joltageLength = 12;

		var startingIndex = 0;

		long joltageSum = 0;
		for (int i = 0; i < joltageLength; i++) {
			var maxIndex = battery.Length - (joltageLength - i);

			var largestValue = FindLargestValue(battery, startingIndex, maxIndex);
			startingIndex = largestValue.Pos + 1;

			joltageSum += largestValue.Val * (long) Math.Pow(10, joltageLength - i - 1);
		}

		return joltageSum;
	}

	private (int Pos, int Val) FindLargestValue(string battery, int start, int end) {
		var largestValue = int.Parse(battery[start].ToString());
		var largestValueIndex = start;

		for (var currentIndex = start; currentIndex <= end; currentIndex++){
			var currentValue = int.Parse(battery[currentIndex].ToString());

			if (largestValue < currentValue) {
				largestValue = currentValue;
				largestValueIndex = currentIndex;
			}
		}

		return (largestValueIndex, largestValue);
	}
}
