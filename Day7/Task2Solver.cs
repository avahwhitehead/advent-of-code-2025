using Xunit.Abstractions;

namespace Day7;

public class Task2Solver(
	ITestOutputHelper? output
)
{
	public long Solve(string input) {
		var grid = input
			.Trim()
			.Split('\n', StringSplitOptions.RemoveEmptyEntries)
			.Select(l => l.ToCharArray().Select(ParseCell).ToArray())
			.ToArray();

		var startBeamX = Array.FindIndex(grid[0], c => c == CellContents.Beam);
		return CountTimelines(grid, startBeamX, 0, new Dictionary<string, long>());
	}

	private long CountTimelines(CellContents[][] grid, int beamX, int beamY, Dictionary<string, long> lookupCache) {
		if (beamY < 0 || beamY + 1 >= grid.Length) return 1;

		// Error in unknown state (cannot encounter another beam)
		if (grid[beamY + 1][beamX] == CellContents.Beam) {
			throw new InvalidOperationException($"Cell at ({beamX}, {beamY}) is not splitter or empty");
		}

		// See if the number of timelines from this point has already been calculated
		if (lookupCache.TryGetValue($"{beamY},{beamX}", out var timelineCount)) {
			return timelineCount;
		}

		// Beam continues downwards with no splitting
		if (grid[beamY + 1][beamX] == CellContents.Empty) {
			return CountTimelines(grid, beamX, beamY + 1, lookupCache);
		}

		var totalTimelines = 0L;

		// Follow timeline to the left
		if (beamX > 0) {
			totalTimelines += CountTimelines(grid, beamX - 1, beamY + 1, lookupCache);
		}
		// Follow timeline to the right
		if (beamX < grid[beamY].Length - 1) {
			totalTimelines += CountTimelines(grid, beamX + 1, beamY + 1, lookupCache);
		}

		// Cache the result
		lookupCache[$"{beamY},{beamX}"] = totalTimelines;

		return totalTimelines;
	}

	private CellContents ParseCell(char cell) {
		return cell switch {
			'S' => CellContents.Beam,
			'.' => CellContents.Empty,
			'^' => CellContents.Splitter,
			_ => throw new ArgumentOutOfRangeException(nameof(cell), cell, null)
		};
	}
}
