/*
    Written and created by Arnar Ingi Gunnarsson 
    Github: arnaringig
*/
using System;
namespace ExactCoverSudoku
{
    // The node class provides two constructors. One for the column node (the root node included)
    // and one for the data node.
    public class Node
    { 
        private Node _up;
        private Node _down;
        private Node _left;
        private Node _right; 
        private Node _colNode;
        private RowMetadata _rowData;

        private int    _size;
        private string _id;
        private string _tag;
        private string _constraint;

        // column node constructor
        public Node(string id, string tag)
        {
            this._size = 0  ;
            this._id   = id ;
            this._tag  = tag;
        }
        
        // data node constructor
        public Node(string id, string tag, string constraint, Node colNode, int[] rowData)
        {
            this._id         = id;
            this._tag        = tag;
            this._colNode    = colNode;
            this._constraint = constraint;
            this._rowData    = new RowMetadata(rowData);
        }

        public void increaseSize()
        {
            if(_tag.Equals("columnNode"))
            {
                this._size += 1;
            }
        }

        public void decreaseSize()
        {
            if(_tag.Equals("columnNode"))
            {
                this._size -= 1;
            }
        }

        public Node   Up           { get { return _up         ;} set { _up    = value;} } 
        public Node   Down         { get { return _down       ;} set { _down  = value;} }
        public Node   Left         { get { return _left       ;} set { _left  = value;} }
        public Node   Right        { get { return _right      ;} set { _right = value;} }
        public Node   ColNode      { get { return _colNode    ;}                        }
        public int    Size         { get { return _size       ;} set { _size  = value;} }
        public string ID           { get { return _id         ;}                        }
        public string Tag          { get { return _tag        ;}                        }
        public string Constraint   { get { return _constraint ;}                        }
        
        public RowMetadata RowData { get { return _rowData    ;}                         }
    }
}