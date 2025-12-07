using Xunit.Abstractions;

namespace Day7.Tests;

public class Task1Tests(
	ITestOutputHelper output
) {
	[Fact]
	public void Task1_ExampleInput() {
		// Arrange
		var input = @"
.......S.......
...............
.......^.......
...............
......^.^......
...............
.....^.^.^.....
...............
....^.^...^....
...............
...^.^...^.^...
...............
..^...^.....^..
...............
.^.^.^.^.^...^.
...............
		";

		var solver = new Task1Solver(output);

		// Act
		var result = solver.Solve(input);

		// Assert
		Assert.Equal(21, result);
	}

	[Fact]
	public void Task1_PuzzleInput() {
		var input = File.ReadAllText("input.txt");

		var solver = new Task1Solver(null);
		var result = solver.Solve(input);

		output.WriteLine(result.ToString());
	}
}
