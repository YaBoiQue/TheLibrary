#include "Schedule.h"

using namespace std;

schedule::schedule ( )
{
    headptr = nullptr;
}

schedule::~schedule ( )
{
    //Defining variables
    node* tempptr = headptr;

    //While not at the last item
    while ( tempptr != nullptr )
    {
        headptr = headptr->next;
        delete tempptr;
        tempptr = headptr;
    }
}

bool schedule::addEmployee ( employee info )
{
    //defining variables
    node* tempptr = headptr;

    //If list is empty
    if ( tempptr == nullptr )
    {
        //Allocate node, add info and return
        headptr = new ( nothrow ) node;
        if ( headptr == nullptr )
            return false;

        headptr->info = info;

        return true;
    }

    //Navigate to the end of the list
    while ( tempptr->next != nullptr )
        tempptr = tempptr->next;

    //Allocate new node and add info
    tempptr->next = new ( nothrow ) node;
    if ( tempptr->next == nullptr )
        return false;

    tempptr->next->info = info;

    return true;
}

bool schedule::delEmployee ( int pos )
{
    //Defining variables
    node* prev = headptr;
    node* cur = headptr;
    int i;

    //If position is past the end of list
    if ( size ( ) < ( pos + 1 ) )
        return false;

    //Navigate to position
    for ( i = 0; i < pos; ++i )
    {
        prev = cur;
        cur = cur->next;
    }

    //If still at first node
    if ( prev == cur )
    {
        headptr = headptr->next;
        delete cur;

        return true;
    }

    prev->next = cur->next;
    delete cur;

    return true;
}

bool schedule::delEmployee ( string id )
{
    //Defining variables
    node* prev = headptr;
    node* cur = headptr;

    //If list is empty
    if ( headptr == nullptr )
        return false;

    //Navigate to id
    while ( cur != nullptr && cur->info.id() != id )
    {
        prev = cur;
        cur = cur->next;
    }

    //If navigated past list
    if ( cur = nullptr )
    {
        return false;
    }

    //If still at begining
    if ( prev = cur )
    {
        headptr = headptr->next;
        delete cur;

        return true;
    }

    prev->next = cur->next;
    delete cur;

    return true;
}

bool schedule::addSchedule ( string id, _time from, _time to, days day )
{
    //Defining variables
    node* temp = headptr;
    availability::card tempCard;
    int i;

    //Setting values
    tempCard.day = day;
    tempCard.from = from;
    tempCard.to = to;

    //While not at the end check for id
    while ( temp != nullptr && temp->info.id ( ) != id )
        temp = temp->next;

    //If at the end of the list
    if ( temp == nullptr )
        return false;

    //If to set to everyday
    if ( day == 0 )
        for ( i = 0; i < 7; ++i )
            temp->scheduled[i].push_back ( tempCard );

    //Add card to list on day
    temp->scheduled[day - 1].push_back ( tempCard );

    return true;
}

bool schedule::clearSchedule ( string id, days day )
{
    //Defining variables
    node* temp = headptr;

    //While not at the end check for id
    while ( temp != nullptr && temp->info.id ( ) != id )
        temp = temp->next;

    //If at the end of the list
    if ( temp == nullptr )
        return false;

    if ( day == 0 )
        temp->scheduled->clear ( );

    temp->scheduled[day - 1].clear ( );

    return true;
}

bool schedule::clearSchedule ( days day )
{
    //Defining variables
    node* temp = headptr;

    //While not at the end of the list
    while ( temp != nullptr )
    {
        if ( day == 0 )
            temp->scheduled->clear ( );
        else
            temp->scheduled[day - 1].clear ( );

        temp = temp->next;
    }

    return true;
}

void schedule::clear ( )
{
    //Defining variables
    node* temp = headptr;

    while ( temp != nullptr )
    {
        headptr = headptr->next;
        delete temp;

        temp = headptr;
    }
}

int schedule::size ( )
{
    //Defining variables
    int i = 0;
    node* temp = headptr;

    //Navigate to end of list
    while ( temp != nullptr )
    {
        temp = temp->next;
        ++i;
    }

    return i;
}

employee schedule::at ( int pos )
{
    //Defining variables
    node* temp = headptr;
    int i;

    //If position will overnavigate
    if ( pos > size ( ) )
        return employee ( );

    //Navigate to position
    for ( i = 0; temp != nullptr && i < pos; ++i )
    {
        temp = temp->next;
    }

    //If at the end of list
    if ( temp == nullptr )
        return employee ( );

    return temp->info;
}

vector<employee> schedule::all ( )
{
    //Defining variables
    vector<employee> empList;
    node* temp = headptr;

    //While not at the end of list, add to vector
    while ( temp != nullptr )
    {
        empList.push_back ( temp->info );
    }

    return empList;
}
