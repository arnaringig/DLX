/*
    Written and created by Arnar Ingi Gunnarsson 
    Github: arnaringig
*/
using System;
namespace ExactCoverSudoku
{
    public class RowMetadata
    {
        private int _val;
        private int _row;
        private int _col;

        public RowMetadata(int[] rowData)
        {
            this._val = rowData[0];
            this._row = rowData[1];
            this._col = rowData[2];
        }

        public int Val  { get { return _val; } }
        public int Row  { get { return _row; } }
        public int Col  { get { return _col; } }
    }
}
    