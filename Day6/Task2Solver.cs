namespace Day6;

public class Task2Solver {
	public long Solve(string input) {
		var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
			.Select(l => l.ToCharArray())
			.ToList();

		var problems = new List<Problem>([new Problem()]);

		for (var col = 0; col < lines[0].Length; col++) {
			Problem problem;
			if (IsColumnABreak(col, lines)) {
				problem = new Problem();
				problems.Add(problem);
				continue;
			}

			problem = problems.Last();

			var argument = 0L;
			foreach (var line in lines) {
				char chr;
				if (col >= line.Length) chr = ' ';
				else chr = line[col];

				if (TryParseOperation(chr, out var operation)) {
					problem.Operation = operation!.Value;
					continue;
				}

				if (chr == ' ') continue;

				argument *= 10;
				argument += int.Parse(chr.ToString());
			}
			problem.Arguments.Add(argument);
		}

		return problems.Sum(p => p.Solve());
	}

	private bool IsColumnABreak(int col, List<char[]> lines) {
		return lines.All(l => l.Length <= col || l[col] == ' ');
	}

	private bool TryParseOperation(char c, out Operation? operation) {
		switch (c) {
			case '+':
				operation = Operation.Add;
				return true;
			case '*':
				operation = Operation.Multiply;
				return true;
		}

		operation = null;
		return false;
	}
}
