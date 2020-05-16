/*
    Written and created by Arnar Ingi Gunnarsson 
    Github: arnaringig
*/

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

            // row 1
            Node C1 = new Node("C1","Data");  
            Node E1 = new Node("E1","Data");
            Node F1 = new Node("F1","data");
            connectThree(C1,E1,F1);

            
            // row 2
            Node A2 = new Node("A2","data"); 
            Node D2 = new Node("D2","data");
            Node G2 = new Node("G2","data");
            connectThree(A2,D2,G2);
            // row 3
            Node B3 = new Node("B3","data");
            Node C3 = new Node("C3","data");
            Node F3 = new Node("F3","data");
            connectThree(B3,C3,F3);
            // row 4
            Node A4 = new Node("A4","data");
            Node D4 = new Node("D4","data");
            connectTwo(A4,D4);
            // row 5
            Node B5 = new Node("B5","data");
            Node G5 = new Node("G5","data");
            connectTwo(B5,G5);
            // row 6
            Node D6 = new Node("D6","data");
            Node E6 = new Node("E6","data");
            Node G6 = new Node("G6","data");
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