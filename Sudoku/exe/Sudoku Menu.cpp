#include "sudoku.h"

int main ( )
{
    int menuOption;
    bool end = false;

    while ( !end )
    {
        cout << setfill ( char ( 205 ) ) << setw ( 25 ) << left << char ( 201 ) << char ( 187 ) << endl;
        cout << char ( 186 ) << " Sudoku Dimensions Menu " << char ( 186 ) << endl;
        cout << setw ( 25 ) << left << char ( 200 ) << char ( 188 ) << endl << endl;
        cout << " 1: 3x3\n";
        cout << " 2: 9x9\n";

        cout << "\n 0: exit program\n" << endl;

        cout << "Menu option: ";
        cin >> menuOption;
        cout << endl << endl;

        if ( menuOption == 1 )
        {
            thrMain ( );
        }

        if ( menuOption == 2 )
        {
            nineMain ( );
        }

        else if ( menuOption == 0 )
        {
            cout << "Goodbye" << endl;
            end = true;
        }

        else
        {
            cout << "Option Invalid\n" << endl;
        }
    }
    
}