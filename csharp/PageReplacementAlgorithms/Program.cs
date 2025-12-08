using PageReplacementAlgorithms.Algorithms;

const string stringReference = "1, 2, 3, 4, 2, 1, 5, 6, 2, 1, 2, 3, 7, 6, 3, 2, 1, 2, 3, 6";

var fifo = new FifoAlgorithm(stringReference, 4);
var result = fifo.Run();


Console.WriteLine(result);
