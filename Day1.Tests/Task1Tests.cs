using Xunit.Abstractions;

namespace Day1.Tests;

public class Task1Tests(
	ITestOutputHelper output
) {

	[Fact]
	public void Task1_ExampleInput() {
		// Arrange
		var input = "L68\nL30\nR48\nL5\nR60\nL55\nL1\nL99\nR14\nL82";

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
