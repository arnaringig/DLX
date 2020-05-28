/*
    Written and created by Arnar Ingi Gunnarsson 
    Github: arnaringig
*/

using System;
namespace ExactCoverSudoku 
{
    public class CellToDLI
    { 
        // value, row, column
        private int[] _rowData = new int[3];

        private int _celDLIdx;                                                               
        private int _rowDLIdx;                                                               
        private int _colDLIdx;                                                               
        private int _boxDLIdx;                                                               
        
        // The constructor.
        public CellToDLI(int cellIdx, int value, int length)                                       
        {
            int celRegion = 0;   
            int rowRegion = 1;                                                             
            int colRegion = 2;                                                            
            int boxRegion = 3;                                                            

            // Minus 1 from the value to keep all indices correct.
            // The row|col|box constraint indices are calculated via the lambda functions below. 
            int val = value;
            
            // k is the square root of length. It is used in the lambda functions below
            // to calculate the placement indices of the linked list nodes.
            int k = (int)Math.Sqrt(length);
            // and q is the fourth root of length
            int q = (int)Math.Sqrt(k);
                                                 
            int row = getRow(cellIdx,k);                                                    
            int col = getCol(cellIdx,k);                                                    
            int box = getBox(row,col,q);                                                    

            this._rowData[0] = val;
            this._rowData[1] = row;
            this._rowData[2] = col;

            // The length of the grid array (since we want to be able to use an arbitrarily sized problem, i.e 16 by 16).
            int len = length;                                                      
     
            this._celDLIdx = insertIdx(celRegion,0,len,cellIdx);                             
            this._rowDLIdx = insertIdx(rowRegion,row,len,val);                              
            this._colDLIdx = insertIdx(colRegion,col,len,val);                          
            this._boxDLIdx = insertIdx(boxRegion,box,len,val);                               
        }

        // Takes a cell index and k from the input problem and returns the sudoku grid row. k is the squre root of the problem length.
        Func<double, int, int> getRow = (cIdx,k)    => (int)Math.Floor(cIdx/k);  
        // Takes a cell index and k from the input problem and returns the sudoku grid column. k is the squre root of the problem length.
        Func<double, int, int> getCol = (cIdx,k)    => (int)cIdx%k;              
        // Takes a row index and column index and q and returns which box the pair belongs to. q is the fourth root of the problem length
        Func<int,int,int,int>  getBox = (row,col,q) => q*(row/q) + (col/q);           
        // Returns column placement index for DLX. | 1-81 cell | 82-162 row | 163-243 col | 244-324 box | (for 9 by 9).
        // The formula is: region*length + ((Sqrt(length)*(row|col|box) + cellValue)  |  (Sqrt(length)*0 + cellIdx)).
        Func<int,int,int,int,int> insertIdx = (r,p,l,v) => r*l + (int)Math.Sqrt(l)*p + v; 
                                                                                          
        // Accessor methods
        public int[] RowData   { get { return _rowData ; } }                                     
        public int   CelDLIdx  { get { return _celDLIdx; } }                                     
        public int   RowDLIdx  { get { return _rowDLIdx; } }                                     
        public int   ColDLIdx  { get { return _colDLIdx; } }                                     
        public int   BoxDLIdx  { get { return _boxDLIdx; } }                                     
    }
}