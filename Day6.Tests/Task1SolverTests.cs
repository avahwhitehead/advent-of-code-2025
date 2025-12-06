using Xunit.Abstractions;

namespace Day6.Tests;

public class Task1Tests(
	ITestOutputHelper output
) {
	[Theory]
	[InlineData("123 \n  45 \n    6\n*", 33210)]
	[InlineData("328 \n  64 \n   98\n+", 490)]
	[InlineData(" 51 \n 387 \n  215\n*", 4243455)]
	[InlineData(" 64 \n  23 \n  314\n+", 401)]
	public void Task1_ExampleInput_Columns(string input, long expected) {
		// Arrange
		var solver = new Task1Solver();

		// Act
		var result = solver.Solve(input);

		// Assert
		Assert.Equal(expected, result);
	}

	[Fact]
	public void Task1_ExampleInput() {
		// Arrange
		var input = "123 328  51 64 \n 45 64  387 23 \n  6 98  215 314\n*   +   *   +  \n";

		var solver = new Task1Solver();

		// Act
		var result = solver.Solve(input);

		// Assert
		Assert.Equal(4277556, result);
	}

	[Fact]
	public void Task1_PuzzleInput() {
		var input = File.ReadAllText("input.txt");

		var solver = new Task1Solver();
		var result = solver.Solve(input);

		output.WriteLine(result.ToString());
	}
}
