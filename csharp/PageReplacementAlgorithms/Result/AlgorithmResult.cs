namespace PageReplacementAlgorithms.Result;

public record AlgorithmResult(Queue<int> FinalMemoryState, int TotalPageFaults)
{
}
    