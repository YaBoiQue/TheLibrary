#pragma once

#include <iostream>
#include <iomanip>
#include <fstream>
#include <string>
#include <random>

using namespace std;

#ifndef __sudoku__H__
#define __sudoku__H__

struct txtCell
{
    int cont[3][3] = { 0 };
    int puzzVal[3][3] = { 0 };
    unsigned int numPos = 0;
    bool used[9] = { false };
};

struct nxnCell
{
    txtCell cell[3][3];
    bool vused[9][9] = { false };
    bool hused[9][9] = { false };
    int numPos = 0;
};

//3x3.cpp
void thrMain ( );
bool ThrxThrInp ( txtCell& cell );
void ThrxThrPuz ( txtCell& cell, int posX = 0, int posY = 0 );
void ThrxThrPos ( txtCell& cell, int posX = 0, int posY = 0 );

//9x9.cpp
void nineMain ( );
bool inp9x9 ( nxnCell& cell );
void puz9x9 ( nxnCell& cell, int cellX = 0, int cellY = 0 );
void puzCell ( nxnCell& puzzle, int x, int y, int posX = 0, int posY = 0 );
bool checkValid ( nxnCell& puzzle, int x, int y, int val );

//InputOutput.cpp
bool openOut ( ofstream& fout, string filename );
bool openInp ( ifstream& fin, string filename );
void tempOut ( int x, int y );
void contOut ( nxnCell& puzzle, ostream& out );
void contOut ( txtCell& puzzle, ostream& out );
void puzzOut ( nxnCell& puzzle, ostream& out );
void puzzOut ( txtCell& puzzle, ostream& out );

#endif