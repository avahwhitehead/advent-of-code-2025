using Xunit.Abstractions;

namespace Day8.Tests;

public class Task1Tests(
	ITestOutputHelper output
) {
	[Fact]
	public void Task1_ExampleInput() {
		// Arrange
		var input = @"
162,817,812
57,618,57
906,360,560
592,479,940
352,342,300
466,668,158
542,29,236
431,825,988
739,650,466
52,470,668
216,146,977
819,987,18
117,168,530
805,96,715
346,949,466
970,615,88
941,993,340
862,61,35
984,92,344
425,690,689
		";

		var solver = new Task1Solver();

		// Act
		var result = solver.Solve(input, 10);

		// Assert
		Assert.Equal(40, result);
	}

	[Fact]
	public void Task1_PuzzleInput() {
		var input = File.ReadAllText("input.txt");

		var solver = new Task1Solver();
		var result = solver.Solve(input, 1000);

		output.WriteLine(result.ToString());
	}
}
