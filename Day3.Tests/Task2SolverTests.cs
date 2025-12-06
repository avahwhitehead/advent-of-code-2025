using Xunit.Abstractions;

namespace Day3.Tests;

public class Task2Tests(
	ITestOutputHelper output
) {
	[Theory]
	[InlineData("987654321111111", 987654321111L)]
	[InlineData("811111111111119", 811111111119L)]
	[InlineData("234234234234278", 434234234278L)]
	[InlineData("818181911112111", 888911112111L)]
	public void Task2_ExampleInputLines(string input, long expected) {
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
		var input = "987654321111111\n811111111111119\n234234234234278\n818181911112111";

		var solver = new Task2Solver();

		// Act
		var result = solver.Solve(input);

		// Assert
		Assert.Equal(3121910778619, result);
	}

	[Fact]
	public void Task2_PuzzleInput() {
		var input = File.ReadAllText("input.txt");

		var solver = new Task2Solver();
		var result = solver.Solve(input);

		output.WriteLine(result.ToString());
	}
}
