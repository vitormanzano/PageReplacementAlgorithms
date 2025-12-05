using PageReplacementAlgorithms.Result;

namespace PageReplacementAlgorithms.Algorithms;

public abstract class Algorithm 
{
    public string StringReference { get; private set; }
    public int NumberOfFrames { get; private set; }
    public int PageFaults { get; protected set; }
    protected List<int> MemoryState;

    protected Algorithm(string stringReference, int numberOfFrames)
    {
        SetStringReference(stringReference);
        SetNumberOfFrames(numberOfFrames);
        MemoryState = [];
        PageFaults = 0;
    }
    
    public abstract AlgorithmResult Run();

    private void SetStringReference(string stringReference)
    {
        ValidateStringReference(stringReference);
        StringReference = stringReference;
    }
    
    private static void ValidateStringReference(string stringReference)
    {
        if (string.IsNullOrEmpty(stringReference)) 
            throw new ArgumentException("String reference must be a non-empty string");
    }
    
    private void SetNumberOfFrames(int numberOfFrames)
    {
        ValidateNumberOfFrames(numberOfFrames);
        NumberOfFrames = numberOfFrames;
    }

    private static void ValidateNumberOfFrames(int numberOfFrames)
    {
        if (numberOfFrames <= 0) 
            throw new ArgumentException("Number of frames must be a positive integer");
    }

    protected int[] GetPagesFromStringReference(string stringReference)
    {
        var parts = stringReference.Split(',');
        
        var pages = parts
            .Select(p => int.Parse(p.Trim()))
            .ToArray();
        return pages;
    }
}