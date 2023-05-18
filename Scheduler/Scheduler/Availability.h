#pragma once


#ifndef __Availability__H__
#define __Availability__H__

#include <vector>
#include <string>
#include <iostream>
#include <iomanip>
#include <sstream>

using namespace std;

enum days
{
    EVERYDAY, MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY, SUNDAY
};

struct _time
{
    int hour = -1;
    int minute = -1;

    bool operator== ( const _time& rhs );
};



class availability
{
public:

    struct card
    {
        _time from;
        _time to;
        days day = EVERYDAY;

        bool operator== ( const card& rhs );
    };
    

    //Con\Deconstructors
    availability ( );
    ~availability ( );


    //Manipulation
    bool insert ( _time from, _time to );
    bool remove ( int pos );
    bool remove ( card del );
    bool change ( int pos, _time from, _time to );
    void clear ( );
    bool optimize ( );


    //Information
    bool empty ( );
    int  size ( );
    bool contains ( card value );
    bool print ( );
    bool print ( ostream out );


    //Overloading

    


private:

    vector <card> cardList;


};


#endif