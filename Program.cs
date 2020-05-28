using System;
using System.Collections.Generic;
using System.IO;

namespace ExactCoverSudoku
{
    // https://www.ocf.berkeley.edu/~jchu/publicportal/sudoku/0011047.pdf
    // Dancing Links Donald E. Knuth, Stanford University
    class Program
    {
        static void Main(string[] args)
        { 
            int[] sudokuGrid = SudokuReader.readGrid("./TestProblems/sudokuprufa2.txt");
            Solver.solve(sudokuGrid);
            //Node dlxRoot = new DLXSudokuReducer(sudokuGrid).Root; 
            //SimpleDLX dlx = new SimpleDLX(); 
            //List<Node> solutions = new List<Node>();
            Console.WriteLine("búið");
        }
    }
}
