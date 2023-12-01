//
// Created by 101059445 on 10/16/2023.
//
#include "deckLib.h"
#include "list"

#ifndef CARDGAMES_SOLITAIRE_H
#define CARDGAMES_SOLITAIRE_H

class solitaire
{
    Deck tableau[7]
            {Deck(false), Deck(false), Deck(false), Deck(false),
             Deck(false), Deck(false), Deck(false)};
    Deck foundations[4]
            {Deck(false), Deck(false), Deck(false), Deck(false)};
    Deck stock = Deck(true); //Hand
    Deck talon = Deck(false); //Waste
    Deck completed[4]
            {Deck(false), Deck(false), Deck(false), Deck(false)};      //Stores completed stacks
    int tableauHidden[7]
            {0,0,0,0,0,0,0};   //Number of hidden cards in each tableau

public:
    solitaire() { reset(); }
    explicit solitaire(Deck& in)  { reset(in); }
    explicit solitaire(Deck&& in) { reset(in); }

    //Gameplay
    bool reset();
    bool reset(Deck& deck);
    bool reset(Deck&& deck);

    //Manipulation
    bool draw();                    //Draws from stock into talon
    bool tabtotab(int from, int num, int to);    //Moves from tableau to tableau
    bool tabtofou(int from, int to);    //Moves from tableau to foundation
    bool foutotab(int from, int to);    //Moves from foundation to tableau
    bool foutofou(int from, int to);    //Moves from foundation to foundation
    bool taltotab(int to);              //Moves from talon to tableau
    bool taltofou(int to);              //Moves from talon to foundation

    //Informational
    list<int> getHidden();
    int numHidden(int n);

    Card topTableau(int n);
    Card topFoundation(int n);
    Card topTalon();

    int sizeTableau(int n);
    int sizeFoundation(int n);
    int sizeTalon();
    int sizeStock();

    int sizeShown(int n);
    bool validateTableau(int n, Card card);
    bool validateFoundation(int n, Card card);

    static bool validOrder(const Card& top, const Card& bottom) ;
};

#endif //CARDGAMES_SOLITAIRE_H
