/*
    Written and created by Arnar Ingi Gunnarsson 
    Github: arnaringig
*/

namespace ExactCoverSudoku
{
    // The node class provides two constructors. One for the column node (the root node included)
    // and one for the data node.
    public class Node
    { 
        private Node up;
        private Node down;
        private Node left;
        private Node right; 
        private Node col;

        int    size;
        string id;
        string tag;
        string constraint;

        // column node constructor
        public Node(string id, string tag)
        {
            this.size = 0  ;
            this.id   = id ;
            this.tag  = tag;
        }
        
        // data node constructor
        public Node(string id, string tag, string constraint, Node col)
        {
            this.id         = id;
            this.tag        = tag;
            this.col        = col;
            this.constraint = constraint;
            
        }

        public void increaseSize()
        {
            if(tag.Equals("columnNode"))
            {
                this.size += 1;
            }
        }

        public void decreaseSize()
        {
            if(tag.Equals("columnNode"))
            {
                this.size -= 1;
            }
        }

        public Node   Up          { get { return up         ;} set { up    = value;} } 
        public Node   Down        { get { return down       ;} set { down  = value;} }
        public Node   Left        { get { return left       ;} set { left  = value;} }
        public Node   Right       { get { return right      ;} set { right = value;} }
        public Node   Col         { get { return col        ;}                       }
        public int    Size        { get { return size       ;} set { size  = value;} }
        public string ID          { get { return id         ;}                       }
        public string Tag         { get { return tag        ;}                       }
        public string Constraint  { get { return constraint ;}                       }
    }
}