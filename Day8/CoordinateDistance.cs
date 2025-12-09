namespace Day8;

public class CoordinateDistance {
	public XyzCoordinate Point1 { get; init; }
	public XyzCoordinate Point2 { get; init; }
	public int Distance { get; init; }


	public override bool Equals(object? obj) {
		if (obj is not CoordinateDistance other) return false;

		if (Point1 == other.Point1 && Point2 == other.Point2) return true;
		if (Point1 == other.Point2 && Point2 == other.Point1) return true;

		return false;
	}

	public override int GetHashCode() {
		return Point1.GetHashCode() ^ Point2.GetHashCode();
	}
}
