#include "pch.h"
#include "sudoku.h"

sudoku::sudoku ( )
{
    tailptr = nullptr;
}

sudoku::sudoku ( sudoku& s )
{
    //Setting tailptr
    tailptr = nullptr;

    //Defining variables
    puzzle* copyptr = tailptr;
    puzzle* baseptr = s.tailptr;

    //If no manipulation has been made return
    if ( s.basePuzz.size == 0 )
    {
        return;
    }

    //Resize vectors
    resize ( s.basePuzz.size );

    //Copy puzzle and used values
    basePuzz.cont = s.basePuzz.cont;
    basePuzz.usedC = s.basePuzz.usedC;
    basePuzz.usedH = s.basePuzz.usedH;
    basePuzz.usedV = s.basePuzz.usedV;

    //If there are no puzzles return
    if ( baseptr == nullptr )
    {
        return;
    }

    //Create first puzzle structure
    tailptr = new ( nothrow ) puzzle;
    copyptr = tailptr;

    //Copy data
    copyptr->cont = baseptr->cont;
    copyptr->usedC = baseptr->usedC;
    copyptr->usedH = baseptr->usedH;
    copyptr->usedV = baseptr->usedV;
    copyptr->possNum = baseptr->possNum;
    copyptr->next = tailptr;

    //While there is another solution
    while ( baseptr->next != s.tailptr )
    {
        //Create new puzzle structure
        copyptr->next = new ( nothrow ) puzzle;

        //Increment pointers
        copyptr = copyptr->next;
        baseptr = baseptr->next;

        //Copy data
        copyptr->cont = baseptr->cont;
        copyptr->usedC = baseptr->usedC;
        copyptr->usedH = baseptr->usedH;
        copyptr->usedV = baseptr->usedV;
        copyptr->possNum = baseptr->possNum;
        copyptr->next = tailptr;
    }
}

sudoku::~sudoku ( )
{
    puzzle* tempptr = tailptr;

    if ( tailptr != nullptr )
    {
        tailptr = tailptr->next;
        tempptr->next = nullptr;
        basePuzz.possNum = 0;
    }

    while ( tailptr != nullptr )
    {
        tempptr = tailptr;
        tailptr = tailptr->next;
        delete tempptr;
    }
}