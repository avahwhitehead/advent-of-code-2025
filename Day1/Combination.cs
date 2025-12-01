using System.Text;

namespace Day1;

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

	public override string ToString() {
		var stringBuilder = new StringBuilder();
		if (Direction == Direction.Ascending) stringBuilder.Append("R");
		else stringBuilder.Append("L");
		stringBuilder.Append(Distance);
		return stringBuilder.ToString();
	}
}
