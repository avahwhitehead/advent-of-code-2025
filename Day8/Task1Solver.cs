namespace Day8;

public class Task1Solver
{
	public int Solve(string input, int iterations) {
		var coordinates = input
			.Trim()
			.Split('\n', StringSplitOptions.RemoveEmptyEntries)
			.Select(l => l.Trim())
			.Select(XyzCoordinate.Parse)
			.ToArray();

		var chains = new List<HashSet<XyzCoordinate>>();
		var closestPairs = new HashSet<CoordinateDistance>();

		foreach (var closestPair in FindClosestPairs(coordinates)) {
			if (closestPairs.Count == iterations) break;

			closestPairs.Add(closestPair);

			var containingChainPoint1 = chains.FirstOrDefault(c => c.Contains(closestPair.Point1));
			var containingChainPoint2 = chains.FirstOrDefault(c => c.Contains(closestPair.Point2));

			// If the closest pair is not contained in any chain, create a new chain
			if (containingChainPoint1 == null && containingChainPoint2 == null) {
				chains.Add([closestPair.Point1, closestPair.Point2]);
				continue;
			}

			// If both closest points are in different chains
			// Merge the two chains
			if (containingChainPoint1 != null && containingChainPoint2 != null) {
				if (containingChainPoint1 != containingChainPoint2) {
					// Merge the two chains since they are connected
					containingChainPoint1.UnionWith(containingChainPoint2);
					chains.Remove(containingChainPoint2);
				}
				continue;
			}

			// Exactly one point exists in a chain, so add the other point to the chain
			var singleValidChain = (containingChainPoint1 ?? containingChainPoint2)!;
			singleValidChain.Add(closestPair.Point1);
			singleValidChain.Add(closestPair.Point2);
		}

		return chains
			.Select(c => c.Count)
			.OrderByDescending(x => x)
			.Take(3)
			.Aggregate(1, (acc, x) => acc * x);
	}

	private IEnumerable<CoordinateDistance> FindClosestPairs(IEnumerable<XyzCoordinate> points) {
		var pointsList = points.ToList();

		var pointDistances = pointsList
			.SelectMany(p1 => pointsList
				.Where(p2 => !Equals(p1, p2))
				.Select(p2 => new CoordinateDistance {
					Point1 = p1,
					Point2 = p2,
					Distance = p1.DistanceTo(p2)
				})
			)
			.OrderBy(p => p.Distance);

		return pointDistances;
	}
}
