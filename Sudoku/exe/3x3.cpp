#include "sudoku.h"

void thrMain ( )
{
    //Defining variables
    txtCell baseCell;
    txtCell cell = baseCell;
    bool back = false;
    int menuOption = -1, i;

    while ( !back )
    {
        //Reset cell
        cell = baseCell;

        //Output banner
        cout << setfill ( char ( 205 ) ) << setw ( 30 ) << left << char ( 201 ) << char ( 187 ) << endl;
        cout << char ( 186 ) << " 3x3 Dimensional Sudoku Menu " << char ( 186 ) << endl;
        cout << setw ( 30 ) << left << char ( 200 ) << char ( 188 ) << endl << endl;

        //Output menu options
        cout << " 1: create template\n";
        cout << " 2: output puzzle possibilities\n";
        cout << " 3: output all possibilities\n\t--WARNING: ~9^9 possibilities\n\n";

        cout << " 0: return to previous menu\n" << endl;

        //Prompt for user input
        cout << endl << "Menu option: ";
        cin >> menuOption;
        cout << endl << endl;

        //Menu selections
        if ( menuOption == 1 )
        {
            tempOut ( 3, 3 );
        }

        else if ( menuOption == 2 )
        {
            if ( ThrxThrInp ( cell ) )
            {
                cell.numPos = 0;
                ThrxThrPuz ( cell );

                cout << "There are " << cell.numPos << " possibilities";
                cout << endl << endl << endl;
            }
        }

        else if ( menuOption == 3 )
        {
            ThrxThrPos ( cell );
        }

        else if ( menuOption == 0 )
        {
            back = true;
        }

        else
        {
            cout << "Option Invalid\n" << endl;
        }
    }
}


bool ThrxThrInp ( txtCell& baseCell )
{
    //Defining variables 
    ifstream fin;
    string filename;
    string tempcomment, comment;
    char tempchar;
    int x, y;

    //Output prompt for filename
    cout << "Specify puzzle input filename" << endl << endl;
    cout << "Filename: ";
    cin >> filename;
    cout << endl << endl;

    //Open file
    openInp ( fin, filename );
    
    //Read dimension values and check for validity
    fin >> x;
    fin >> y;

    if ( x != 3 && y != 3 )
    {
        cout << "Incorrect dimension variables" << endl;
        cout << "Create a 3x3 template for reference" << endl << endl;
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
    for ( y = 0; y < 3; ++y )
    {
        //Loop for each column
        for ( x = 0; x < 3; ++x )
        {
            fin >> tempchar;
            int u = fin.peek ( );
            //If the value is x, insert 0 into array
            if ( tempchar == 'x' )
            {
                baseCell.puzzVal[y][x] = 0;
            }
            //Else if the value is between 1 and 9 exclusive, insert value into array
            else if ( tempchar <= '9' && tempchar >= '1' )
            {
                baseCell.puzzVal[y][x] = (tempchar - 48);
                fin.ignore ( );
                if ( baseCell.used[baseCell.puzzVal[y][x] - 1] )
                {
                    cout << "Invalid values in puzzle file, variable duplicate\n";
                    cout << "Create a 3x3 template for referance\n" << endl;

                    return false;
                }
                baseCell.used[baseCell.puzzVal[y][x] - 1] = true;
            }
            //Else option is not valid, exit
            else
            {
                cout << "Invalid values in puzzle file\n";
                cout << "Create a 3x3 template for referance\n" << endl;

                return false;
            }
        }
    }

    puzzOut ( baseCell, cout );

    return true;
}


void ThrxThrPuz ( txtCell& baseCell, int posX, int posY )
{
    //Defining variables
    int i, x, y;

    if ( posY == 3 )
    {
        contOut ( baseCell, cout );

        return;
    }

    if ( baseCell.puzzVal[posY][posX] == 0 )
    {
        for ( i = 0; i < 9; ++i )
        {
            if ( !baseCell.used[i] )
            {
                baseCell.cont[posY][posX] = ( i + 1 );
                baseCell.used[i] = true;

                if ( posX < 2 )
                {
                    ThrxThrPuz ( baseCell, ( posX + 1 ), posY );
                }
                else
                {
                    ThrxThrPuz ( baseCell, 0, ( posY + 1 ) );
                }

                baseCell.used[i] = false;
            }
        }
    }
    else
    {
        baseCell.cont[posY][posX] = baseCell.puzzVal[posY][posX];

        if ( posX < 2 )
        {
            ThrxThrPuz ( baseCell, ( posX + 1 ), posY );
        }
        else
        {
            ThrxThrPuz ( baseCell, 0, ( posY + 1 ) );
        }
    }
}


void ThrxThrPos ( txtCell& baseCell, int posX, int posY )
{
    //Defining variables
    int i, x, y;

    if ( posY == 3 )
    {
        contOut ( baseCell, cout );

        return;
    }

    for ( i = 0; i < 9; ++i )
    {
        if ( !baseCell.used[i] )
        {
            baseCell.cont[posY][posX] = ( i + 1 );
            baseCell.used[i] = true;

            if ( posX < 2 )
            {
                ThrxThrPos ( baseCell, ( posX + 1 ), posY );
            }
            else
            {
                ThrxThrPos ( baseCell, 0, ( posY + 1 ) );
            }

            baseCell.used[i] = false;
        }
    }
}