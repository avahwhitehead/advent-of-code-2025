using Xunit.Abstractions;

namespace Day2.Tests;

public class Task1Tests(
	ITestOutputHelper output
) {

	[Fact]
	public void Task1_ExampleInput() {
		// Arrange
		var input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,\n1698522-1698528,446443-446449,38593856-38593862,565653-565659,\n824824821-824824827,2121212118-2121212124";

		var solver = new Task1Solver();

		// Act
		var result = solver.Solve(input);

		// Assert
		Assert.Equal(1227775554, result);
	}

	[Fact]
	public void Task1_PuzzleInput() {
		var input = File.ReadAllText("input.txt");

		var solver = new Task1Solver();
		var result = solver.Solve(input);

		output.WriteLine(result.ToString());
	}
}
