#include "pch.h"
#include "sudoku.h"


int sudoku::size ( )
{
    //Return base size number
    return basePuzz.size;
}


bool sudoku::empty ( )
{
    if ( tailptr == nullptr )
        return true;

    return false;
}


int sudoku::numPoss ( )
{
    //Defining variables
    int i = 0;
    puzzle* tempptr = tailptr;

    return basePuzz.possNum;

    ////Increment first puzzle
    //if ( tempptr != nullptr )
    //{
    //    tempptr = tempptr->next;
    //    ++i;
    //}

    ////While not at the last possibility
    //while ( tempptr != tailptr )
    //{
    //    //Increment number and to next possibility
    //    tempptr = tempptr->next;

    //    ++i;
    //}

    ////Return number of possibilities
    //return i;
}


vector<vector<int>> sudoku::cont ( )
{
    //Defining variables
    vector<vector<int>> contents;
    vector<int> tempCont;
    puzzle* tempptr = tailptr;
    int i, tempint;
    int size = basePuzz.size;
    int sizeCell = int ( sqrt ( basePuzz.size ) );
    int sizeVect = int ( pow ( basePuzz.size, 2 ) );

    //If there are no possibilities return the empty vector
    if ( tailptr == nullptr )
    {
        return contents;
    }

    //First puzzle contents
    //Loop for entire vector
    for ( i = 0; i < sizeVect; ++i )
    {
        //Move the possible contents to the vector
        tempint = tempptr->cont[( i / size )][( i % size )];

        //Push contents to back of vector
        tempCont.push_back ( tempint );
    }

    //Push vector to end of vector of vectors
    contents.push_back ( tempCont );

    //Increment pointer
    tempptr = tempptr->next;

    //While not at the end of the list
    while ( tempptr != tailptr )
    {
        //Reset temporary vector
        tempCont.clear ( );

        //Loop for the length of the vector
        for ( i = 0; i < sizeVect; ++i )
        {
            //Move the possible contents to the vector
            tempint = tempptr->cont[( i / size )][( i % size )];

            tempCont.push_back ( tempint );
        }
        contents.push_back ( tempCont );

        //Increment pointer
        tempptr = tempptr->next;
    }

    //Return the filled vector
    return contents;
}


vector<int> sudoku::cont ( int pos )
{
    //Defining variables
    vector<int> contents;
    puzzle* tempptr = tailptr;
    int i;
    int size = basePuzz.size;
    int sizeCell = int ( sqrt ( size ) );
    int sizeVect = int ( pow ( size, 2 ) );

    //Resize vector
    contents.resize ( sizeVect, 0 );

    //If there are no possibilities return the empty vector
    if ( tailptr == nullptr )
    {
        return contents;
    }

    //While not at the position in the list, increment pointer
    while ( tempptr->possNum != pos && tempptr->next != tailptr )
    {
        tempptr = tempptr->next;
    }

    //If still not at the position return the empty vector
    if ( tempptr->possNum != pos )
    {
        return contents;
    }

    for ( i = 0; i < sizeVect; ++i )
    {
        //Move contents of possibility into vector
        contents[i] = tempptr->cont[( i / size )][( i % size )];
    }
    
    //Return filled vector
    return contents;
}


vector<int> sudoku::puzz ( )
{
    //Defining variables
    vector<int> contents;
    int i, tempint;
    int size = basePuzz.size;
    int sizeCell = int ( sqrt ( basePuzz.size ) );
    int sizeVect = int ( pow ( basePuzz.size, 2 ) );

    //If the size is unchanged return the empty vector
    if ( size == 0 )
    {
        return contents;
    }

    //Loop for the size of the vector
    for ( i = 0; i < sizeVect; ++i )
    {
        //Move puzzle contents into vector
        tempint = basePuzz.cont[( i / size )][( i % size )];

        contents.push_back ( tempint );
    }

    //Return filled vector
    return contents;
}