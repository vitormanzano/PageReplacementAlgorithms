using PageReplacementAlgorithms.Result;

namespace PageReplacementAlgorithms.Algorithms;

public class FifoAlgorithm(string stringReference, int numberOfFrames) : Algorithm(stringReference, numberOfFrames)
{
    public override AlgorithmResult Run()
    {
        var pages = GetPagesFromStringReference(StringReference);
        foreach (var page in pages)
        {
           if (IsPageHit(page))
                continue;
           
           IncreasePageFaults();
            
            if (MemoryState.Count == NumberOfFrames)
                RemovePage();

            AddNewPage(page);
        }

        return new AlgorithmResult(MemoryState, PageFaults);
    }

    private void AddNewPage(int pageNumber)
    {
        MemoryState.Add(pageNumber);
    }

    private void RemovePage()
    {
        MemoryState.RemoveAt(0);
    }
}