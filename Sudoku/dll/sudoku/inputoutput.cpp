#include "pch.h"
#include "sudoku.h"


bool sudoku::puzzIn ( vector<int> in )
{
    //Defining variables
    int i = 0, j = 0, x = 0, y = 0, c = 0;
    int size = basePuzz.size;

    //If vector does not match puzzle size return false
    if ( sqrt ( in.size ( ) ) != size )
    {
        return false;
    }

    //Loop until at the end of the vector
    for ( i = 0; i < int ( in.size ( ) ); ++i )
    {
        //Update x, y, and cell positions
        x = ( i % size );
        y = ( i / size );
        c = ( ( ( y / int ( sqrt ( size ) ) ) * int ( sqrt ( size ) ) )
            + ( x / int ( sqrt ( size ) ) ) );

        //If vector position is a puzzle value
        if ( in.at ( i ) != 0 )
        {
            //If the value is not valid return false
            if ( in.at ( i ) <= basePuzz.size && !is_valid ( in.at ( i ), i ) )
            {
                return false;
            }

            //Update puzzle value and used values
            basePuzz.cont[y][x] = in.at ( i );
            basePuzz.usedH[y][( in[i] - 1 )] = true;
            basePuzz.usedV[x][( in[i] - 1 )] = true;
            basePuzz.usedC[c][( in[i] - 1 )] = true;
        }
    }

    return true;
}


bool sudoku::puzzOut ( vector<int> out )
{
    if ( !out.empty ( ) )
    {
        out.clear ( );
    }

    out.resize ( int ( pow ( basePuzz.size, 2 ) ) );

    return true;
}