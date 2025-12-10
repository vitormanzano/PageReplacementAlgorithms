using PageReplacementAlgorithms.Result;

namespace PageReplacementAlgorithms.Algorithms;

/// <summary>
/// Class <c>LruAlgorithm</c>
/// Implements the Least Recently Used (LRU) algorithm
/// </summary>
public class LruAlgorithm(string stringReference, int numberOfFrames) : Algorithm(stringReference, numberOfFrames)
{
    private readonly LinkedList<int> _memory = [];
    
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
            return;
        }
        
        IncreasePageFaults();
        
        if (_memory.Count == NumberOfFrames)
            RemoveFirstPageFromMemory();
        
        AddPageToMemory(page);
    }

    protected override void AddPageToMemory(int page)
    {
        _memory.AddLast(page);
    }

    protected override void RemovePageFromMemory(int page)
    {
        _memory.Remove(page);
    }
    
    private void RemoveFirstPageFromMemory() => _memory.RemoveFirst();

    protected override bool IsPageHit(int page)
    {
        return _memory.Contains(page);
    }
}