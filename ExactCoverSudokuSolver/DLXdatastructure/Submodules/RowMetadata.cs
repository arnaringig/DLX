/*
    Written and created by Arnar Ingi Gunnarsson 
    Github: arnaringig
*/
using System;
namespace ExactCoverSudoku
{
    public class RowMetadata
    {
        private int val;
        private int row;
        private int col;

        public RowMetadata(int[] rowData)
        {
            this.val = rowData[0];
            this.row = rowData[1];
            this.col = rowData[2];
        }

        public int Val  { get { return val; } }
        public int Row  { get { return row; } }
        public int Col  { get { return col; } }
    }
}
    