using Xunit.Abstractions;

namespace Day2.Tests;

public class Task2Tests(
	ITestOutputHelper output
) {
	[Fact]
	public void Task2_ExampleInput() {
		// Arrange
		var input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,\n1698522-1698528,446443-446449,38593856-38593862,565653-565659,\n824824821-824824827,2121212118-2121212124";

		var solver = new Task2Solver();

		// Act
		var result = solver.Solve(input);

		// Assert
		Assert.Equal(4174379265, result);
	}

	[Theory]
	[InlineData("11-22", 11 + 22)]
	[InlineData("95-115", 99 + 111)]
	[InlineData("998-1012", 999 + 1010)]
	[InlineData("1188511880-1188511890", 1188511885)]
	[InlineData("222220-222224", 222222)]
	[InlineData("1698522-1698528", 0)]
	[InlineData("446443-446449", 446446)]
	[InlineData("38593856-38593862", 38593859)]
	[InlineData("565653-565659", 565656)]
	[InlineData("824824821-824824827", 824824824)]
	[InlineData("2121212118-2121212124", 2121212121)]
	public void Task2_ExampleInput2(string input, long expected) {

		var solver = new Task2Solver();

		// Act
		var result = solver.Solve(input);

		// Assert
		Assert.Equal(expected, result);
	}

	[Fact]
	public void Task2_PuzzleInput() {
		var input = File.ReadAllText("input.txt");

		var solver = new Task2Solver();
		var result = solver.Solve(input);

		output.WriteLine(result.ToString());
	}
}
