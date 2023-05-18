#include "sudoku.h"

void nineMain ( )
{
    //Defining variables
    nxnCell baseCell;
    nxnCell cell = baseCell;
    bool back = false;
    char menuOption = 'x';
    int i, x, y;

    while ( !back )
    {
        //Reset cell
        cell = baseCell;
        
        //Output banner
        cout << setfill ( char ( 205 ) ) << setw ( 30 ) << left << char ( 201 ) << char ( 187 ) << endl;
        cout << char (186) << " 9x9 Dimensional Sudoku Menu " << char(186) << endl;
        cout << setw ( 30 ) << left << char ( 200 ) << char ( 188 ) << endl << endl;

        //Output list
        cout << " 1: create template\n";
        cout << " 2: output puzzle possibilities\n";
        cout << " 3: output all possibilities\n\t--WARNING: over 6 x 10^21 possible\n\n";

        cout << " 0: return to previous menu\n" << endl;

        //Prompt for user input
        cout << endl << "Menu option: ";
        cin >> menuOption;
        cout << endl << endl;

        //Menu selections
        if ( menuOption == '1' )
        {
            tempOut ( 9, 9 );
        }

        else if ( menuOption == '2' )
        {
            if ( inp9x9 ( cell ) )
            {
                puz9x9 ( cell );

                if ( cell.numPos == 0 )
                {
                    cout << "No possibilities\n\n" << endl;
                }
                else
                {
                    cout << "Number of possibilities: " << cell.numPos << "\n\n" << endl;
                }
            }
        }

        else if ( menuOption == '3' )
        {
            puz9x9 ( cell );
        }

        else if ( menuOption == '0' )
        {
            back = true;
        }

        else
        {
            cout << "Option Invalid\n" << endl;
        }
    }
}


bool inp9x9 ( nxnCell& puzzle )
{
    //Defining variables 
    ifstream fin;
    txtCell* tempCell;
    string filename;
    string tempcomment, comment;
    char tempchar;
    int x, y, tempint;

    //Output prompt for filename
    cout << "Specify puzzle input filename" << endl << endl;
    cout << "Filename: ";
    cin >> filename;
    cout << endl << endl;

    //Open file
    if ( !openInp ( fin, filename ) )
    {
        cout << "Unable to open file: " << filename << "\n" << endl;
        return false;
    }

    //Read dimension values and check for validity
    fin >> x;
    fin >> y;

    //If dimensions are incorrect
    if ( x != 9 && y != 9 )
    {
        cout << "Incorrect dimension variables" << endl;
        cout << "Create a 9x9 template for reference" << endl << endl;
        return false;
    }

    //Ignore newline
    fin.ignore ( );

    //Check for comments
    while ( fin.peek ( ) == '/' )
    {
        getline ( fin, tempcomment );
        comment.append ( tempcomment );
    }

    //Loop for each row
    for ( y = 0; y < 9; ++y )
    {
        //Loop for each column
        for ( x = 0; x < 9; ++x )
        {
            //Move tempCell
            tempCell = &puzzle.cell[( y / 3 )][( x / 3 )];

            //Read in character
            fin >> tempchar;
            fin.ignore ( );

            //If spot is blank
            if ( isalpha(tempchar) || tempchar == '0' )
            {
                tempint = 0;
            }

            //Else if the value is between 1 and 9 exclusive, insert value into array
            else if ( tempchar <= '9' && tempchar >= '1' )
            {
                //Set tempint to character number and move it into puzzVal
                tempint = ( tempchar - 48 );
                tempCell->puzzVal[( y % 3 )][( x % 3 )] = tempint;

                //If integer is not valid output error and return
                if ( !checkValid ( puzzle, x, y, tempint ) )
                {
                    cout << "Invalid values in puzzle file, variable duplicate\n";
                    cout << "Create a 9x9 template for referance\n" << endl;

                    return false;
                }

                //Set used statements to reflect
                tempCell->used[( tempint - 1 )] = true;
                puzzle.vused[x][( tempint - 1 )] = true;
                puzzle.hused[y][( tempint - 1 )] = true;
            }
            //Else option is not valid, exit
            else
            {
                cout << "Invalid values in puzzle file\n";
                cout << "Create a 9x9 template for referance\n" << endl;

                return false;
            }
        }
    }

    //Output puzzle template
    puzzOut ( puzzle, cout );

    return true;
}


void puz9x9 ( nxnCell& puzzle, int cellX, int cellY )
{
    if ( cellY == 3 )
    {
        contOut ( puzzle, cout );

        return;
    }

    puzCell ( puzzle, cellX, cellY );
}


void puzCell ( nxnCell& puzzle, int cellX, int cellY, int curX, int curY )
{
    //Defining variables
    txtCell* cellptr = &puzzle.cell[cellY][cellX];
    int i, x = ( ( cellX * 3 ) + curX ), y = ( ( cellY * 3 ) + curY );

    if ( curY == 3 )
    {
        if ( cellX < 2 )
        {
            puz9x9 ( puzzle, ( cellX + 1 ), cellY );
        }
        else
        {
            puz9x9 ( puzzle, 0, ( cellY + 1 ) );
        }

        return;
    }

    if ( cellptr->puzzVal[curY][curX] == 0 )
    {
        for ( i = 0; i < 9; ++i )
        {
            if ( checkValid ( puzzle, x, y, (i+1) ) )
            {
                cellptr->cont[curY][curX] = ( i + 1 );
                cellptr->used[i] = true;
                puzzle.vused[x][i] = true;
                puzzle.hused[y][i] = true;

                if ( curX < 2 )
                {
                    puzCell ( puzzle, cellX, cellY, ( curX + 1 ), curY );
                }
                else
                {
                    puzCell ( puzzle, cellX, cellY, 0, ( curY + 1 ) );
                }

                cellptr->cont[curY][curX] = 0;
                cellptr->used[i] = false;
                puzzle.vused[x][i] = false;
                puzzle.hused[y][i] = false;
            }
        }
    }
    else
    {
        cellptr->cont[curY][curX] = cellptr->puzzVal[curY][curX];
        if ( curX < 2 )
        {
            puzCell ( puzzle, cellX, cellY, ( curX + 1 ), curY );
        }
        else
        {
            puzCell ( puzzle, cellX, cellY, 0, ( curY + 1 ) );
        }
    }
}

void rand9x9 ( nxnCell& puzzle )
{

}


bool checkValid ( nxnCell& puzzle, int x, int y, int val )
{
    //If placement if valid return true
    if ( !puzzle.cell[(y/3)][(x/3)].used[(val - 1)] &&
        !puzzle.vused[x][(val - 1)] &&
        !puzzle.hused[y][(val - 1)] )
    {
        return true;
    }

    //Otherwise return false
    return false;
}