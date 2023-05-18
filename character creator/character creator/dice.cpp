#include "pch.h"
#include "dice.h"

int rollDie ( int numSides )
{
    //Set up sudo random
    srand ( int ( time ( NULL ) ) );

    //Return random number
    return ( rand() % numSides + 1 ) ;
}

int d4 ( )
{
    return rollDie ( 4 );
}

int d6 ( )
{
    return rollDie ( 6 );
}

int d8 ( )
{
    return rollDie ( 8 );
}

int d10 ( )
{
    return rollDie ( 10 );
}

int d12 ( )
{
    return rollDie ( 12 );
}

int d20 ( )
{
    return rollDie ( 20 );
}

int per ( )
{
    return rollDie ( 100 );
}
