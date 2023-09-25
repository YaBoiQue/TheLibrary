#ifndef PLAYINGCARDSLIB_LIBRARY_H
#define PLAYINGCARDSLIB_LIBRARY_H

#include <iostream>
#include <iomanip>
#include <algorithm>
#include <random>
#include <ctime>
#include <chrono>
#include <fstream>
#include <vector>

using namespace std;

typedef  unsigned long size_type;


#ifndef PLAYINGCARDSLIB_LIBRARY_H_SUIT
#define PLAYINGCARDSLIB_LIBRARY_H_SUIT

class Suit
{
public:
    enum _suit : uint8_t
    {
        club,
        diamond [[maybe_unused]],
        heart [[maybe_unused]],
        spade [[maybe_unused]]
    };

    //De/Constructors
    Suit() = default;

    constexpr explicit Suit(const _suit& aSuit) : suit(aSuit){};
    constexpr explicit Suit(const int& val) : suit(static_cast<_suit>(val)){};
    constexpr explicit Suit(const char& val) : suit(Suit::club) {fromChar(val);};

    //Information
    [[nodiscard]] constexpr bool isBlack() const;
    [[nodiscard]] constexpr bool isRed() const;
    [[nodiscard]] constexpr int  toInt()  const;
    [[nodiscard]] constexpr char toChar() const;

    [[nodiscard]] constexpr _suit value() const;

    //Manipulation
    constexpr bool fromInt(const int& val);
    constexpr bool fromChar(const char& val);

    //Operator overloads
    Suit& operator=(const Suit& rhs) = default;
    Suit& operator=(const int& rhs);
    Suit& operator=(const char& rhs);
    int  operator*(const int& rhs) const;

    //input/output
    friend ostream& operator<<(ostream& out, const Suit& rhs);

    // Allow switch and comparisons.
    constexpr explicit operator _suit() const { return suit; }

    // Prevent usage: if(suit)
    explicit operator bool() const = delete;

    constexpr bool operator==(Suit a) const;
    constexpr bool operator!=(Suit a) const;

private:
    _suit suit;
};

#endif //PLAYINGCARDSLIB_LIBRARY_H_SUIT



#ifndef PLAYINGCARDSLIB_LIBRARY_H_CARD
#define PLAYINGCARDSLIB_LIBRARY_H_CARD

class Card {
    int _rank;   //0=ace, 1=two, 2=three, 3=four, 4=five, 5=six, 6=seven, 7=eight, 8=nine, 9=ten, 10=jack, 11=queen, 12=king
    Suit _suit;  //0=club, 2=diamond, 3=heart, 4=spade

public:
    //De/Constructors
    explicit Card(int value=0) : _rank(value % 13), _suit(value / 13) {}
    explicit Card(int rank, Suit suit ) : _rank(rank), _suit(suit) {}
    explicit Card(int rank, int suit) : _rank(rank), _suit(suit) {}
    Card(Card &&card)  noexcept : _rank(card._rank), _suit(card._suit) {}
    Card(const Card& card) = default;
    explicit Card(const Card *card) : _rank(card->_rank), _suit(card->_suit) {}

    //Manipulation
    void set(int rank, Suit suit);
    void set(int rank, int suit);

    //Information
    [[nodiscard]] constexpr int value() const;
    [[nodiscard]] constexpr Suit suit() const;
    [[nodiscard]] constexpr int rank() const;


    //Overloads
    Card& operator=(const int& rhs);
    Card& operator=(const Card& rhs) = default;
    Card& operator=(Card&& rhs) noexcept;
    bool operator==(const Card& rhs);
    bool operator!=(const Card& rhs);

    //Input/Output
    friend ostream& operator<<(ostream& out, const Card& rhs);
};
#endif //PLAYINGCARDSLIB_LIBRARY_H_CARD



#ifndef PLAYINGCARDSLIB_LIBRARY_H_NODE
#define PLAYINGCARDSLIB_LIBRARY_H_NODE

class Node
{
public:
    Card card;
    Node* next = nullptr;
    Node* prev = nullptr;

    Node() : next(nullptr), prev(nullptr) {};
    explicit Node(const Card item, Node *nptr = nullptr, Node *pptr = nullptr) :
            card(item), next(nptr), prev(pptr) {}
};

#endif //PLAYINGCARDSLIB_LIBRARY_H_NODE



#ifndef PLAYINGCARDSLIB_LIBRARY_H_DECK
#define PLAYINGCARDSLIB_LIBRARY_H_DECK
class Deck {
    Node *head{}, *tail{};

public:

#ifndef PLAYINGCARDSLIB_LIBRARY_H_DECK_ITERATOR
#define PLAYINGCARDSLIB_LIBRARY_H_DECK_ITERATOR

    class Iterator {
        friend class Deck;
        Node *_node;
        //De/Constructors
        explicit Iterator(Node *node=nullptr): _node(node){}
    public:
        Iterator() : _node(nullptr) {}

        //Operator Overloads
        Card& operator*();
        Deck::Iterator& operator+(int rhs);
        Deck::Iterator& operator-(int rhs);
        Deck::Iterator& operator++();
        const Deck::Iterator operator++(int);
        Deck::Iterator& operator--();
        const Deck::Iterator  operator--(int);

        inline friend bool operator==(const Deck::Iterator& lhs, const Deck::Iterator& rhs)
        {
            if (rhs._node->card == lhs._node->card)
            {
                return true;
            }
            return false;
        }
        inline friend bool operator!=(const Deck::Iterator& lhs, const Deck::Iterator& rhs)
        {
            if (rhs._node->card == lhs._node->card)
            {
                return false;
            }
            return true;
        }
    };

#endif //PLAYINGCARDSLIB_LIBRARY_H_DECK_ITERATOR

    //De/Constructors
    Deck() {head = tail = new Node();};
    explicit Deck(bool fill);

    Deck(const Deck& other);

    Deck(Deck&& other) noexcept ;
    ~Deck();

    //Manipulations
    void clear();
    void reset();                                       //Clears deck and fills with default values
    void shuffle(unsigned seed = 0);                    //Shuffles cards in deck
    Iterator cut(Iterator pos = Iterator(nullptr));
    static Card draw(Iterator &pos);
    static Iterator remove(Iterator pos);
    Iterator insert(const Card& in, Iterator pos);

    //Information
    [[nodiscard]] Iterator begin() const;
    [[nodiscard]] Iterator end() const;
    [[nodiscard]] constexpr size_type size() const;
    [[nodiscard]] constexpr bool empty() const;
    [[nodiscard]] static Card& peek(Iterator pos = Iterator(nullptr));
    [[nodiscard]] Iterator seek(const Card& search, Iterator start = Iterator(nullptr));

    //Conversions
    vector<Card> toVector();

    Deck& fromVector(vector<Card>& from);

    //Overloads
    Deck& operator=(const Deck& rhs);               //Sets deck equal to right hand rhs
    Deck& operator=(Deck&& rhs) noexcept;
    bool operator==(const Deck& rhs);              //Checks if deck is equal to rhs
    friend ostream& operator<<(ostream& out, const Deck& rhs);    //Export deck to ostream
    friend ifstream& operator>>(ifstream& in, Deck& rhs);                //Import deck from istream

};

#endif //PLAYINGCARDSLIB_LIBRARY_H_DECK

#endif //PLAYINGCARDSLIB_LIBRARY_H
