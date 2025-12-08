using PageReplacementAlgorithms.Result;

namespace PageReplacementAlgorithms.Algorithms;

public class FifoAlgorithm(string stringReference, int numberOfFrames) : Algorithm(stringReference, numberOfFrames)
{
    private readonly Queue<int> _memory = new();
    private readonly HashSet<int> _memorySet = [];

    public override AlgorithmResult Run()
    {
        var pages = GetPagesFromStringReference();
        
        foreach (var page in pages)
           ProcessPage(page);

        return new AlgorithmResult(_memory.ToList(), PageFaults);
    }

    protected override void ProcessPage(int page)
    {
        if (IsPageHit(page))
            return;
        
        IncreasePageFaults();

        if (_memory.Count == NumberOfFrames)
            RemovePageFromMemory(page);
        
        AddPageToMemory(page);
    }

    protected override void AddPageToMemory(int page)
    {
        _memory.Enqueue(page);
        _memorySet.Add(page);
    }

    protected override void RemovePageFromMemory(int page)
    {
        var removed = _memory.Dequeue();
        _memorySet.Remove(removed);
    }

    protected override bool IsPageHit(int page)
    {
        return _memorySet.Contains(page); // Using hashset for O(1) lookup
    }
    
}