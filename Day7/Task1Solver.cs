using Xunit.Abstractions;

namespace Day7;

public class Task1Solver(
	ITestOutputHelper? output
)
{
	public int Solve(string input) {
		var grid = input
			.Trim()
			.Split('\n', StringSplitOptions.RemoveEmptyEntries)
			.Select(l => l.ToCharArray().Select(ParseCell).ToArray())
			.ToArray();

		var totalSplits = 0;
		for (var y = 1; y < grid.Length; y++) {
			totalSplits += StepRow(grid, y);
		}
		return totalSplits;
	}

	private int StepRow(CellContents[][] grid, int y) {
		var totalSplits = 0;

		for (var x = 0; x < grid[y].Length; x++) {
			var currentCell = grid[y][x];

			// Only need to operate on cells where the above is a Beam
			var aboveCell = grid[y - 1][x];
			if (aboveCell != CellContents.Beam) continue;

			// Beams flow down into empty cells
			if (currentCell == CellContents.Empty) {
				grid[y][x] = CellContents.Beam;
			}

			// Splitters add a beam to either side
			// Splits are only counted if they convert an empty cell into a beam
			if (currentCell == CellContents.Splitter) {
				bool hasSplit = false;
				if (x > 0 && grid[y][x - 1] == CellContents.Empty) {
					grid[y][x - 1] = CellContents.Beam;
					hasSplit = true;
				}

				if (x < grid.Length - 1 && grid[y][x + 1] == CellContents.Empty) {
					grid[y][x + 1] = CellContents.Beam;
					hasSplit = true;
				}

				if (hasSplit) {
					totalSplits++;
				}
			}
			DisplayGrid(grid);
		}
		return totalSplits;
	}

	private CellContents ParseCell(char cell) {
		return cell switch {
			'S' => CellContents.Beam,
			'.' => CellContents.Empty,
			'^' => CellContents.Splitter,
			_ => throw new ArgumentOutOfRangeException(nameof(cell), cell, null)
		};
	}

	private char CellToString(CellContents cell) {
		return cell switch {
			CellContents.Beam => '|',
			CellContents.Empty => '.',
			CellContents.Splitter => '^',
			_ => throw new ArgumentOutOfRangeException(nameof(cell), cell, null)
		};
	}

	private void DisplayGrid(CellContents[][] grid) {
		if (output == null) return;

		foreach (var row in grid) {
			output.WriteLine(string.Join("", row.Select(CellToString)));
		}
		output.WriteLine(string.Empty);
		output.WriteLine(string.Empty);
	}
}
