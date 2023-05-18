#include "pch.h"
#include "sudoku.h"


bool sudoku::is_valid ( int val, int pos )
{
    int size = basePuzz.size;
    int x = ( pos % basePuzz.size );
    int y = ( pos / basePuzz.size );
    int c = ( ( ( y / int ( sqrt ( size ) ) ) * int ( sqrt ( size ) ) )
        + ( x / int ( sqrt ( size ) ) ) );

    if ( !basePuzz.usedH.at ( y ).at ( ( val - 1 ) ) &&
        !basePuzz.usedV.at ( x ).at ( ( val - 1 ) ) &&
        !basePuzz.usedC.at ( c ).at ( ( val - 1 ) ) )
    {
        return true;
    }

    return false;
}


void sudoku::clearPuzz ( puzzle& poss )
{
    //Set size and pointer values
    poss.size = basePuzz.size;
    poss.next = nullptr;

    //Clear all contents
    poss.cont.clear ( );
    poss.usedC.clear ( );
    poss.usedH.clear ( );
    poss.usedV.clear ( );

    //Resize vectors
    poss.cont.resize ( poss.size, vector<int> ( poss.size ) );
    poss.usedC.resize ( poss.size, vector<bool> ( poss.size ) );
    poss.usedH.resize ( poss.size, vector<bool> ( poss.size ) );
    poss.usedV.resize ( poss.size, vector<bool> ( poss.size ) );

    //Set used values to basevalues
    poss.usedC = basePuzz.usedC;
    poss.usedH = basePuzz.usedH;
    poss.usedV = basePuzz.usedV;

}


bool sudoku::permute ( puzzle& temp, int pos )
{
    //Defining variables
    puzzle* tempptr = tailptr;
    int vectSize = int ( pow ( temp.size, 2 ) );
    int cellSize = int ( sqrt ( temp.size ) );
    int i = 0, x = pos % temp.size, y = pos / temp.size;
    int c = ( ( ( y / cellSize ) * cellSize ) ) + ( x / cellSize );

    //If at the end of the vector
    if ( pos == vectSize )
    {
        if ( tempptr == nullptr )
        {
            tailptr = new ( nothrow ) puzzle;
            temp.possNum = ++basePuzz.possNum;
            *tailptr = temp;
            tailptr->next = tailptr;

            return true;
        }

        //If the content already exists in the first puzzle return false
        if ( tempptr->cont == temp.cont )
        {
            return false;
        }

        //Increment pointer
        tempptr = tempptr->next;

        //While not at tailptr
        while ( tempptr != tailptr )
        {
            //If the content already exists in a puzzle return false
            if ( tempptr->cont == temp.cont )
            {
                return false;
            }

            tempptr = tempptr->next;
        }

        //Increment to last puzzle
        while ( tempptr->next != tailptr )
        {
            tempptr = tempptr->next;
        }

        //Set puzzle and base number and return true
        temp.possNum = ++basePuzz.possNum;

        tempptr->next = new ( nothrow ) puzzle;
        tempptr = tempptr->next;
        *tempptr = temp;
        tempptr->next = tailptr;


        return true;
    }

    //If the base contents is equal to 0
    if ( basePuzz.cont[y][x] == 0 )
    {
        //For each possible value less than size
        for ( i = 0; i < temp.size; ++i )
        {
            //If the value is valid at this position
            if ( !temp.usedH[y][i] && !temp.usedV[x][i] && !temp.usedC[c][i] )
            {
                //Set values at position
                temp.cont[y][x] = ( i + 1 );
                temp.usedH[y][i] = true;
                temp.usedV[x][i] = true;
                temp.usedC[c][i] = true;

                //If permute is succeeded return true
                if ( permute ( temp, ( pos + 1 ) ) )
                {
                    return true;
                }

                //Reset values at position
                temp.cont[y][x] = 0;
                temp.usedH[y][i] = false;
                temp.usedV[x][i] = false;
                temp.usedC[c][i] = false;
            }
        }
    }
    else
    {
        //Set a temporary int to contents value
        i = basePuzz.cont[y][x];

        //Set contents and used values
        temp.cont[y][x] = i;
        temp.usedC[c][( i - 1 )] = true;
        temp.usedH[y][( i - 1 )] = true;
        temp.usedV[x][( i - 1 )] = true;

        //If permute is succeeded return true
        if ( permute ( temp, ( pos + 1 ) ) )
        {
            return true;
        }
    }

    //Permute was not finished, return false
    return false;
}