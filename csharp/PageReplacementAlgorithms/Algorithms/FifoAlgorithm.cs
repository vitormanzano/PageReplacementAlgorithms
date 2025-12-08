using System.Collections;
using PageReplacementAlgorithms.Result;

namespace PageReplacementAlgorithms.Algorithms;

public class FifoAlgorithm(string stringReference, int numberOfFrames) : Algorithm(stringReference, numberOfFrames)
{
    private readonly List<List<int>> _steps = [];
    private readonly Queue<int> _memory = new();
    private readonly HashSet<int> _memorySet = [];

    public override AlgorithmResult Run()
    {
        var pages = GetPagesFromStringReference();
        
        foreach (var page in pages)
           ProcessPage(page);

        return new AlgorithmResult(_steps, PageFaults);
    }

    protected override void ProcessPage(int page)
    {
        if (IsPageHit(page))
        {
            _steps.Add(SnapshotMemory());
            return;
        }
        
        IncreasePageFaults();

        if (_memory.Count == NumberOfFrames)
            RemovePageFromMemory(page);
        
        AddPageToMemory(page);
        
        _steps.Add(SnapshotMemory());
    }

    protected override void AddPageToMemory(int page)
    {
        _memory.Enqueue(page);
        _memorySet.Add(page);
    }

    protected override void RemovePageFromMemory(int page)
    {
        _memory.Dequeue();
        _memorySet.Remove(page);
    }

    protected override bool IsPageHit(int page)
    {
        return _memorySet.Contains(page); // Using hashset for O(1) lookup
    }

    protected override List<int> SnapshotMemory()
    {
        return [.._memory];
    }
}