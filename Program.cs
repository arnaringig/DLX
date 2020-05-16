using System;
using System.IO;
namespace ExactCoverSudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //int[] sudokuGrid = SudokuReader.readGrid("sudokuprufaempty.txt");
            //Node dlxRoot = new DLXSudokuReducer(sudokuGrid).Root; 
            //Console.WriteLine(Object.ReferenceEquals(dlxRoot,dlxRoot.Left.Right));
            SimpleDLX dlx = new SimpleDLX(); 
            Console.WriteLine(dlx.Root.Right.Down.Down.Right.Up.Right.Right.ID);        
        }
    }
}
