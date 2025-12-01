namespace Day1;

public class Task1Solver {
	public int Solve(string input) {
		var combinations = input
			.Split('\n', StringSplitOptions.RemoveEmptyEntries)
			.Select(l => l.Trim())
			.Select(Combination.FromString);

		const int start = 50;

		var zerosCount = SumCombinations(start, combinations);

		return zerosCount;
	}

	private int SumCombinations(int currentPosition, IEnumerable<Combination> combinations) {
		var zerosCount = 0;

		foreach (var c in combinations) {
			currentPosition += (int)c.Direction * c.Distance;
			currentPosition = ModPositive(currentPosition, 100);

			if (currentPosition == 0) zerosCount++;
		}

		return zerosCount;
	}

	private int ModPositive(int value, int modulus) {
		var res = value % modulus;
		return res < 0 ? res + modulus : res;
	}
}

internal class Combination {
	public Direction Direction { get; init; }
	public int Distance { get; init; }


	private Combination(Direction direction, int distance) {
		Direction = direction;
		Distance = distance;
	}

	public static Combination FromString(string input) {
		var direction = input[0] switch {
			'L' => Direction.Descending,
			_ => Direction.Ascending
		};

		var distance = int.Parse(input[1..]);

		return new Combination(direction, distance);
	}
}

internal enum Direction {
	Descending = -1,
	Ascending = 1,
}
