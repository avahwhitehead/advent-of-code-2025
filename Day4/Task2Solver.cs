using Xunit.Abstractions;

namespace Day4;

public class Task2Solver(ITestOutputHelper? output) {
	public int Solve(string input) {
		var grid = input
			.Split('\n', StringSplitOptions.RemoveEmptyEntries)
			.Select(c => c.ToCharArray().Select(GetCellContent).ToArray())
			.ToArray();

		var totalRemovedAccessibleRolls = 0;
		var lastRemovedAccessibleRolls = 0;
		do {
			lastRemovedAccessibleRolls = RemoveAccessibleRolls(grid);
			totalRemovedAccessibleRolls += lastRemovedAccessibleRolls;
		} while (lastRemovedAccessibleRolls > 0);

		return totalRemovedAccessibleRolls;
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

	private int RemoveAccessibleRolls(CellContent[][] grid) {
		var removedAccessibleRolls = 0;

		for (var y = 0; y < grid.Length; y++) {
			for (var x = 0; x < grid[0].Length; x++) {
				if (grid[y][x] != CellContent.PaperRoll) {
					continue;
				}

				if (IsCellAccessible(grid, x, y)) {
					grid[y][x] = CellContent.Empty;
					removedAccessibleRolls++;
				}
			}
		}
		return removedAccessibleRolls;
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
