#include "Schedule.h"
#include <windows.h>
#include <fstream>
#include <vector>

using namespace std;

struct setup
{
    //File Locations
    vector<string> employeeDir;
    vector<string> scheduleDir;
};

//Function prototypes
bool createSetup ( );
bool createFile ( string filename );
setup readSetup ( );
string parseVector ( vector<char> argument );

//Global Variables
setup settings;


int main ( )
{
    //Defining variables
    ifstream setupFile ( "setup.ini" );

    //If the file does not exist create one (run startup sequence)
    if ( !setupFile.is_open() )
        if ( !createSetup ( ) )
            return -1;

    settings = readSetup ( );


    
    return 0;
}



bool createSetup ( )
{
    //Defining variables
    ofstream setupFile ( "setup.ini" );
    ofstream employee;
    ofstream schedule;

    //If the file does not open return false
    if ( !setupFile.is_open ( ) )
        return false;

    //Output setup header
    setupFile << "//-----SCHEDULER INITIALIZATION FILE-----\n";
    setupFile << "//do not change unless you know what you are doing\n\n";

    //Output and create file locations
    setupFile << "//---File/Repository Locations---\n";
    setupFile << "employees \"employees/\"\n";
    setupFile << "schedules \"schedules/\"\n";




    //Close setup file
    setupFile.close ( );

    //Create file directories
    CreateDirectoryA ( "employees", NULL );
    CreateDirectoryA ( "schedules", NULL );

    //Create files in default locations
    if ( !createFile ( "employees/sample.card" ) 
      || !createFile ( "schedules/sample.sched" ) )
    {
        return false;
    }

    //Open sample files and fill
    employee.open ( "employees/sample.card" );
    schedule.open ( "schedules/sample.sched" );

    //Fill employee sample file
    employee << "//-----Sample Employee Card-----\n\n";

    employee << "//---employee name/ID---\n"
        << "first John\n"
        << "middle Dick\n"
        << "last Doe\n"
        << "id 192837465\n\n";

    employee << "//---employee availability---\n"
        << "available from 7:30 to 20:00 on everyday\n"
        << "unavailable from 9:30 to 12:00 on tuesday\n\n";

    employee << "//-----Employee Compatibility-----\n"
        << "compatible id 1726529\n"
        << "compatible name Sue Jane\n"
        << "incompatible id 1228562\n"
        << "incompatible name Billy Bob\n\n";

    //Fill schedule sample file
    schedule << "//-----Sample Schedule-----\n";

    schedule << "\nMonday:\n"
        << "Doe, John, 192837465 from 7:30 to 20:00\n";

    schedule << "\nTuesday:\n"
        << "Doe, John, 192837465 from 7:30 to 9:30\n"
        << "Jane, Sue, 87264818 from 9:30 to 12:00\n"
        << "Doe, John, 192837465 from 9:30 to 20:00\n";

    schedule << "\nWednesday:\n"
        << "Doe, John, 192837465 from 7:30 to 20:00\n";

    schedule << "\nThursday:\n"
        << "Doe, John, 192837465 from 7:30 to 20:00\n";

    schedule << "\nFriday:\n"
        << "Doe, John, 192837465 from 7:30 to 20:00\n";

    //Close files and return true
    employee.close ( );
    schedule.close ( );

    return true;
}


bool createFile ( string filename )
{
    ofstream file ( filename, ios::trunc );

    if ( !file.is_open ( ) )
        return false;

    file.close ( );
    return true;
}


setup readSetup ( )
{
    //Defining variables
    ifstream setupFile ( "setup.ini" );
    setup input;
    string variable;
    string comment;
    vector<char> argument;
    char tempChar;
    bool cont = true;
   

    while ( !setupFile.eof() )
    {
        argument.clear ( );

        if ( setupFile.peek ( ) == '/' )
        {
            getline ( setupFile, comment );
        }
        else
        {
            setupFile >> variable;
                
            while ( setupFile.peek ( ) != '\n' )
            {
                setupFile >> tempChar;
                argument.push_back ( tempChar );
            }

            setupFile.ignore ( );

            if ( variable == "employees" )
                input.employeeDir.push_back ( parseVector ( argument ) );

            else if ( variable == "schedules" )
                input.scheduleDir.push_back ( parseVector ( argument ) );

            else
            {
                cout << "Invalid variables in setup.ini" << endl;
                exit ( -1 );
            }
        }

        while ( setupFile.peek ( ) == '\n' )
            setupFile.ignore ( );

    }

    return input;
}


string parseVector ( vector <char> argument )
{
    //Defining variables
    string output = "";
    int start = 0, end = 0, i;

    while ( argument.at ( start ) == ' ' )
        ++start;

    if ( argument.at ( start ) == '"' )
        ++start;

    end = start;

    while ( argument.at ( end ) != '"'
         && argument.at ( end ) != ' '
         && int ( argument.size ( ) ) >  end  )
        ++end;

    for ( i = start; i < end; ++i )
        output += argument.at ( i );

    return output;
}