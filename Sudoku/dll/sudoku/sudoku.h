#pragma once

#include <vector>
#include <iostream>
#include <fstream>
#include <cmath>

using namespace std;

#ifndef __sudoku__H__
#define sudokuDLL_API __declspec(dllexport)

class sudokuDLL_API sudokuList
{

public:
    struct puzzle
    {
        vector<vector<int>> cont;
        vector<vector<bool>> usedH;
        vector<vector<bool>> usedV;
        vector<vector<bool>> usedC;
        int possNum = 0;
        int size = 0;
        puzzle* next;
    };

    //Constructors/Deconstructor
    sudokuList ( );
    sudokuList ( sudokuList& s );
    ~sudokuList ( );

    //Iterator

    //Modifiers
    bool assign ( puzzle input );
    bool insert ( puzzle input );
    bool erase ( int num );
    bool pop ( puzzle output );

    bool resize ( int size );
    void clear ( );
    bool solve ( int num );

    //Information
    int size ( );
    bool empty ( );
    vector<int> seek ( int pos );
    vector<vector<int>> cont ( );
    


private:

    puzzle* tailptr;
    puzzle* temp;
};

#endif