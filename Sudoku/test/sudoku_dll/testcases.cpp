#include "sudoku.h"
#include "..\..\..\catch.hpp"


TEST_CASE ( "constructor/deconstructor" )
{
    sudoku puzzle;

    REQUIRE ( puzzle.empty ( ) );
}

TEST_CASE ( "size - with sections" )
{
    sudoku puzzle;

    SECTION ( "empty" )
    {
        REQUIRE ( puzzle.size ( ) == 0 );
    }

    puzzle.resize ( 4 );

    SECTION ( "4x4" )
    {
        REQUIRE ( puzzle.size ( ) == 4 );
    }

    puzzle.resize ( 9 );

    SECTION ( "9x9" )
    {
        REQUIRE ( puzzle.size ( ) == 9 );
    }

    puzzle.resize ( 0 );

    SECTION ( "re-empty" )
    {
        REQUIRE ( puzzle.size ( ) == 0 );
    }
}

TEST_CASE ( "resize - with sections" )
{
    sudoku puzzle;

    SECTION ( "empty set 0" )
    {
        REQUIRE ( puzzle.resize ( 0 ) );

        REQUIRE ( puzzle.size ( ) == 0 );
    }

    SECTION ( "4x4" )
    {
        REQUIRE ( puzzle.resize ( 4 ) );

        REQUIRE ( puzzle.size ( ) == 4 );
    }

    SECTION ( "9x9" )
    {
        REQUIRE ( puzzle.resize ( 9 ) );

        REQUIRE ( puzzle.size ( ) == 9 );
    }

    puzzle.resize ( 9 );

    SECTION ( "3 fail" )
    {
        REQUIRE ( !puzzle.resize ( 3 ) );

        REQUIRE ( puzzle.size ( ) == 9 );
    }

    SECTION ( "7 fail" )
    {
        REQUIRE ( !puzzle.resize ( 7 ) );

        REQUIRE ( puzzle.size ( ) == 9 );
    }
}

TEST_CASE ( "clear - with sections" )
{

}