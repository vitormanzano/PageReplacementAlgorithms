using PageReplacementAlgorithms.Algorithms;

string stringReference = "7, 0, 1, 2, 0, 3, 0, 4, 2, 3, 0, 3, 2, 1, 2, 0, 1, 7, 0, 1";

FifoAlgorithm fifo = new FifoAlgorithm(stringReference, 3);
var result = fifo.Run();

Console.WriteLine(result);
