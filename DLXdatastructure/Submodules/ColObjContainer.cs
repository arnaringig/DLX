/*
    Written and created by Arnar Ingi Gunnarsson 
    Github: arnaringig
*/
using System;
namespace ExactCoverSudoku
{
    public class ColObjContainer
    {
        public Node[] container;
        
        public ColObjContainer(int len,Node root) 
        {
            this.container = new Node[len];
            initializeContainer(root);
        }

        private void initializeContainer(Node root)
        {
            populateContainer();
            connectColumnObjects(root);
        }

        private void populateContainer() 
        {
            for (int i = 0; i < this.container.Length; i++)
            {
                this.container[i] = new Node("C"+i.ToString(),"columnNode");
            }
        }

        private void connectColumnObjects(Node root) 
        {
            int first = 0;
            int last  = this.container.Length-1;

            this.container[first].Left  = root; //Breyta þessu bara í ColObj. Þarf að vera sama týpan.
            this.container[last ].Right = root;
            root.Left = this.container[last];
            root.Right = this.container[first];



            for (int i = 1; i < this.container.Length-1; i++)
            {
                this.container[i-1].Right = this.container[ i ];
                this.container[ i ].Left  = this.container[i-1];   
            }
            
        }

        public Node this[int index]
        {
            get { return container[index]; }
        }
    }
}