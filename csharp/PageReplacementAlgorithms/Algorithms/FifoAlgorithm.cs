using PageReplacementAlgorithms.Result;

namespace PageReplacementAlgorithms.Algorithms;

public class FifoAlgorithm(string stringReference, int numberOfFrames) : Algorithm(stringReference, numberOfFrames)
{
    public override AlgorithmResult Run()
    {
        var pages = GetPagesFromStringReference(StringReference);
        foreach (var page in pages)
        {
            var HasPage = VerifyIfIsPageFault(page);
            if (HasPage)
                continue;
            
            if (MemoryState.Count == NumberOfFrames)
            {
                RemovePage();
            }

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

    private void IncreasePageFaults()
    {
        PageFaults++;
    }

    private bool VerifyIfIsPageFault(int pageNumber)
    {
        if (MemoryState.Contains(pageNumber)) 
            return true;
        
        IncreasePageFaults();
        return false;
    }
}