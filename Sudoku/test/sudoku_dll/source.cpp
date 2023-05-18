#define CATCH_CONFIG_RUNNER

#include "sudoku.h"
#include "..\..\..\catch.hpp"

using namespace std;


const bool RUNCATCH = true;



int main ( int argc, char** argv)
{
    //Run testcases
    Catch::Session session;
    int result;

    if ( RUNCATCH && argc == 1 )
    {
        result = session.run ( );
        if ( result != 0 )
        {
            cout << "Test cases didn't pass." << endl;
            return result;
        }
    }
}