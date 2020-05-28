/*
    Written and created by Arnar Ingi Gunnarsson 
    Github: arnaringig
*/
using System;
namespace ExactCoverSudoku
{
    class DLXSudokuReducer                                                       /* The DLX data structure is described in the Readme file. */
    {
        private int[]             _grid;
        private Node              _root;
        private int               _len;
        private ColObjContainer   _colObjContainer;
        private Node[]            _lastNodeMemo;
    
        // The constructor takes as input the problem grid to be solved.                                                          
        public DLXSudokuReducer(int[] grid)                                              
        {                                      
            // The sudoku problem we will solve represented as an array of integers (81 for 9 by 9 for instance).
            this._grid            = grid;                                    
            // The root column object is the special case entry point for the DLX.
            this._root            = new Node("Root","rootNode");             
            // The length of the problem array times 4. 324 for 9 by 9 (most common). 256 for 16 by 16, etc.
            this._len             = this._grid.Length*4;  

            // (9 by 9) by 4 The container stores all Column Objects except the root column object.               
            this._colObjContainer = new ColObjContainer(this._len,this._root);  

            // When we have inserted all the nodes, we need to connect the last nodes of each column
            // back to the respective column object. In order to be able to do that very fast it´s
            // good to memoize which nodes are the last nodes while we insert, and then in constant time
            // we can access each last node in an array of last nodes and connect them to the column node.
            this._lastNodeMemo    = new Node[this._len];

            //Then we start the process of reducing the grid.
            reduceSudokuGridToDLX();
        } 

        public Node Root
        {
            get { return _root; }
        }

        private void reduceSudokuGridToDLX() 
        {
            for (int i = 0; i < this._grid.Length; i++) 
            { 
                insert(i); 
            }

            // Memoizing the last nodes to an array gives us constant time access 
            // to each node so that when connecting each last node to the corresponding
            // column object we won´t have to go through the root node each time and
            // iterate to the last node.
            
            
            foreach (var lastNode in _lastNodeMemo)
            {
                lastNode.Down = lastNode.ColNode;
                lastNode.ColNode.Up = lastNode;
            }
        }

        private void insert(int cellIdx)
        {
            int value = this._grid[cellIdx];
              
             // If the cell in the sudoku grid is empty
            if (value == 0)                                                 
            {
                for (int i = 0; i < (int)Math.Sqrt(this._grid.Length); i++)
                {   
                    insertSubroutine(cellIdx,i);
                }
            }
            else
            {
                insertSubroutine(cellIdx,value-1);
            } 
        }

        // breyta nafninu á þessu falli.. ekki subroutine 
        private void insertSubroutine(int cellIdx,int value) 
        {
            CellToDLI DLIdata = new CellToDLI(cellIdx,value,this._grid.Length);
            string nodeId = "D"+cellIdx.ToString();

            
            
            // here we use Node´s column node constructor
            // these are the column nodes that each respective data node below points to.
            Node celColumnNode = this._colObjContainer[DLIdata.CelDLIdx];
            Node rowColumnNode = this._colObjContainer[DLIdata.RowDLIdx];
            Node colColumnNode = this._colObjContainer[DLIdata.ColDLIdx];
            Node boxColumnNode = this._colObjContainer[DLIdata.BoxDLIdx];

            // here we use Node´s data node constructor.
            Node celDataNode = new Node(nodeId,"dataNode","cell",celColumnNode,DLIdata.RowData);
            Node rowDataNode = new Node(nodeId,"dataNode","row" ,rowColumnNode,DLIdata.RowData);
            Node colDataNode = new Node(nodeId,"dataNode","col" ,colColumnNode,DLIdata.RowData);
            Node boxDataNode = new Node(nodeId,"dataNode","box" ,boxColumnNode,DLIdata.RowData);

            insertRow(
                cellIdx,
                DLIdata,
                celDataNode,
                rowDataNode,
                colDataNode,
                boxDataNode
            );
        }

        private void insertRow(int cellIdx, CellToDLI indices, Node cel, Node row, Node col, Node box)
        {
            connectRowNodes(cel,row,col,box);
            insertNode(cellIdx,cel,indices.CelDLIdx); 
            insertNode(cellIdx,row,indices.RowDLIdx);
            insertNode(cellIdx,col,indices.ColDLIdx);
            insertNode(cellIdx,box,indices.BoxDLIdx);
        }

        // connectRowNodes connects the 4 data nodes like a 'necklace'.
        //  <-cel-row-col-box->
        private void connectRowNodes(Node a, Node b, Node c, Node d)
        {
            a.Right  = b;
            a.Left   = d;
            b.Right  = c;
            b.Left   = a;
            c.Right  = d;
            c.Left   = b;
            d.Right  = a;
            d.Left   = c;            
        }

        // insertNode enters a column node at an index and then 
        // iterates down until it can insert the node.
        private void insertNode(int cellIdx, Node insertNode, int columnIndex)
        {   
            Node connectorNode = this._colObjContainer[columnIndex];
            
            while(connectorNode.Down is Node)
            {
                connectorNode = connectorNode.Down;
            }
            
            connectorNode.Down = insertNode;
            insertNode.Up = connectorNode; 

            // As a node is inserted, the size property of the corresponding column 
            // object is increased.
            insertNode.ColNode.increaseSize();

            // Memoize last nodes.
            _lastNodeMemo[columnIndex] = insertNode;         
        }
    }
}