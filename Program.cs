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
            int[] sudokuGrid = SudokuReader.readGrid("sudokuprufa2.txt");
            Node dlxRoot = new DLXSudokuReducer(sudokuGrid).Root; 
            //SimpleDLX dlx = new SimpleDLX(); 
            List<Node> solutions = new List<Node>();

            algorithmX(dlxRoot,solutions);
            Console.WriteLine("búið");
        }

        public static void algorithmX(Node root, List<Node> solutions)
        {

            if(root == root.Right)
            {
                Console.WriteLine("kLÁRAR");
                foreach(Node row in solutions )
                {
                    Node temp = row;
                    Console.Write(temp.RowData.Val+1 + " ");
                    //Console.Write(temp.ID + " ");
                    /*while(temp.Right != row)
                    {
                        Console.Write(temp.Right.ID + " ");
                        
                        temp = temp.Right;
                    }*/
                    Console.WriteLine();
                }
                return;
            } 

            Node columnObject = chooseNextColumnInLine(root);
            Node firstInRow  = columnObject.Down;
            Node rowObject = firstInRow.Right;
            cover(columnObject);

            while(firstInRow != columnObject)
            {
                solutions.Add(firstInRow);
               
                while(rowObject != firstInRow)
                {
                
                    cover(rowObject.ColNode);
                    rowObject = rowObject.Right;
                }
                
                algorithmX(root,solutions);
                
                solutions.RemoveAt(solutions.Count - 1);

                rowObject = firstInRow.Left;
                while(rowObject != firstInRow)
                {
                    uncover(rowObject.ColNode);
                    rowObject = rowObject.Left;
                }

                firstInRow = firstInRow.Down;
                rowObject  = firstInRow.Right;               

            }
            uncover(columnObject);
        }

        private static Node chooseSmallestSizeColumn(Node root)
        { 
            Node columnObject = root.Right;
            Node smallestColumn = columnObject;
            while(columnObject.Right != root)
            {
                if(columnObject.Size > columnObject.Right.Size )
                {
                    smallestColumn = columnObject.Right;
                }
                columnObject = columnObject.Right;
            }

            return smallestColumn;
        }

        private static Node chooseNextColumnInLine(Node root)
        {
            return root.Right;
        }

        private static void cover(Node columnObject)
        {
            
            columnObject.Right.Left = columnObject.Left;
            columnObject.Left.Right = columnObject.Right;
             
            Node firstInRow = columnObject.Down;

            Node rowObject  = firstInRow.Right;
  
            while(firstInRow != columnObject)
            {
                
                while(rowObject != firstInRow)
                {
                    rowObject.Up.Down = rowObject.Down;
                    rowObject.Down.Up = rowObject.Up;
                    
                    rowObject = rowObject.Right;
                }
                           
                firstInRow = firstInRow.Down;
                rowObject  = firstInRow.Right;  
            }
        }

        private static void uncover(Node columnObject)
        {
            Node firstInRow = columnObject.Up;
            Node rowObject = firstInRow.Left;

            while(firstInRow != columnObject)
            {
                while(rowObject != firstInRow)
                {
                    rowObject.Up.Down = rowObject;
                    rowObject.Down.Up = rowObject;

                    rowObject = rowObject.Left;
                }

                firstInRow = firstInRow.Up;
                rowObject = firstInRow.Left;
            }

            columnObject.Left.Right = columnObject;
            columnObject.Right.Left = columnObject;
        }
    }
}
