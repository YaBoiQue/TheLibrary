#pragma once

#include "Availability.h"

using namespace std;

#ifndef __Employee__H__
#define __Employee__H__

class employee
{
public:

    struct card
    {
        string fName;
        string mName;
        string lName;
        string id;
        vector <string> compat;
        vector <string> incompat;
        availability avail;
        availability unavail;
    };


    //Con\Deconstructors
    employee ( );
    ~employee ( );


    //Manipulation
    bool firstIn ( string name );
    bool middleIn ( string name );
    bool lastIn ( string name );
    bool idIn ( string id );
    bool incompat ( string id );
    bool _incompat ( string id );
    bool compat ( string id );
    bool _compat ( string id );
    bool unavail ( _time from, _time to );
    bool _unavail ( _time from, _time to );
    bool avail ( _time from, _time to );
    bool _avail ( _time from, _time to );
    bool clear ( );


    //Information
    string first ( );
    string middle ( );
    string last ( );
    string id ( );
    vector<string> incompat ( );
    vector<string> compat ( );
    availability unavail ( );
    availability avail ( );



    


protected:



private:
    card info;

    bool contains ( vector<string> list, string seek );
};


#endif
