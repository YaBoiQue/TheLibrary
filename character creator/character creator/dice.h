#pragma once

#include <random>
#include <time.h>

using namespace std;

#ifndef __dice__H__
#define __dice__H__

//Generic die
int rollDie ( int numSides = 6);

//DnD set
int d4 ( );
int d6 ( );
int d8 ( );
int d10 ( );
int d12 ( );
int d20 ( );
int per ( );

#endif