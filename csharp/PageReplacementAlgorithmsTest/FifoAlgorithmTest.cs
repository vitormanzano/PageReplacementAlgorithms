using PageReplacementAlgorithms.Algorithms;

namespace PageReplacementAlgorithmsTest;

public class FifoAlgorithmTest
{
    [Fact]
    public void ShouldNotRunIfStringReferenceIsNullOrEmpty()
    {
        var stringReference = "";
        
        
        var ex = Assert
            .Throws<ArgumentException>(() => new FifoAlgorithm(stringReference, 10));
        
        Assert.Equal("String reference must be a non-empty string", ex.Message);
        
        stringReference = null;
        
        ex = Assert
            .Throws<ArgumentException>(() => new FifoAlgorithm(stringReference, 2));
        
        Assert.Equal("String reference must be a non-empty string", ex.Message);
    }
    
    [Fact]
    public void ShouldNotRunIfNumberOfFramesIsLessThanOne()
    {
        var ex = Assert
            .Throws<ArgumentException>(() => new FifoAlgorithm("1, 2, 3", 0));
        
        Assert.Equal("Number of frames must be greater than zero", ex.Message);
    }
    
    [Fact]
    public void ShouldRunFifoAlgorithmWith3Frames()
    {
        var expectedMemoryState = new[] { 3, 1, 6 };
        const int expectedPageFaults = 16;
        
        var fifo = new FifoAlgorithm("1, 2, 3, 4, 2, 1, 5, 6, 2, 1, 2, 3, 7, 6, 3, 2, 1, 2, 3, 6", 3);
        
        var result = fifo.Run();
        
        Assert.Equal(expectedPageFaults, result.TotalPageFaults);
        Assert.All(expectedMemoryState, item =>
            Assert.Contains(item, result.FinalMemoryState));
    }
    
    [Fact]
    public void ShouldRunFifoAlgorithmWith4Frames()
    {
        var expectedMemoryState = new[] { 3, 1, 6, 2 };
        const int expectedPageFaults = 14;
        
        var fifo = new FifoAlgorithm("1, 2, 3, 4, 2, 1, 5, 6, 2, 1, 2, 3, 7, 6, 3, 2, 1, 2, 3, 6", 4);
        
        var result = fifo.Run();
        
        Assert.Equal(expectedPageFaults, result.TotalPageFaults);
        Assert.All(expectedMemoryState, item =>
            Assert.Contains(item, result.FinalMemoryState));
    }
    
    [Fact]
    public void ShouldRunFifoAlgorithmWith5Frames()
    {
        var expectedMemoryState = new[] { 3, 1, 6, 2, 7};
        const int expectedPageFaults = 10;
        
        var fifo = new FifoAlgorithm("1, 2, 3, 4, 2, 1, 5, 6, 2, 1, 2, 3, 7, 6, 3, 2, 1, 2, 3, 6", 5);
        
        var result = fifo.Run();
        
        Assert.Equal(expectedPageFaults, result.TotalPageFaults);
        Assert.All(expectedMemoryState, item =>
            Assert.Contains(item, result.FinalMemoryState));
    }
}