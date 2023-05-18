#pragma once

#include <iostream>

using namespace std;

#ifndef __medication__H__
#define __medication__H__

class medication
{
public:
    //Structures
    struct infoStruct
    {

    };

    //Con/Deconstructor
    medication ( );
    ~medication ( );

    //Modifiers
    bool insert ( infoStruct ins );
    bool erase ( infoStruct rem );
    bool clear ( );

    //Access
    infoStruct operator[] ( int num );
    infoStruct at ( int num );
    int find ( infoStruct info );
    bool contains ( infoStruct info );

    //Capacity
    int size ( );
    bool empty ( );
    
    //Contents


private:

};


#endif