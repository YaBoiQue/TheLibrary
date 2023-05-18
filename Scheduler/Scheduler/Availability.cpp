#include "Availability.h"

availability::availability ( )
{

}

availability::~availability ( )
{

}

bool availability::insert ( _time from, _time to )
{
    //Defining variables
    card tempCard;

    //If a time value is not set
    if ( from.minute < 0 || from.minute > 59 || from.hour < 1 || from.hour > 12
        || to.minute < 0 || to.minute > 59 || to.hour < 1 || to.hour > 12 )
        return false;

    //If invalid time values
    if ( from.minute  )

    //Add times to card
    tempCard.from = from;
    tempCard.to = to;

    //Add card to list
    cardList.push_back ( tempCard );

    return true;
    
}


bool availability::remove ( int pos )
{
    //Check if card exists
    if ( int(cardList.size ( )) < ( pos + 1 ) )
        return false;

    //Erase card
    cardList.erase ( cardList.begin ( ) + pos );

    return true;
}

bool availability::remove ( card del )
{
    //Defining variables
    int i = 0;

    //Check if card exists
    if ( !contains ( del ) )
        return false;

    //Navigate to card
    while ( !( cardList.at ( i ) == del ) )
        ++i;

    //Erase card
    cardList.erase ( cardList.begin ( ) + i );

    return true;
}

bool availability::change ( int pos, _time from, _time to )
{
    //Check if card exists
    if ( int (cardList.size ( )) < ( pos + 1 ) )
        return false;

    //If a time value is not set
    if ( from.minute < 0 || from.minute > 59 || from.hour < 1 || from.hour > 12
        || to.minute < 0 || to.minute > 59 || to.hour < 1 || to.hour > 12 )
        return false;

    //Change contents
    cardList.at ( pos ).from = from;
    cardList.at ( pos ).to = to;

    return true;

}

void availability::clear ( )
{
    cardList.clear ( );
}

bool availability::optimize ( )
{
    cout << "Unfinished Function Used: availability::optimize" << endl;

    return false;
}

bool availability::empty ( )
{
    if ( cardList.empty ( ) )
        return true;
    return false;
}

int availability::size ( )
{
    return int ( cardList.size ( ) );
}

bool availability::contains ( card value )
{
    //Defining variables
    int i, size = int ( cardList.size ( ) );
    card curCard;

    for ( i = 0; i < size; ++i )
    {
        curCard = cardList.at ( i );
        if ( curCard == value )
            return true;
    }

    return false;
}

bool availability::print ( )
{
    //Defining variables
    int i, size = int ( cardList.size ( ) );
    card curCard;

    for ( i = 0; i < size; ++i )
    {
        //Set current card
        curCard = cardList.at ( i );
        
        //Set output formatting
        cout << setprecision ( 2 ) << noshowpoint;

        //Output card
        cout << "from " << curCard.from.hour << ":" << curCard.from.minute
             << " to "  << curCard.to.hour   << ":" << curCard.to.minute 
             << " on "  << curCard.day       << "\n\n";
    }

    cout << endl;

    return true;
}

bool availability::print ( ostream out )
{
    //Defining variables
    int i, size = int ( cardList.size ( ) );
    card curCard;

    for ( i = 0; i < size; ++i )
    {
        //Set current card
        curCard = cardList.at ( i );

        //Set output formatting
        out << setprecision ( 2 ) << noshowpoint;

        //Output card
        out << "from " << curCard.from.hour << ":" << curCard.from.minute
            << " to "  << curCard.to.hour   << ":" << curCard.to.minute
            << " on "  << curCard.day << "\n\n";
    }

    out << endl;

    return true;
}

bool availability::card::operator== ( const card& rhs )
{


    if ( from == rhs.from )
        if ( to == rhs.to )
            return true;

    return false;
}

bool _time::operator== ( const _time& rhs )
{
    
    if ( hour == rhs.hour )
        if ( minute == rhs.minute )
            return true;

    return false;
}