    // The DLX datastructure is as follows:
    // At the top we have 324 column objects (for a 9 by 9 Sudoku grid)
    // Why 324? Because we have:
    // four times 81 columns for the cell, row, column and box contstraint
    // respectively.
    // Then for each empty cell in the Sudoku grid (the ones that don´t have
    // a number in them at the beginning) we create four Data Objects.




    CellToDLI constructor:

            // |##1-81 cell region##|  82-162 row region  |  163-243 col region  |  244-324 box region  | (for 9 by 9). 
            // |  1-81 cell region  |##82-162 row region##|  163-243 col region  |  244-324 box region  | (for 9 by 9).
            // |  1-81 cell region  |  82-162 row region  |##163-243 col region##|  244-324 box region  | (for 9 by 9).
            // |  1-81 cell region  |  82-162 row region  | 163-243 col region   |##244-324 box region##| (for 9 by 9). 

            // The length of the grid array (since we want to be able to use an arbitrarily sized problem, i.e 16 by 16).

            // This could have been this.celDXL = cellIdx, but I leave it 'verbose' to provide context. (at region 0, columns   1-81 ).            
            // The rowDLIdx is the column-object-container index at which a data object is to be inserted (at region 1, columns  82-162).
            // The colDLIdx is the column-object-container index at which a data object is to be inserted (at region 2, columns 163-243).
            // The boxDLIdx is the column-object-container index at which a data object is to be inserted (at region 3, columns 244-324).  