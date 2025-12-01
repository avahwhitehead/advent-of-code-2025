namespace Day1;

public class Task2Solver {
	public int Solve(string input) {
		var combinations = input
			.Split('\n', StringSplitOptions.RemoveEmptyEntries)
			.Select(l => l.Trim())
			.Select(Combination.FromString);

		const int start = 50;

		var zerosCount = FindZeros(start, combinations);

		return zerosCount;
	}

	private int FindZeros(int currentPosition, IEnumerable<Combination> combinations) {
		var zerosCount = 0;

		foreach (var c in combinations) {
			var lastPosition = currentPosition;

			currentPosition += (int)c.Direction * c.Distance;

			if (currentPosition > 0) {
				zerosCount += currentPosition / 100;
			} else if (currentPosition == 0) {
				zerosCount++;
			} else {
				zerosCount += (Math.Abs(currentPosition) / 100);
				if (lastPosition != 0) zerosCount++;
			}

			currentPosition = ModPositive(currentPosition, 100);
		}

		return zerosCount;
	}

	private int ModPositive(int value, int modulus) {
		var res = value % modulus;
		return res < 0 ? res + modulus : res;
	}
}
