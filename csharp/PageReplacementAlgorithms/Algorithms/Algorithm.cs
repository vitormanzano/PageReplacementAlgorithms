using System.Collections;
using PageReplacementAlgorithms.Result;

namespace PageReplacementAlgorithms.Algorithms;

public abstract class Algorithm(string stringReference, int numberOfFrames)
{
    private string StringReference { get; } = ValidateStringReference(stringReference);
    protected int NumberOfFrames { get; } = ValidateNumberOfFrames(numberOfFrames);
    protected int PageFaults { get; private set; } = 0;

    public abstract AlgorithmResult Run();
    protected abstract void ProcessPage(int page);
    protected abstract void AddPageToMemory(int page);
    protected abstract void RemovePageFromMemory(int page);
    protected abstract bool IsPageHit(int page);
    protected abstract List<int> SnapshotMemory();
    
    
    private static string ValidateStringReference(string stringReference)
    {
        return string.IsNullOrEmpty(stringReference) 
            ? throw new ArgumentException("String reference must be a non-empty string")
            : stringReference;
    }
    
    private static int ValidateNumberOfFrames(int numberOfFrames)
    {
        return numberOfFrames <= 0
            ? throw new ArgumentException("Number of frames must be greathen than zero")
            : numberOfFrames;
    }

    protected int[] GetPagesFromStringReference()
    {
        return StringReference
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(p => !int.TryParse(p.Trim(), out var page) 
                ? throw new ArgumentException($"Invalid page number: {p} in string reference")
                : page)
            .ToArray();
    }
    
    protected void IncreasePageFaults() => PageFaults++;
}