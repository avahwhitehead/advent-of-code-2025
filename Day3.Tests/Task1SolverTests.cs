using Xunit.Abstractions;

namespace Day3.Tests;

public class Task1Tests(
	ITestOutputHelper output
) {
	[Theory]
	[InlineData("987654321111111", 98)]
	[InlineData("811111111111119", 89)]
	[InlineData("234234234234278", 78)]
	[InlineData("818181911112111", 92)]
	public void Task1_ExampleInputLines(string input, int expected) {
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
		var input = "987654321111111\n811111111111119\n234234234234278\n818181911112111";

		var solver = new Task1Solver();

		// Act
		var result = solver.Solve(input);

		// Assert
		Assert.Equal(357, result);
	}

	[Fact]
	public void Task1_PuzzleInput() {
		var input = File.ReadAllText("input.txt");

		var solver = new Task1Solver();
		var result = solver.Solve(input);

		output.WriteLine(result.ToString());
	}
}
