namespace Day2.Tools;

public class Range {
	public long Start { get; init; }

	public long End { get; init; }

	public IEnumerable<long> Enumerate() {
		for (var i = Start; i <= End; i++) {
			yield return i;
		}
	}
}
