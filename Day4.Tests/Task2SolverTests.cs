using Xunit.Abstractions;

namespace Day4.Tests;

public class Task2Tests(
	ITestOutputHelper output
) {
	[Fact]
	public void Task2_ExampleInput() {
		// Arrange
		var input = "..@@.@@@@.\n@@@.@.@.@@\n@@@@@.@.@@\n@.@@@@..@.\n@@.@@@@.@@\n.@@@@@@@.@\n.@.@.@.@@@\n@.@@@.@@@@\n.@@@@@@@@.\n@.@.@@@.@.";

		var solver = new Task2Solver(output);

		// Act
		var result = solver.Solve(input);

		// Assert
		Assert.Equal(43, result);
	}

	[Fact]
	public void Task2_PuzzleInput() {
		var input = File.ReadAllText("input.txt");

		var solver = new Task2Solver(null);
		var result = solver.Solve(input);

		output.WriteLine(result.ToString());
	}
}
