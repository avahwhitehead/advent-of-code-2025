using Xunit.Abstractions;

namespace Day1.Tests;

public class Task2Tests(
	ITestOutputHelper output
) {

	[Fact]
	public void Task2_ExampleInput() {
		// Arrange
		var input = "L68\nL30\nR48\nL5\nR60\nL55\nL1\nL99\nR14\nL82";

		var solver = new Task2Solver();

		// Act
		var result = solver.Solve(input);

		// Assert
		Assert.Equal(6, result);
	}

	[Fact]
	public void Task2_PuzzleInput() {
		var input = File.ReadAllText("input.txt");

		var solver = new Task2Solver();
		var result = solver.Solve(input);

		output.WriteLine(result.ToString());
	}
}
