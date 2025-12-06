namespace Day6;

public class Problem {
	public List<long> Arguments { get; init; } = [];

	public Operation Operation { get; set; }

	public long Solve() {
		if (Operation == Operation.Add) {
			return Arguments.Sum();
		}

		if (Operation == Operation.Multiply) {
			return Arguments.Aggregate(1L, (acc, x) => acc * x);
		}

		throw new InvalidOperationException($"Unknown operation {Operation}");
	}
}


public enum Operation {
	Add,
	Multiply
}
