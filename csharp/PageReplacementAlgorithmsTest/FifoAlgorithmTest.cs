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
}