#include "pch.h"
#include "sudoku.h"


bool sudoku::resize ( int size )
{
    //Defining Variables
    int i = 0, j = 0;

    //If the square root of size is not an integer or solutions have been made return false
    if ( int ( sqrt ( size ) ) != double ( sqrt ( size ) ) )
    {
        return false;
    }

    //If solutions are made return false
    if ( tailptr != nullptr )
    {
        return false;
    }

    if ( basePuzz.size != 0 )
    {
        clear ( );
    }

    //Resize base vectors
    basePuzz.size = size;
    basePuzz.cont.resize ( size, vector<int> ( size, 0 ) );
    basePuzz.usedC.resize ( size, vector<bool> ( size, false ) );
    basePuzz.usedH.resize ( size, vector<bool> ( size, false ) );
    basePuzz.usedV.resize ( size, vector<bool> ( size, false ) );

    return true;
}


void sudoku::clear ( )
{
    //Defining pointer
    puzzle* tempptr = tailptr;

    //While there are puzzles allocated
    while ( tailptr != nullptr )
    {
        tempptr = tailptr;
        tailptr = tailptr->next;
        delete tempptr;
    }

    return;
}