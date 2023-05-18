#pragma once

#ifndef __createStruct__H__
#define __createStruct__H__

#include <iomanip>
#include <vector>

class structure
{
public:
    //Constructor/Deconstructor
    structure ( );
    structure ( string name );
    structure ( structure rhs );
    ~structure ( );

    //Item manipulation
    bool changeName ( );
    bool addItem ( string var, string name, string val, string comment );
    bool removeItem ( int pos );
    bool editItem ( int pos );

    //Data access
    string viewVar ( int pos );
    string viewName ( int pos );
    string viewVal ( int pos );
    string viewCom ( int pos );

    //List information
    bool hasVar ( string var );
    bool hasName ( string name );
    bool hasVal ( string val );
    bool hasCom ( string comment );
    bool empty ( );
    int size ( );

    //List output
    bool structIn ( );
    bool structOut ( );
    bool listIn ( );
    bool listOut ( );
    bool readIn ( );
    bool readOut ( );



private:
    struct item
    {
        string var;
        string name;
        string val;
        string comment;
    };
    vector<string> varList;
    string structName;

    //Position access
    int findVar ( string var );
    int findName ( string name );
    int findVal ( string val );
    int findCom ( string comment );
};

//Constructor
structure::structure ( )
{
    structName = "DEFAULT";
}

//Constructor with listname
structure::structure ( string name )
{
    structName = name;
}

//Copy constructor
structure::structure ( structure rhs )
{
    structName = rhs.structName + "_COPY";
    varList = rhs.varList;
}

//Deconstructor
structure::~structure ( )
{

}

#endif