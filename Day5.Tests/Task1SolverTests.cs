using Xunit.Abstractions;

namespace Day5.Tests;

public class Task1Tests(
	ITestOutputHelper output
) {
	[Fact]
	public void Task1_ExampleInput() {
		// Arrange
		var input = @"
			3-5
			10-14
			16-20
			12-18

			1
			5
			8
			11
			17
			32
		";

		var solver = new Task1Solver();

		// Act
		var result = solver.Solve(input);

		// Assert
		Assert.Equal(3, result);
	}

	[Fact]
	public void Task1_PuzzleInput() {
		var input = File.ReadAllText("input.txt");

		var solver = new Task1Solver();
		var result = solver.Solve(input);

		output.WriteLine(result.ToString());
	}
}
