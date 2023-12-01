#include "war.h"

#ifndef __WAR__CPP__
#define __WAR__CPP__

war::war( bool set )
{
    if (set)
    {
        deck.reset();
        deck.shuffle();
    }
}


war::war(Deck& deckIn, bool start )
{
    deck = deckIn;
    if (start)
        playGame();
}


bool war::manual()
{
    //Defining variables
    int win;
    char choice;
    bool seeDeck = false;
    string filename;

    //Deck builder loop
    do
    {
        //Output options and prompt for choice
        cout << "Choose an option:\n"
             << " 1: auto fill deck\n"
             << " 2: manual fill deck\n"
             << " 3: deck from file\nChoice: ";

        cin >> choice;

        //If auto fill was selected
        if (choice == '1')
        {
            deck.reset();
        }
            //If manual fill was selected
        else if (choice == '2')
        {
            //Output beta message
            cout << "Feature still in development" << endl;
        }
            //If by file was selected
        else if (choice == '3')
        {
            //Output beta message
            cout << "Feature still in development\n\n\n" << endl;

            //Prompt for filename
            cout << "Filename: ";
            cin >> filename;

            //Open file   NEEDS TO BE CHANGED!!!!!
            ifstream fin(filename);

            //Check that file was opened correctly
            if (!fin.is_open())
            {
                //Output error text
                cout << "Could not find file, opening default deck file.\n\n\n" << endl;

                //Open default deck file
                fin.open("default.deck");

                //Check that file was opened correctly
                if (!fin.is_open())
                {
                    cout << "Failed to open file" << endl;
                    return false;
                }
            }

            //Output successfull message and read into deck
            cout << "File opened successfully" << endl;
            fin >> deck;
        }
            //If an invalid choice was made
        else
        {
            cout << "INVALID CHOICE" << endl;
        }

        cout << "\n\n\n\n\n\n\n\n\n\n\n" << endl;
    } while (choice != '1' /* && choice != '2'*/ && choice != '3' );

    choice = 0;

    do //No cheating loop
    {
        //Clear any prior inputs
        cin.clear();

        //Output prompt
        cout << "See deck order?\n 1: yes\n 2: no\n\nChoice: ";

        cin >> choice;

        //Cheats on (can see deck)
        if (choice == '1')
        {
            seeDeck = true;
        }
            //Cheats off (can not see deck)
        else if (choice == '2')
        {
            seeDeck = false;
        }
            //Output invalid choice and repeate
        else
        {
            cout << "INVALID CHOICE" << endl;
        }

        cout << "\n\n\n\n\n\n\n\n\n\n" << endl;
    } while (choice != '1' && choice != '2');

    choice = 0;

    do //Shuffle loop
    {
        choice = 0;

        //If cheats are on output deck
        if (seeDeck)
        {
            cout << deck << endl << endl;

        }
        do//Prompt for deck shuffle loop
        {
            cout << "Shuffle deck? (will repeat until 0(no) is chosen)\n 1: yes\n 0: no\n\nChoice: ";

            cin >> choice;

            //If an invalid choice was made repeat
            if (choice != '1' && choice != '0')
                cout << "INVALID CHOICE\n\n\n\n";
        } while (choice != '1' && choice != '0');
        //If shuffle was chosen
        if (choice == '1')
            deck.shuffle();

    } while (seeDeck && choice != '0');

    //play the game
    playGame();

    //check who won
    winner(win);

    //If player won
    if (win == 1)
    {
        cout << "YOU WIN!!!\nThe Game of War lasted " << rounds << " rounds!!\n\nYour final hand was:\n" << hand1 << endl;
    }
        //If bot won
    else if (win == 2)
    {
        cout << "YOU LOST!!!\nThe Game of War lasted " << rounds << " rounds!!\n\nTheir final hand was:\n" << hand2 << endl;
    }
        //If game timed out
    else
    {
        cout << "The game never ended" << endl;
    }

    return true;
}

bool war::setHands()
{
    //Defining variables
    int size = deck.size();
    Card tempCard;

    //If the deck is empty, fill it
    if (size == 0)
    {
        deck.reset();
        deck.shuffle();
    }


    //Update deck size and temporary deck
    size = deck.size();

    //Iterate through the deck and move cards to hands
    for (int i = 0; i < size; ++i)
    {
        tempCard = deck.draw(deck.begin());

        //Alternate adding cards to hands
        if (i % 2 == 0)
            hand1.insert(tempCard, hand1.begin());
        if (i % 2 == 1)
            hand2.insert(tempCard, hand2.begin());
    }

    return true;
}

bool war::playGame()
{
    setHands();

    return iterateGame();
}

bool war::iterateGame()
{

    if (hand1.empty() || hand2.empty())
        return true;

    if (!playRound())
        return false;

    ++rounds;

    return iterateGame();
}

bool war::playRound()
{
    //Defining variables
    int dif = 0;

    do
    {
        //Both players discard a card
        disc1.insert(hand1.draw(hand1.begin()), disc1.begin());
        disc2.insert(hand2.draw(hand2.begin()), disc2.begin());

        //Set difference integer
        dif = compare();

        //If tied then draw three and repeat
        if (dif == 0)
        {
            for (int i = 0; !hand1.empty() && !hand2.empty() && i < 3; ++i)
            {
                disc1.insert(hand1.draw(hand1.begin()), disc1.begin());
                disc2.insert(hand2.draw(hand2.begin()), disc2.begin());
            }
        }

    } while (dif == 0 && !hand1.empty() && !hand2.empty());

    //If hand1 won
    if (dif > 0)
    {
        while (!disc2.empty())
            hand1.insert(disc2.draw(disc2.begin()), hand1.end());

        while (!disc1.empty())
            hand1.insert(disc1.draw(disc1.begin()), hand1.end());

        return true;
    }
    //If hand2 won
    else if (dif < 0)
    {
        while (!disc1.empty())
            hand2.insert(disc1.draw(disc1.begin()), hand2.end());

        while (!disc2.empty())
            hand2.insert(disc2.draw(disc2.begin()), hand2.end());

        return true;
    }

    //If a hand1 ran out during a tie
    if (hand1.empty())
    {
        while (!disc2.empty())
            hand1.insert(disc2.draw(disc2.begin()), hand1.end());

        while (!disc1.empty())
            hand1.insert(disc1.draw(disc1.begin()), hand1.end());

        return true;
    }

    //Else hand2 ran out during a tie
    while (!disc1.empty())
        hand2.insert(disc1.draw(disc1.begin()), hand2.end());

    while (!disc2.empty())
        hand2.insert(disc2.draw(disc2.begin()), hand2.end());

    return true;
}

int war::compare()
{
    //Defining variables
    int rank1 = disc1.peek(disc1.begin()).rank(), rank2 = disc2.peek(disc2.begin()).rank();
    int dif;

    //If aces, set as high cards
    if (rank1 == 0)
        rank1 += 13;
    if (rank2 == 0)
        rank2 += 13;

    //Find the difference between the values
    dif = rank1 - rank2;

    return dif;
}

bool war::winner(int& player)
{
    //If both hands are empty return false
    if (hand1.empty() && hand2.empty())
    {
        player = 0;
        return false;
    }
    //If hand 1 is empty player 2 wins
    if (hand1.empty())
    {
        player = 2;
        return true;
    }
    //If hand 2 is empty player 1 wins
    if (hand2.empty())
    {
        player = 1;
        return true;
    }

    //No hands were empty, return false
    player = 0;
    return false;
}

int war::numRounds()
{
    return rounds;
}

Deck war::hand(bool player /*true for 1, false for 2*/)
{
    //return selected hand
    if (player)
        return hand1;
    return hand2;
}


#endif