namespace PageReplacementAlgorithms.Result;

public record AlgorithmResult(ICollection<int> FinalMemoryState, int TotalPageFaults)
{
}
    