using PageReplacementAlgorithms.Algorithms;

namespace PageReplacementAlgorithmsTest;

public class LruAlgorithmTest
{
    [Fact]
    public void ShouldNotRunIfStringReferenceIsNullOrEmpty()
    {
        var stringReference = "";
        
        
        var ex = Assert
            .Throws<ArgumentException>(() => new LruAlgorithm(stringReference, 10));
        
        Assert.Equal("String reference must be a non-empty string", ex.Message);
        
        stringReference = null;
        
        ex = Assert
            .Throws<ArgumentException>(() => new LruAlgorithm(stringReference, 2));
        
        Assert.Equal("String reference must be a non-empty string", ex.Message);
    }
    
    [Fact]
    public void ShouldNotRunIfNumberOfFramesIsLessThanOne()
    {
        var ex = Assert
            .Throws<ArgumentException>(() => new LruAlgorithm("1, 2, 3", 0));
        
        Assert.Equal("Number of frames must be greater than zero", ex.Message);
    }
    
    [Fact]
    public void ShouldRunLruAlgorithmWith3Frames()
    {
        var expectedMemoryState = new[] { 3, 6, 2 };
        const int expectedPageFaults = 15;
        
        var lru = new LruAlgorithm("1, 2, 3, 4, 2, 1, 5, 6, 2, 1, 2, 3, 7, 6, 3, 2, 1, 2, 3, 6", 3);
        
        var result = lru.Run();
        
        Assert.Equal(expectedPageFaults, result.TotalPageFaults);
        Assert.All(expectedMemoryState, item =>
            Assert.Contains(item, result.FinalMemoryState));
    }
    
    [Fact]
    public void ShouldRunLruAlgorithmWith4Frames()
    {
        var expectedMemoryState = new[] { 3, 1, 6, 2 };
        const int expectedPageFaults = 10;
        
        var lru = new LruAlgorithm("1, 2, 3, 4, 2, 1, 5, 6, 2, 1, 2, 3, 7, 6, 3, 2, 1, 2, 3, 6", 4);
        
        var result = lru.Run();
        
        Assert.Equal(expectedPageFaults, result.TotalPageFaults);
        Assert.All(expectedMemoryState, item =>
            Assert.Contains(item, result.FinalMemoryState));
    }
    
    [Fact]
    public void ShouldRunFifoAlgorithmWith5Frames()
    {
        var expectedMemoryState = new[] { 3, 1, 6, 2, 7};
        const int expectedPageFaults = 8;
        
        var lru = new LruAlgorithm("1, 2, 3, 4, 2, 1, 5, 6, 2, 1, 2, 3, 7, 6, 3, 2, 1, 2, 3, 6", 5);
        
        var result = lru.Run();
        
        Assert.Equal(expectedPageFaults, result.TotalPageFaults);
        Assert.All(expectedMemoryState, item =>
            Assert.Contains(item, result.FinalMemoryState));
    }
}