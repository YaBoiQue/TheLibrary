#include "sudoku.h"

bool openOut ( ofstream& fout, string filename )
{
    //Open file with filename
    fout.open ( filename, ios::out | ios::trunc );

    //If file fails to open
    if ( !fout.is_open ( ) )
    {
        //Output error
        cout << "Output file \"" << filename << " \" failed to open.\n" << endl;

        //Return false
        return false;
    }

    //Else return true
    return true;
}


bool openInp ( ifstream& fin, string filename )
{
    //Open file with filename
    fin.open ( filename, ios::in );

    //If file fails to open
    if ( !fin.is_open ( ) )
    {
        //Output error
        cout << "Input file \"" << filename << " \" failed to open.\n" << endl;

        //Return false
        return false;
    }

    //Else return true
    return true;
}


void tempOut ( int x, int y )
{
    //Defining variables
    ofstream fout;
    string filename;
    int ix, iy;

    cout << "Specify output filename" << endl;
    cout << "Warning: If file exists, contents will be erased" << endl << endl;
    cout << "Filename: ";
    cin >> filename;
    cout << endl << endl;

    openOut ( fout, filename );


    fout << x << " " << y << "\n";
    fout << "//Replace x's with position value, leave x if unknown\n";

    for ( iy = 0; iy < y; ++iy )
    {
        for ( ix = 0; ix < x; ++ix )
        {
            fout << "x";

            if ( ix < ( x - 1 ) )
            {
                fout << " ";
            }
        }
        fout << "\n";
    }



}


void contOut ( nxnCell& puzzle, ostream& out )
{
    //Declaring variables
    int i, x, y;

    puzzle.numPos++;

    if ( puzzle.numPos == 1 )
    {
        cout << "Solution possibilities:\n\n";
    }

    cout << puzzle.numPos << ".\n";

    //Output first line
    cout << setw ( 8 ) << setfill ( char ( 196 ) ) << left << char ( 218 );
    for ( i = 0; i < 2; ++i )
    {
        cout << setw ( 8 ) << left << char ( 194 );
    }
    cout << char ( 191 ) << endl;

        //Loop for each row
    for ( y = 0; y < 9; ++y )
    {
        for ( x = 0; x < 9; ++x )
        {
            if ( ( x % 3 ) == 0 )
            {
                cout << setw ( 2 ) << setfill ( ' ' ) << char ( 179 );
            }
            //Loop for each column
            cout << setw ( 2 ) << puzzle.cell[(y/3)][(x/3)].cont[(y%3)][(x%3)];

            //If at the end of row
            if ( x == 8 )
            {
                cout << char ( 179 ) << endl;
            }
        }

        //
        if ( ( y % 3 ) == 2 && y < 8 )
        {
            cout << setw ( 8 ) << setfill ( char ( 196 ) ) << left << char ( 195 );
            for ( i = 0; i < 2; ++i )
            {
                cout << setw ( 8 ) << left << char ( 197 );
            }
            cout << char ( 180 ) << endl;
        }
    }
    //Output last line
    cout << setw ( 8 ) << setfill ( char ( 196 ) ) << left << char ( 192 );
    for ( i = 0; i < 2; ++i )
    {
        cout << setw ( 8 ) << left << char ( 193 );
    }
    cout << char ( 217 ) << endl;

    cout << endl << endl;
    
    return;
}


void contOut ( txtCell& puzzle, ostream& out )
{
    //Declaring variables
    int i, x, y;

    puzzle.numPos++;

    if ( puzzle.numPos == 1 )
    {
        cout << "Solution possibilities:\n\n";
    }

    cout << puzzle.numPos << ".\n";

    //Output first line
    cout << setw ( 8 ) << setfill ( char ( 196 ) ) << left << char ( 218 );
    cout << char ( 191 ) << endl;

    //Loop for each row
    for ( y = 0; y < 3; ++y )
    {
        cout << setw ( 2 ) << setfill ( ' ' ) << char ( 179 );

        //Loop for each column
        for ( x = 0; x < 3; ++x )
        {
            cout << setw ( 2 ) << puzzle.cont[( y % 3 )][( x % 3 )];
        }

        //Output end char
        cout << char ( 179 ) << endl;
    }
    //Output last line
    cout << setw ( 8 ) << setfill ( char ( 196 ) ) << left << char ( 192 );
    cout << char ( 217 ) << endl;

    cout << endl << endl;

    return;
}


void puzzOut ( nxnCell& puzzle, ostream& out )
{
    //Defining variables
    int i, x, y;


    cout << "Outputting puzzle layout ( 0's are empty spaces to fill )\n\n";


    //Output first line
    cout << setw ( 8 ) << setfill ( char ( 196 ) ) << left << char ( 218 );
    for ( i = 0; i < 2; ++i )
    {
        cout << setw ( 8 ) << left << char ( 194 );
    }
    cout << char ( 191 ) << endl;

    //Loop for each row
    for ( y = 0; y < 9; ++y )
    {
        for ( x = 0; x < 9; ++x )
        {
            if ( ( x % 3 ) == 0 )
            {
                cout << setw ( 2 ) << setfill ( ' ' ) << char ( 179 );
            }
            //Loop for each column
            cout << setw ( 2 ) << puzzle.cell[( y / 3 )][( x / 3 )].puzzVal[( y % 3 )][( x % 3 )];

            //If at the end of row
            if ( x == 8 )
            {
                cout << char ( 179 ) << endl;
            }
        }

        //
        if ( ( y % 3 ) == 2 && y < 8 )
        {
            cout << setw ( 8 ) << setfill ( char ( 196 ) ) << left << char ( 195 );
            for ( i = 0; i < 2; ++i )
            {
                cout << setw ( 8 ) << left << char ( 197 );
            }
            cout << char ( 180 ) << endl;
        }
    }
    //Output last line
    cout << setw ( 8 ) << setfill ( char ( 196 ) ) << left << char ( 192 );
    for ( i = 0; i < 2; ++i )
    {
        cout << setw ( 8 ) << left << char ( 193 );
    }
    cout << char ( 217 ) << endl;

    cout << endl << endl;
}


void puzzOut ( txtCell& puzzle, ostream& out )
{
    //Declaring variables
    int i, x, y;

    //Output title
    cout << "Outputting puzzle layout ( 0's are empty spaces to fill )\n\n";

    //Output first line
    cout << setw ( 8 ) << setfill ( char ( 196 ) ) << left << char ( 218 );
    cout << char ( 191 ) << endl;

    //Loop for each row
    for ( y = 0; y < 3; ++y )
    {
        cout << setw ( 2 ) << setfill ( ' ' ) << char ( 179 );

        //Loop for each column
        for ( x = 0; x < 3; ++x )
        {
            cout << setw ( 2 ) << puzzle.puzzVal[( y % 3 )][( x % 3 )];
        }

        //Output end char
        cout << char ( 179 ) << endl;
    }
    //Output last line
    cout << setw ( 8 ) << setfill ( char ( 196 ) ) << left << char ( 192 );
    cout << char ( 217 ) << endl;

    cout << endl << endl;

    return;
}