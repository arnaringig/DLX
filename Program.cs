using System;
using System.Collections.Generic;
using System.IO;
namespace ExactCoverSudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] sudokuGrid = SudokuReader.readGrid("sudokuprufa4by4.txt");
            Node dlxRoot = new DLXSudokuReducer(sudokuGrid).Root; 
            //Console.WriteLine(dlxRoot.Left.Right.ID); 
            //Node prufa = dlxRoot;
            //SimpleDLX dlx = new SimpleDLX(); 
            List<Node> solutions = new List<Node>();
            //Node c = dlx.Root.Right;
            
            /*for(int i = 0;i<10;i++)
            {
                prufa = prufa.Right;
                Console.WriteLine(prufa.ID);
            }*/
            //Console.WriteLine(prufa.Down.RowData.Val);
            //Console.WriteLine(prufa.Down.Down.Tag);
            algorithmX(dlxRoot,solutions);
            Console.WriteLine("búið");
            //Console.WriteLine(dlxRoot.Left.Left.ID);

            
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
            //Console.WriteLine(root.Right.ID);
            //Environment.Exit(1);
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
                Environment.Exit(1);
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
