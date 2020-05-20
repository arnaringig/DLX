using System;
using System.Collections.Generic;
using System.IO;
namespace ExactCoverSudoku
{
    class Program
    {
        // ATH VILJUM PRUFA AÐ OVERLOADA == OPERATORINN FYRIR NODES
        // SVO VIÐ ÞURFUM KANNSKI EKKI ISSAME FALLIÐ!!!
        static void Main(string[] args)
        {
            
            //int[] sudokuGrid = SudokuReader.readGrid("sudokuprufaempty.txt");
            //Node dlxRoot = new DLXSudokuReducer(sudokuGrid).Root; 
            //Console.WriteLine(Object.ReferenceEquals(dlxRoot,dlxRoot.Left.Right));
            
            SimpleDLX dlx = new SimpleDLX(); 
            List<Node> solutions = new List<Node>();
            Node c = dlx.Root.Right;
            
            
            
            algorithmX(dlx.Root,solutions);

            //Console.WriteLine(dlx.Root.Right.Right.Right.Right.ID);

            
  
            //   h -  A  -  B  -  C  -  D  -  E  -  F  -  G         <= Column Objects
            //        |     |     |     |     |     |     |
            //        |  -  |  -  C1 -  |  -  E1 -  F1 -  |
            //        |     |     |     |     |     |     |
            //        A2 -  |  -  |  -  D2 -  |  -  |  -  G2
            //        |     |     |     |     |     |     | 
            //        |  -  B3 -  C3 -  |  -  |  -  F3 -  |
            //        |     |     |     |     |     |     |
            //        A4 -  |  -  |  -  D4 -  |  -  |  -  |
            //        |     |     |     |     |     |     |
            //        |  -  B5 -  |  -  |  -  |  -  |  -  G5
            //        |     |     |     |     |     |     |          
            //        |  -  |  -  |  -  D6 -  E6 -  |  -  G6

        }



        public static void algorithmX(Node root, List<Node> solutions)
        {
            if(root == root.Right)
            {
                foreach(Node row in solutions )
                {
                    Node temp = row;
                    Console.Write(temp.ID + " ");
                    while(temp.Right != row)
                    {
                        Console.Write(temp.Right.ID + " ");
                        
                        temp = temp.Right;
                    }
                    
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
                    //Console.WriteLine(rowObject.ID);
                    cover(rowObject.Col);
                    rowObject = rowObject.Right;
                }
                
                algorithmX(root,solutions);
                
                solutions.RemoveAt(solutions.Count - 1);

                rowObject = firstInRow.Left;
                while(rowObject != firstInRow)
                {
                    //Console.WriteLine(rowObject.ID);
                    uncover(rowObject.Col);
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
            columnObject.Left.Right = columnObject.Right;
            columnObject.Right.Left = columnObject.Left;

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
            // Breyta nafninu á c og r eins og uppi í eitthvað viðeigandi.
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
