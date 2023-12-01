//
// Created by 101059445 on 10/16/2023.
//
#include "solitaire.h"


bool solitaire::reset() {
    Deck deck = Deck(true);

    return reset(deck);
}

bool solitaire::reset(Deck& deck) {

    stock = deck;

    for (int i = 0; i < 7; ++i)
    {
        for (int j = 0; j <= i; ++j)
        {
            if (!tableau[i].insert(stock.draw(stock.begin()),tableau[i].begin()))
                return false;
        }

        tableauHidden[i] = i;
    }

    return true;
}

bool solitaire::reset(Deck &&deck) {
    return reset(deck);
}

bool solitaire::draw()
{
    Card card;

    if(stock.empty())
    {
        if (talon.empty())
            return false;
        while(!talon.empty())
            stock.insert(talon.draw(talon.rend()), stock.begin());
    }

    card = stock.draw(stock.rend());
    talon.insert(card, talon.begin());

    return true;
}

bool solitaire::tabtotab(int from, int num, int to) {
    vector<Card> cards;
    Card prevCard, curCard;

    //check if enough cards visible
    if (sizeShown(from) < num)
        return false;

    //check if card list valid
    prevCard = tableau[from].peek(tableau[from].begin());

    for (int i = 1; i < num; ++i)
    {
        curCard = tableau[from].peek(tableau[from].begin() + i);

        if(!validOrder(curCard, prevCard))
        {
            return false;
        }

        prevCard = curCard;
    }

    //Check if location is valid
    if (!tableau[to].empty())
    {
        if (!validateTableau(to, tableau[from].peek(tableau[from].begin() + num - 1)))
            return false;
    }

    //Move cards
    for (int i = 0; i < num; ++i)
    {
        if(!tableau[to].insert(tableau[from].draw(tableau[from].begin()), tableau[to].begin() + i))
            return false;
    }

    return true;
}

bool solitaire::validOrder(const Card& top, const Card& bottom) {
    bool isRed = top.suit().isRed();
    int rank = top.rank();

    if (isRed == bottom.suit().isRed())
    {
        if (rank == (bottom.rank() + 1))
        {
            return true;
        }
    }
    return false;
}

bool solitaire::tabtofou(int from, int to) {

    if (foundations[to].empty())
    {
        if(tableau[from].peek(tableau[from].begin()).rank() == 0)
        {
            foundations[to].insert(tableau[from].draw(tableau[from].begin()), foundations[to].begin());
            return true;
        }
        return false;
    }

    if (tableau[from].peek(tableau[from].begin()).suit() == foundations[to].peek(foundations[to].begin()).suit())
    {
        if (tableau[from].peek(tableau[from].begin()).rank() != (foundations[to].peek(foundations[to].begin()).rank()+1))
        {
            return false;
        }
    }

    foundations[to].insert(tableau[from].draw(tableau[from].begin()), foundations[to].begin());
    return true;
}

bool solitaire::foutotab(int from, int to) {

    //Check if location is valid
    if (!tableau[to].empty())
    {
        if (!validateTableau(to, foundations[from].peek(foundations[from].begin())))
            return false;
    }

    tableau[to].insert(foundations[from].draw(foundations[from].begin()), tableau[to].begin());
    return true;
}
