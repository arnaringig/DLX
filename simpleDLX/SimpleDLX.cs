/*
    Written and created by Arnar Ingi Gunnarsson 
    Github: arnaringig
*/


// THIS IS THE SMALL EXAMPLE GRID USED IN DONALD KNUTH´S PAPER
// TO DEMONSTRATE ALGORITHM X
// Each node is a linked list objct with 4 connections, up, down, left and right

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


using System;
namespace ExactCoverSudoku 
{
    public class SimpleDLX
    {
        private Node root = new Node("root","Root");


        public SimpleDLX()
        {
            createDLX(root);
            
        }

        private void createDLX(Node root)
        {
            Node A = new Node("A","Column");
            Node B = new Node("B","Column");
            Node C = new Node("C","Column");
            Node D = new Node("D","Column");
            Node E = new Node("E","Column");
            Node F = new Node("F","Column");
            Node G = new Node("G","Column");

            A.Size = 2;
            B.Size = 2;
            C.Size = 2;
            D.Size = 3;
            E.Size = 2;
            F.Size = 2;
            G.Size = 3;

            root.Right = A;
            A.Right    = B;
            B.Right    = C;
            C.Right    = D;
            D.Right    = E;
            E.Right    = F;
            F.Right    = G;
            G.Right    = root;

            root.Left  = G;
            G.Left     = F;
            F.Left     = E;
            E.Left     = D;
            D.Left     = C;
            C.Left     = B;
            B.Left     = A;
            A.Left     = root; 


            int[] filler = new int[3] {1,1,1};
            // row 1
            Node C1 = new Node("C1","Data","",C,filler);  
            Node E1 = new Node("E1","Data","",E,filler);
            Node F1 = new Node("F1","data","",F,filler);
            connectThree(C1,E1,F1);

            
            // row 2
            Node A2 = new Node("A2","data","",A,filler); 
            Node D2 = new Node("D2","data","",D,filler);
            Node G2 = new Node("G2","data","",G,filler);
            connectThree(A2,D2,G2);
            // row 3
            Node B3 = new Node("B3","data","",B,filler);
            Node C3 = new Node("C3","data","",C,filler);
            Node F3 = new Node("F3","data","",F,filler);
            connectThree(B3,C3,F3);
            // row 4
            Node A4 = new Node("A4","data","",A,filler);
            Node D4 = new Node("D4","data","",D,filler);
            connectTwo(A4,D4);
            // row 5
            Node B5 = new Node("B5","data","",B,filler);
            Node G5 = new Node("G5","data","",G,filler);
            connectTwo(B5,G5);
            // row 6
            Node D6 = new Node("D6","data","",D,filler);
            Node E6 = new Node("E6","data","",E,filler);
            Node G6 = new Node("G6","data","",G,filler);
            connectThree(D6,E6,G6);




            connectUpDown(C,C1);
            connectUpDown(E,E1);
            connectUpDown(F,F1); 

            connectUpDown(A,A2);
            connectUpDown(D,D2);
            connectUpDown(G,G2);

            connectUpDown(B,B3);
            connectUpDown(C1,C3);
            connectUpDown(F1,F3);

            connectUpDown(A2,A4);
            connectUpDown(D2,D4);

            connectUpDown(B3,B5);
            connectUpDown(G2,G5);

            connectUpDown(D4,D6);
            connectUpDown(E1,E6);
            connectUpDown(G5,G6);

            connectUpDown(A4,A);
            connectUpDown(B5,B);
            connectUpDown(C3,C);
            connectUpDown(D6,D);
            connectUpDown(E6,E);
            connectUpDown(F3,F);
            connectUpDown(G6,G);


        }

        private void connectThree(Node one,Node two,Node three)
        {
            one.Right   = two;
            two.Right   = three;
            three.Right = one;

            one.Left    = three;
            three.Left  = two;
            two.Left    = one;
        }

        private void connectTwo(Node one,Node two)
        {
            one.Left  = two;
            two.Left  = one;
            one.Right = two;
            two.Right = one;
        }

        private void connectUpDown(Node one,Node two)
        {
            one.Down = two;
            two.Up   = one;
        }

        public Node Root
        {
            get { return root; }
        }

        
    }
}