using PageReplacementAlgorithms.Result;

namespace PageReplacementAlgorithms.Algorithms;

/// <summary>
/// Class <c>LruAlgorithm</c>
/// Implements the Least Recently Used (LRU) algorithm
/// </summary>
public class LruAlgorithm(string stringReference, int numberOfFrames) : Algorithm(stringReference, numberOfFrames)
{
    private readonly HashSet<int> _memory = [];
    
    public override AlgorithmResult Run()
    {
        var pages = GetPagesFromStringReference();

        foreach (var page in pages)
        {
            ProcessPage(page);
        }
        
        return new AlgorithmResult(_memory.ToList(), PageFaults);
    }

    protected override void ProcessPage(int page)
    {
        if (IsPageHit(page))
        {
            RemovePageFromMemory(page);
            AddPageToMemory(page);
        }
        
        IncreasePageFaults();
        
        if (_memory.Count == NumberOfFrames)
            RemovePageFromMemory(page);
        
        AddPageToMemory(page);
    }

    protected override void AddPageToMemory(int page)
    {
        _memory.Add(page);
    }

    protected override void RemovePageFromMemory(int page)
    {
        _memory.Remove(page);
    }

    protected override bool IsPageHit(int page)
    {
        return _memory.Contains(page);
    }
}