#define CATCH_CONFIG_MAIN
#include "catch.hpp"
#include "../deckLib.cpp"
#include <iostream>

using namespace std;

/*****************SUIT******************/
//Constructors
TEST_CASE("SUIT - constructor (uninitialized)")
{
Suit suit{};

REQUIRE(suit == Suit());
}

TEST_CASE("SUIT - constructor (initialized)")
{
Suit suit = Suit(Suit::club);
REQUIRE(suit.value() == Suit::club);

suit = Suit(Suit::diamond);
REQUIRE(suit.value() == Suit::diamond);

suit = Suit(Suit::heart);
REQUIRE(suit.value() == Suit::heart);

suit = Suit(Suit::spade);
REQUIRE(suit.value() == Suit::spade);
}

TEST_CASE("SUIT - constructor (from int)")
{
Suit suit = Suit(0);
REQUIRE(suit.value() == Suit::club);

suit = Suit(1);
REQUIRE(suit.value() == Suit::diamond);

suit = Suit(2);
REQUIRE(suit.value() == Suit::heart);

suit = Suit(3);
REQUIRE(suit.value() == Suit::spade);

suit = Suit(4);
REQUIRE(suit.value() == Suit::club);
}

TEST_CASE("SUIT - constructor (from char)")
{
Suit suit = Suit('c');
REQUIRE(suit.value() == Suit::club);

suit = Suit('d');
REQUIRE(suit.value() == Suit::diamond);

suit = Suit('h');
REQUIRE(suit.value() == Suit::heart);

suit = Suit('s');
REQUIRE(suit.value() == Suit::spade);

suit = Suit('t');
REQUIRE(suit == Suit());
}

//Information
TEST_CASE("SUIT - color detection")
{
Suit suit = Suit('c');
REQUIRE(suit.isBlack());
REQUIRE(!suit.isRed());

suit = Suit('d');
REQUIRE(!suit.isBlack());
REQUIRE(suit.isRed());

suit = Suit('s');
REQUIRE(suit.isBlack());
REQUIRE(!suit.isRed());

suit = Suit('h');
REQUIRE(!suit.isBlack());
REQUIRE(suit.isRed());
}

TEST_CASE("SUIT - conversions from suit")
{
Suit suit = Suit('c');
REQUIRE(suit.toInt() == 0);
REQUIRE(suit.toChar() == 'C');
REQUIRE(suit.value() == Suit::club);

suit = Suit('d');
REQUIRE(suit.toInt() == 1);
REQUIRE(suit.toChar() == 'D');
REQUIRE(suit.value() == Suit::diamond);

suit = Suit('s');
REQUIRE(suit.toInt() == 3);
REQUIRE(suit.toChar() == 'S');
REQUIRE(suit.value() == Suit::spade);

suit = Suit('h');
REQUIRE(suit.toInt() == 2);
REQUIRE(suit.toChar() == 'H');
REQUIRE(suit.value() == Suit::heart);
}

//Manipulations
TEST_CASE("SUIT - conversion to suit")
{
Suit suit = Suit();

suit.fromInt(0);
REQUIRE(suit.value() == Suit::club);

suit.fromChar('c');
REQUIRE(suit.value() == Suit::club);

suit.fromInt(1);
REQUIRE(suit.value() == Suit::diamond);

suit.fromChar('d');
REQUIRE(suit.value() == Suit::diamond);

suit.fromInt(2);
REQUIRE(suit.value() == Suit::heart);

suit.fromChar('h');
REQUIRE(suit.value() == Suit::heart);

suit.fromInt(3);
REQUIRE(suit.value() == Suit::spade);

suit.fromChar('s');
REQUIRE(suit.value() == Suit::spade);
}

//Operator Overloads
TEST_CASE("SUIT - operator= suit")
{
Suit suit1 = Suit('d'), suit2 = Suit('s');

suit1 = suit2;

REQUIRE(suit1 == suit2);
REQUIRE(suit1.value() == Suit::spade);
}

TEST_CASE("SUIT - operator= int")
{
Suit suit1 = Suit('d');
int suit2 = 3;

suit1 = suit2;

REQUIRE(suit1.toInt() == suit2);
REQUIRE(suit1.value() == Suit::spade);
}

TEST_CASE("SUIT - operator= char")
{
Suit suit1 = Suit('d');
char suit2 = 'S';

suit1 = suit2;

REQUIRE(suit1.toChar() == suit2);
REQUIRE(suit1.value() == Suit::spade);
}

TEST_CASE("SUIT - operator* int")
{
Suit suit = Suit('d');
int val = 11;

val = suit * val;

REQUIRE(val == 11);
}

TEST_CASE("SUIT - inequalities")
{
Suit suit1 = Suit('d'), suit2 = Suit('s');

REQUIRE(suit1 != suit2);
REQUIRE(!(suit1 == suit2));
}


/*****************CARD******************/
//Constructors
TEST_CASE("CARD - default constructor")
{
    for (int i = 0; i < 52; ++i) {
        Card card(i);

        REQUIRE(card.value() == i);
    }
}

TEST_CASE("CARD - rank(int) suit(suit) constructor")
{
    for (int i = 0; i < 4; ++i)
    {
        for (int j = 0; j < 13; ++j)
        {
            Card card(j, Suit(i));
            REQUIRE(card.value() == (i*13)+j);
        }
    }
}

TEST_CASE("CARD - rank(int) suit(int) constructor")
{
    for (int i = 0; i < 4; ++i)
    {
        for (int j = 0; j < 13; ++j)
        {
            Card card(j, i);
            REQUIRE(card.value() == (i*13)+j);
        }
    }
}

TEST_CASE("CARD - copy constructor")
{
    for (int i = 0; i < 52; ++i)
    {
        Card card1(i);
        Card card2(card1);

        REQUIRE(card1 == card2);
    }
}

TEST_CASE("CARD - pointer copy constructor")
{
    for (int i = 0; i < 52; ++i)
    {
        Card card1(i);
        Card *cardptr = &card1;
        Card card2(cardptr);

        REQUIRE(card1 == card2);
    }
}

TEST_CASE("CARD - rank(int) suit(suit) set")
{
    Card card;
    for (int i = 0; i < 4; ++i)
    {
        for (int j = 0; j < 13; ++j)
        {
            card.set(j, Suit(i));

            REQUIRE(card.value() == (i*13)+j);
        }
    }
}

TEST_CASE("CARD - rank(int) suit(int) set")
{
    Card card;
    for (int i = 0; i < 4; ++i)
    {
        for (int j = 0; j < 13; ++j)
        {
            card.set(j, i);

            REQUIRE(card.value() == (i*13)+j);
        }
    }
}

TEST_CASE("CARD - output value")
{
    for (int i = 0; i < 52; ++i)
    {
        Card card(i);
        REQUIRE(card.value() == i);
    }
}

TEST_CASE("CARD - output suit")
{
    for (int i = 0; i < 52; ++i)
    {
        Card card(i);
        REQUIRE(card.suit() == Suit(i/13));
    }
}

TEST_CASE("CARD - output rank")
{
    for (int i = 0; i < 52; ++i)
    {
        Card card(i);
        REQUIRE(card.rank() == i%13);
    }
}

TEST_CASE("CARD - operator= int")
{
    Card card;

    for (int i = 0; i < 52; ++i)
    {
        card = i;
        REQUIRE(card.value() == i);
    }
}

TEST_CASE("CARD - operator= card")
{
    Card card1;

    for (int i = 0; i < 52; ++i)
    {
        Card card2(i);
        card1 = card2;
        REQUIRE(card1.value() == i);
    }
}

TEST_CASE("CARD - operator==")
{
    for (int i = 0; i < 52; ++i)
    {
        for(int j = 0; j < 52; ++j)
        {
            Card card1(i);
            Card card2(j);

            if (i == j)
                REQUIRE(card1 == card2);
            else
                REQUIRE(card1 != card2);
        }
    }
}


/*****************NODE******************/





/***************ITERATOR****************/





/*****************DECK******************/