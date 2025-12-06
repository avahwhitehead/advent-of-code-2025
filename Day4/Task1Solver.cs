using Xunit.Abstractions;

namespace Day4;

public class Task1Solver(ITestOutputHelper? output) {
	public int Solve(string input) {
		var grid = input
			.Split('\n', StringSplitOptions.RemoveEmptyEntries)
			.Select(c => c.ToCharArray().Select(GetCellContent).ToArray())
			.ToArray();

		return CountAccessibleRolls(grid);
	}

	private CellContent GetCellContent(char c) {
		switch (c) {
			case '.':
				return CellContent.Empty;
			case '@':
				return CellContent.PaperRoll;
		}

		throw new ArgumentOutOfRangeException(nameof(c), c, null);
	}

	private int CountAccessibleRolls(CellContent[][] grid) {
		var accessibleRolls = 0;

		char[][] outputGrid = new char[grid.Length][];

		for (var y = 0; y < grid.Length; y++) {
			outputGrid[y] = new char[grid[0].Length];
			for (var x = 0; x < grid[0].Length; x++) {
				if (grid[y][x] != CellContent.PaperRoll) {
					outputGrid[y][x] = '.';
					continue;
				}

				if (IsCellAccessible(grid, x, y)) {
					outputGrid[y][x] = 'x';
					accessibleRolls++;
				} else {
					outputGrid[y][x] = '@';
				}
			}
		}

		if (output != null) {
			foreach (var row in outputGrid) {
				output.WriteLine(string.Join("", row));
			}
		}

		return accessibleRolls;
	}

	private bool IsCellAccessible(CellContent[][] grid, int x, int y) {
		const int maxAdjacentRolls = 4;
		var adjacentRolls = 0;

		var gridHeight = grid.Length;
		var gridWidth = grid[0].Length;

		for (int checkY = y - 1; checkY <= y + 1; checkY++) {
			if (checkY < 0 || checkY >= gridHeight) continue;

			for (int checkX = x - 1; checkX <= x + 1; checkX++) {
				if (checkX < 0 || checkX >= gridWidth) continue;

				if (checkX == x && checkY == y) continue;

				if (grid[checkY][checkX] == CellContent.PaperRoll) adjacentRolls++;

				if (adjacentRolls >= maxAdjacentRolls) return false;
			}
		}

		return true;
	}
}
