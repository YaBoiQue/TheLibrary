#include "Employee.h"

using namespace std;




employee::employee ( )
{

}


employee::~employee ( )
{

}


bool employee::firstIn ( string name )
{
    info.fName = name;

    return true;
}


bool employee::middleIn ( string name )
{
    info.mName = name;

    return true;
}


bool employee::lastIn ( string name )
{
    info.lName = name;

    return true;
}


bool employee::idIn ( string id )
{
    info.id = id;

    return true;
}


bool employee::incompat ( string id )
{
    if ( contains ( info.compat, id ) )
        return false;

    info.incompat.push_back ( id );

    return true;
}


bool employee::_incompat ( string id )
{
    //Defining variables
    int i = 0;

    //Check if vector contains id
    if ( !contains ( info.incompat, id ) )
        return false;

    //Find position of id
    while ( info.incompat.at ( i ) != id )
        ++i;

    info.incompat.erase ( info.incompat.begin ( ) + i );

    return true;
}


bool employee::compat ( string id )
{
    if ( contains ( info.incompat, id ) )
        return false;

    info.compat.push_back ( id );

    return true;
}


bool employee::_compat ( string id )
{
    //Defining variables
    int i = 0;

    //Check if vector contains id
    if ( !contains ( info.compat, id ) )
        return false;

    //Find position of id
    while ( info.compat.at ( i ) != id )
        ++i;

    info.compat.erase ( info.compat.begin ( ) + i );

    return true;
}


bool employee::unavail ( _time from, _time to )
{
    info.unavail.insert ( from, to );

    return true;
}
bool employee::_unavail ( _time from, _time to )
{
    availability::card tempCard;
    
    tempCard.from = from;
    tempCard.to = to;

    if ( !info.unavail.contains ( tempCard ) )
        return false;

    info.unavail.remove ( tempCard );

    return true;
}
bool employee::avail ( _time from, _time to )
{
    info.avail.insert ( from, to );

    return true;
}
bool employee::_avail ( _time from, _time to )
{
    availability::card tempCard;

    tempCard.from = from;
    tempCard.to = to;

    if ( !info.avail.contains ( tempCard ) )
        return false;

    info.avail.remove ( tempCard );

    return true;
}
bool employee::clear ( )
{
    //Clear all non-static employee info
    info.compat.clear ( );
    info.incompat.clear ( );
    info.avail.clear ( );
    info.unavail.clear ( );

    return true;
}

string employee::first ( )
{
    return info.fName;
}

string employee::middle ( )
{
    return info.mName;
}

string employee::last ( )
{
    return info.lName;
}

string employee::id ( )
{
    return info.id;
}

vector<string> employee::incompat ( )
{
    return info.incompat;
}

vector<string> employee::compat ( )
{
    return info.compat;
}

availability employee::unavail ( )
{
    return info.avail;
}

availability employee::avail ( )
{
    return info.avail;
}


bool employee::contains ( vector<string> list, string seek )
{
    //Defining variables
    int i, size = int ( list.size ( ) );

    for ( i = 0; i < size; ++i )
    {
        if ( seek == list.at ( i ) )
            return true;
    }

    return false;
}