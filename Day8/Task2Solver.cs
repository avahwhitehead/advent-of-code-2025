namespace Day8;

public class Task2Solver
{
	public int Solve(string input) {
		var coordinates = input
			.Trim()
			.Split('\n', StringSplitOptions.RemoveEmptyEntries)
			.Select(l => l.Trim())
			.Select(XyzCoordinate.Parse)
			.ToArray();

		List<HashSet<XyzCoordinate>> allChains = coordinates.Select(c => new HashSet<XyzCoordinate> { c }).ToList();

		foreach (var closestPair in FindClosestPairs(coordinates)) {
			var containingChainPoint1 = allChains.FirstOrDefault(c => c.Contains(closestPair.Point1));
			var containingChainPoint2 = allChains.FirstOrDefault(c => c.Contains(closestPair.Point2));

			if (containingChainPoint1 == null && containingChainPoint2 == null) {
				// If the closest pair is not contained in any chain, create a new chain
				allChains.Add([closestPair.Point1, closestPair.Point2]);
			}
			else if (containingChainPoint1 != null && containingChainPoint2 != null) {
				// If both closest points are in different chains
				// Merge the two chains
				if (containingChainPoint1 != containingChainPoint2) {
					// Merge the two chains since they are connected
					containingChainPoint1.UnionWith(containingChainPoint2);
					allChains.Remove(containingChainPoint2);
				}
			}
			else {
				// Exactly one point exists in a chain, so add the other point to the chain
				var singleValidChain = (containingChainPoint1 ?? containingChainPoint2)!;
				singleValidChain.Add(closestPair.Point1);
				singleValidChain.Add(closestPair.Point2);
			}

			if (allChains.Count == 1) {
				return closestPair.Point1.X * closestPair.Point2.X;
			}
		}

		throw new InvalidOperationException("No chain was found");
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
