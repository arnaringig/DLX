/*
    Written and created by Arnar Ingi Gunnarsson 
    Github: arnaringig
*/

using System;
using System.IO;
namespace ExactCoverSudoku
{
    public class SudokuReader
    {
        public static int[] readGrid(String fileName) // static since we won´t really need to instantiate SudokuReader
        {   
            String sudokugridString = File.ReadAllText(fileName); // First we read the grid string from the text file           
            int[] sudokugrid = new int[sudokugridString.Length]; // Then we convert the string to an array of integers
          
            for ( int i = 0; i < sudokugridString.Length-1; i++ ) {
                int cellValue = (int)Char.GetNumericValue(sudokugridString[i]);
                sudokugrid[i] = cellValue;
            } 
            return sudokugrid;
        }
    }
}