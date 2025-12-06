using Xunit.Abstractions;

namespace Day5.Tests;

public class Task2Tests(
	ITestOutputHelper output
) {
	[Fact]
	public void Task2_ExampleInput() {
		// Arrange
		var input = @"
			3-5
			10-14
			16-20
			12-18
		";

		var solver = new Task2Solver();

		// Act
		var result = solver.Solve(input);

		// Assert
		Assert.Equal(14, result);
	}

	[Fact]
	public void Task2_PuzzleInput() {
		var input = File.ReadAllText("input.txt");

		var solver = new Task2Solver();
		var result = solver.Solve(input);

		output.WriteLine(result.ToString());
	}
}
