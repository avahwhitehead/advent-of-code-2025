namespace Day8;

public class XyzCoordinate {
	public int X { get; init; }
	public int Y { get; init; }
	public int Z { get; init; }

	public static XyzCoordinate Parse(string input) {
		var parts = input.Split(',');

		return new XyzCoordinate {
			X = int.Parse(parts[0]),
			Y = int.Parse(parts[1]),
			Z = int.Parse(parts[2]),
		};
	}

	public int DistanceTo(XyzCoordinate other) {
		var squareSum = Square(other.X - X) + Square(other.Y - Y) + Square(other.Z - Z);

		return (int)Math.Sqrt(squareSum);
	}

	private long Square(long v) {
		return v * v;
	}

	public override bool Equals(object? obj) {
		if (obj is not XyzCoordinate other) return false;
		if (other == this) return true;

		return (X, Y, Z) == (other.X, other.Y, other.Z);
	}

	public override int GetHashCode() {
		return HashCode.Combine(X, Y, Z);
	}

	public override string ToString() {
		return $"({X},{Y},{Z})";
	}
}
