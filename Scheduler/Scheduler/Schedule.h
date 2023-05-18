#pragma once

#include "Employee.h"

#ifndef __Schedule__H__
#define __Schedule__H__

class schedule
{
public:

    //Con\Deconstructors
    schedule ( );
    ~schedule ( );


    //Manipulation
    bool addEmployee ( employee add );
    bool delEmployee ( int pos );
    bool delEmployee ( string id );

    bool addSchedule ( string id, _time from, _time to, days day );
    bool clearSchedule ( string id, days day = EVERYDAY );
    bool clearSchedule ( days day = EVERYDAY );

    void clear ( );



    //Information
    int size ( );
    employee at ( int pos );
    vector<employee> all ( );


protected:

    

private:

    struct node
    {
        employee info;
        vector<availability::card> scheduled[7];

        node* next = nullptr;
    };

    node* headptr = nullptr;
};


#endif