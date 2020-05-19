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
            Node c = dlx.Root.Right;
            cover(c);
            Console.WriteLine(dlx.Root.Right.Right.Right.Down.ID);
            uncover(c);
            Console.WriteLine(dlx.Root.Right.Right.Right.Down.ID);
            

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

        public void algorithmX()
        {
            
        }

        private static void cover(Node columnObject)
        {
            columnObject.Left.Right = columnObject.Right;
            columnObject.Right.Left = columnObject.Left;

            Node c = columnObject.Down;
            Node r = c.Right;

            

            while(!isSame(c, columnObject))
            {
                while(!isSame(r,c))
                {
                    r.Up.Down = r.Down;
                    r.Down.Up = r.Up;
                    
                    r = r.Right;
                }
                           
                c = c.Down;
                r = c.Right;  
            }
        }

        private static void uncover(Node columnObject)
        {
            Node c = columnObject.Up;
            Node r = c.Left;

            while(!isSame(c,columnObject))
            {
                while(!isSame(r,c))
                {
                    r.Up.Down = r;
                    r.Down.Up = r;

                    r = r.Left;
                }

                c = c.Up;
                r = c.Left;
            }

            columnObject.Left.Right = columnObject;
            columnObject.Right.Left = columnObject;
        }

        private static bool isSame(Node node1, Node node2)
        {
            return Object.ReferenceEquals(node1,node2);
        }
    }
}
