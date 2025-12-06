namespace Day6;

public class Task1Solver {
	public long Solve(string input) {
		var lines = input.Trim().Split('\n')
			.Select(l => l.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
			.ToList();

		var problems = new List<Problem>();
		foreach (var line in lines) {
			for (var col = 0; col < line.Length; col++) {
				if (problems.Count <= col) problems.Add(new Problem());

				var problem = problems[col];

				if (TryParseOperation(line[col], out var operation)) {
					problem.Operation = operation!.Value;
					continue;
				}

				if (line[col] == string.Empty) continue;

				problem.Arguments.Add(int.Parse(line[col]));
			}
		}

		return problems.Sum(p => p.Solve());
	}

	private bool TryParseOperation(string s, out Operation? operation) {
		switch (s) {
			case "+":
				operation = Operation.Add;
				return true;
			case "*":
				operation = Operation.Multiply;
				return true;
		}

		operation = null;
		return false;
	}
}
