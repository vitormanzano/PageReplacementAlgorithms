namespace PageReplacementAlgorithms.Result;

public record AlgorithmResult(List<int> MemoryState, int PageFaults)
{
    public override string ToString()
    {
        return $"Memory State: {string.Join(", ", MemoryState)} \n Page Faults: {PageFaults}";
    }
}
    