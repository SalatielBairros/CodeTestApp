using System;

namespace CodeTestApp.Eldorado
{
    public class MineCounter
    {
        public static void MainT()
        {
            string input = Console.ReadLine();

            // The first line is the size of the matrix
            var matrixSize = int.Parse(input);

            // Matrix with the given size
            var matrix = new int[matrixSize, matrixSize];

            // Foreach N line we have N columns separated by space
            for (var i = 0; i < matrixSize; i++)
            {
                var consoleLine = Console.ReadLine().Split(' ');
                for (var j = 0; j < consoleLine.Length; j++)
                    matrix[i, j] = int.Parse(consoleLine[j]);
            }

            // Here the "matrix" should have the input formatted as a two-dimensional array
            var result = new int[matrixSize, matrixSize];
            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    var rColumn = (j + 1 == matrixSize ? j : j + 1);
                    var lColumn = (j == 0 ? 0 : j - 1);
                    var tRow = (i == 0 ? 0 : i - 1);
                    var bRow = (i + 1 == matrixSize ? i : i + 1);

                    for (var x = tRow; x < bRow; x++)
                    {
                        for (var y = lColumn; y < rColumn; y++)
                        {
                            if (y != j && x != i && matrix[x, y] == 1)
                                result[i, j]++;
                        }
                    }
                }
            }

            // Example of printing the result matrix

            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                    Console.Write(j < matrixSize - 1 ? "{0} " : "{0}", result[i, j]);
                Console.WriteLine();
            }
        }
    }
}
