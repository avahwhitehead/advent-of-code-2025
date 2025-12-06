using Xunit.Abstractions;

namespace Day6.Tests;

public class Task2Tests(
	ITestOutputHelper output
) {
	[Theory]
	[InlineData("123 \n 45 \n  6\n*", 8544)]
	[InlineData("328 \n64  \n98 \n+", 625)]
	[InlineData(" 51 \n387 \n215\n*", 3253600)]
	[InlineData("64  \n23  \n314\n+", 1058)]
	public void Task2_ExampleInput_Columns(string input, long expected) {
		// Arrange
		var solver = new Task2Solver();

		// Act
		var result = solver.Solve(input);

		// Assert
		Assert.Equal(expected, result);
	}

	[Fact]
	public void Task2_ExampleInput() {
		// Arrange
		var input = "123 328  51 64 \n 45 64  387 23 \n  6 98  215 314\n*   +   *   +  \n";

		var solver = new Task2Solver();

		// Act
		var result = solver.Solve(input);

		// Assert
		Assert.Equal(3263827, result);
	}

	[Fact]
	public void Task2_PuzzleInput() {
		var input = File.ReadAllText("input.txt");

		var solver = new Task2Solver();
		var result = solver.Solve(input);

		output.WriteLine(result.ToString());
	}
}
