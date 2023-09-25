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

class Suit {
public:
    enum _suit : uint8_t {
        club,
        diamond [[maybe_unused]],
        heart [[maybe_unused]],
        spade [[maybe_unused]]
    };

    //De/Constructors
    Suit() = default;

    constexpr explicit Suit(const _suit &aSuit) : suit(aSuit) {};

    constexpr explicit Suit(const int &val) : suit(static_cast<_suit>((val % 4))) {};

    constexpr explicit Suit(const char &val) : suit(Suit::club) { fromChar(val); };

    //Information
    [[nodiscard]] constexpr bool isBlack() const;

    [[nodiscard]] constexpr bool isRed() const;

    [[nodiscard]] constexpr int toInt() const;

    [[nodiscard]] constexpr char toChar() const;

    [[nodiscard]] constexpr _suit value() const;

    //Manipulation
    constexpr bool fromInt(const int &val);

    constexpr bool fromChar(const char &val);

    //Operator overloads
    Suit &operator=(const Suit &rhs) = default;

    Suit &operator=(const int &rhs);

    Suit &operator=(const char &rhs);

    int operator*(const int &rhs) const;

    //input/output
    friend ostream &operator<<(ostream &out, const Suit &rhs);

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
    explicit Card(int value=0) : _rank(value % 13), _suit((value % 52) / 13) {}
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
    bool operator==(const Card& rhs) const;
    bool operator!=(const Card& rhs) const;

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


typedef Deck::Iterator Iterator;

#ifndef PLAYINGCARDSLIB_LIBRARY_CPP_SUIT
#define PLAYINGCARDSLIB_LIBRARY_CPP_SUIT

//Information
constexpr bool Suit::isBlack() const
{
    //Return true if club or spade
    return ((suit == club) || (suit == spade));
}

constexpr bool Suit::isRed() const
{
    //Return true if heart or diamond
    return ((suit == heart) || (suit == diamond));
}

constexpr int Suit::toInt() const
{
    //Returns integer value of suit
    return static_cast<int>(suit);
}

constexpr char Suit::toChar() const
{
    //Returns character value of suit
    switch (suit)
    {
        case club:
            return 'C';
        case diamond:
            return 'D';
        case heart:
            return 'H';
        case spade:
            return 'S';
        default:
            return 'E';
    }
}

//Manipulations
constexpr bool Suit::fromInt(const int &val)
{
    //Sets suit value from int
    if (val > 3) { return false; }
    suit = static_cast<_suit>(val);

    return true;
}

constexpr bool Suit::fromChar(const char &val)
{
    //Sets suit value from character
    switch(toupper(val)){
        case 'C':
            suit = club;
            break;
        case 'D':
            suit = diamond;
            break;
        case 'H':
            suit = heart;
            break;
        case 'S':
            suit = spade;
            break;
        default:
            return false;
    }
    return true;
}

//Overload Operators
Suit& Suit::operator=(const int &rhs)
{
    //Set suit
    fromInt(rhs);

    return *this;
}

Suit &Suit::operator=(const char &rhs)
{
    //Set suit
    fromChar(rhs);

    return *this;
}

int Suit::operator*(const int &rhs) const
{
    //Convert current suit to integer
    int tmp = toInt();

    //Multiply for result and return
    tmp = tmp * rhs;
    return tmp;
}

constexpr bool Suit::operator==(Suit a) const
{
    //Return if values are equal
    return suit == a.suit;
}

constexpr bool Suit::operator!=(Suit a) const
{
    //Return if values are unequal
    return suit != a.suit;
}

//Input/Output
ostream &operator<<(ostream &out, const Suit &rhs)
{
    //Output suit as character
    out << rhs.toChar();

    //Return output stream
    return out;
}

constexpr Suit::_suit Suit::value() const {
    return suit;
}


#endif //PLAYINGCARDSLIB_LIBRARY_CPP_SUIT


#ifndef PLAYINGCARDSLIB_LIBRARY_CPP_CARD
#define PLAYINGCARDSLIB_LIBRARY_CPP_CARD

void Card::set(int rank, Suit suit)
{
    //Set rank and suit
    rank = rank % 13;
    _rank = rank;
    _suit = suit;
}

void Card::set(int rank, int suit)
{
    //Set rank and suit
    rank = rank % 13;
    suit = suit % 4;
    _rank = rank;
    _suit = suit;
}

constexpr int Card::value() const
{
    //Return calculated card value
    return _rank + (_suit.toInt() * 13);
}

constexpr Suit Card::suit() const
{
    //Return card suit
    return _suit;
}

constexpr int Card::rank() const
{
    //Return card rank
    return _rank;
}

Card &Card::operator=(const int &rhs)
{
    //Set rank and suit
    _rank = (rhs % 52) % 13;
    _suit = (rhs % 52) / 13;

    return *this;
}

Card &Card::operator=(Card &&rhs) noexcept
{
    if (this == &rhs)
        return *this;

    //Set rank and suit
    _rank = rhs._rank;
    _suit = rhs._suit;

    return *this;
}

bool Card::operator==(const Card &rhs) const
{
    //If suits are equal
    if (_suit == rhs._suit)
        //If ranks are equal
        if(_rank == rhs._rank)
            //Return true
            return true;
    //else return false
    return false;
}

bool Card::operator!=(const Card& rhs) const
{
    //If suits are equal
    if (_suit == rhs._suit)
        //If ranks are equal
        if(_rank == rhs._rank)
            //Return false
            return false;
    //else return true
    return true;
}

ostream &operator<<(ostream &out, const Card &rhs)
{
    //Output card value
    out << setfill(' ') << setw(2) << rhs.value();

    //Output suit
    out << rhs.suit();

    //Return output stream
    return out;
}

inline ostream &operator<<(ostream &out, const Deck &rhs)
{
    //Get beginning iterator
    Iterator tmpIt = rhs.begin();

    //While not at the end iterator
    while(tmpIt != rhs.end())
    {
        //Output card at iterator
        out << *tmpIt;
        tmpIt++;
    }

    //Return output stream
    return out;
}

ifstream &operator>>(ifstream &in, Deck &rhs)
{
    //Defining variables
    int tempInt;
    Card tempCard;

    //While cards can still be read from the file
    while (in >> tempInt)
    {
        //Insert card into deck
        tempCard = Card(tempInt);
        rhs.insert(tempCard, rhs.end());
    }

    //Return input stream
    return in;
}

#endif //PLAYINGCARDSLIB_LIBRARY_CPP_CARD


#ifndef PLAYINGCARDSLIB_LIBRARY_CPP_ITERATOR
#define PLAYINGCARDSLIB_LIBRARY_CPP_ITERATOR

Card &Deck::Iterator::operator*()
{
    //Return card value
    return _node->next->card;
}

Iterator &Deck::Iterator::operator+(int rhs)
{
    //Increment iterator by rhs
    for (int i = 0; i < rhs; ++i)
    {
        _node = _node->next;
    }

    return *this;
}

Iterator &Deck::Iterator::operator-(int rhs)
{
    //Decrement iterator by rhs
    for (int i = 0; i < rhs; ++i)
    {
        _node = _node->prev;
    }

    return *this;
}

Deck::Iterator &Deck::Iterator::operator++()
{
    //Prefix increment iterator
    _node = _node->next;
    return *this;
}

const Iterator Deck::Iterator::operator++(int)
{
    //Prefix increment iterator
    Iterator tmp = *this;
    _node = _node->next;
    return tmp;
}

Deck::Iterator &Deck::Iterator::operator--()
{
    //Postfix decrement iterator
    _node = _node->prev;
    return *this;
}

const Iterator Deck::Iterator::operator--(int)
{
    //Postfix decrement iterator
    Iterator tmp = *this;
    _node = _node->prev;
    return tmp;
}

#endif


#ifndef PLAYINGCARDSLIB_LIBRARY_CPP_DECK
#define PLAYINGCARDSLIB_LIBRARY_CPP_DECK

//De/Constructors
Deck::Deck(bool fill)
{
    //Set head and tail as null
    head = tail = new Node();

    //If fill is true then add cards
    if (fill)
        reset();
}

Deck::Deck(const Deck& old)
{
    //Defining variables
    Node *copyptr = old.head;

    //While ptr isn't null
    while (copyptr != nullptr)
    {
        //Copy card from old deck to new
        insert(copyptr->card, end());
        copyptr = copyptr->next;
    }
}

Deck::Deck(Deck&& old) noexcept
{
    //Defining variables
    Node *copyptr = old.head;

    //While ptr isn't null
    while (copyptr != nullptr)
    {
        //Copy card from old deck to new
        insert(copyptr->card, end());
        copyptr = copyptr->next;
    }
}

Deck::~Deck()
{
    //Defining variables
    Node *tmpptr;

    //While head isn't null
    while (head != nullptr)
    {
        //Set tmpptr to head and increment head
        tmpptr = head;
        head = head->next;
        //Delete tmpptr
        delete tmpptr;
    }

    //Set tail to null
    tail = nullptr;
}

//Manipulations
void Deck::clear()
{
    //Defining variables
    Node *tmpptr;

    //While head isn't null
    while(head != nullptr)
    {
        //Set tmpptr to head and increment head
        tmpptr = head;
        head = head->next;
        //Delete tmpptr
        delete tmpptr;
    }

    //Set tail to null
    tail = nullptr;
}

void Deck::reset()
{
    //Clear the deck of cards
    clear();

    //Fill the deck with cards ascending
    for (int i = 0; i < 52; ++i)
        insert(Card(i), end());
}

Card Deck::draw(Iterator& pos)
{
    //Defining variables
    Node *ptr = pos._node->next;
    Card card = Card(ptr->card);

    //Ghost node
    pos._node->next = ptr->next;
    ptr->next->prev = ptr->prev;
    ptr->prev->next = ptr->next;

    //Delete node and return card
    delete ptr;
    return card;
}

Iterator Deck::remove(Iterator pos)
{
    //Defining variables
    Node *ptr = pos._node->next;

    //Ghost node
    pos._node->next = ptr->next;
    ptr->next->prev = ptr->prev;
    ptr->prev->next = ptr->next;

    //Delete node and return iterator
    delete ptr;
    return pos;
}

Iterator Deck::insert(const Card &in, Iterator pos)
{
    //Defining variables
    Node *newNode = new Node(Card(in), pos._node->next, pos._node);

    //If at tail then set tail
    if (pos._node == tail) tail = newNode;

    //Insert node
    pos._node->next->prev = newNode;
    pos._node->next = newNode;

    //Return iterator to node
    return pos;
}

//Information
Deck::Iterator Deck::begin() const
{
    //Return iterator to
    return Iterator(head);
}

Deck::Iterator Deck::end() const
{
    //Return iterator to tail
    return Iterator(tail);
}

constexpr size_type Deck::size() const
{
    //Defining variables
    Node *tmpptr = head;
    size_type size = 0;

    //While tmpptr isn't null
    while (tmpptr != nullptr)
    {
        //Increment size and ptr
        ++size;
        tmpptr = tmpptr->next;
    }

    //Return size
    return size;
}

constexpr bool Deck::empty() const
{
    //If head is null return true
    if (head == nullptr)
        return true;

    //Else return false
    return false;
}

Card &Deck::peek(Iterator pos)
{
    //Return card at iterator
    return *pos;
}

Iterator Deck::seek(const Card &card, Iterator start)
{
    //If start is set keep it else set with begin
    start = (start == Iterator(nullptr)) ? begin() : start;
    Iterator tmpIt = start;

    //While not at the tail
    while (tmpIt._node->next != tail)
    {
        //If search is found
        if (tmpIt._node->next->card == card)
        {
            //Return iterator to card
            return tmpIt;
        }
    }

    //Else return null iterator
    return Iterator(nullptr);
}

//Overloads
Deck& Deck::operator=(const Deck& rhs)
{
    //Defining variables
    Node *tmpptr = rhs.head;

    if (this == &rhs)
        return *this;

    //Clear lhs deck
    clear();

    //While not at end of rhs
    while(tmpptr != nullptr)
    {
        //Insert card into lhs
        insert(tmpptr->card, end());
        tmpptr = tmpptr->next;
    }

    //Return lhs
    return *this;
}

Deck &Deck::operator=(Deck &&rhs) noexcept
{
    if (this == &rhs)
        return *this;

    //Defining variables
    Node *tmpptr = rhs.head;

    //Clear lhs deck
    clear();

    //While not at end of rhs
    while(tmpptr != nullptr)
    {
        //Insert card into lhs
        insert(tmpptr->card, end());
        tmpptr = tmpptr->next;
    }

    //Return lhs
    return *this;
}

bool Deck::operator==(const Deck& rhs)
{
    //Defining variables
    size_type deckSize = size();
    Node *lhsptr = head;
    Node *rhsptr = rhs.head;

    //If both are empty return true
    if (empty())
    {
        if (rhs.empty())
            return true;
        return false;
    }
    //Else if one is empty return false
    if (rhs.empty())
        return false;

    //If sizes are different return false
    if (deckSize != rhs.size())
        return false;

    //While neither side is at the end
    while(lhsptr != nullptr && rhsptr != nullptr)
    {
        //If cards are not equal return false
        if (lhsptr->card != rhsptr->card)
        {
            return false;
        }

        //Else increment and repeat
        lhsptr = lhsptr->next;
        rhsptr = rhsptr->next;
    }

    //Return true
    return true;
}

void Deck::shuffle(unsigned int seed)
{
    vector<Card> list = toVector();

    seed = (seed == 0) ? chrono::system_clock::now().time_since_epoch().count() : seed;

    std::shuffle(list.begin(), list.end(), default_random_engine(seed));
}

vector<Card> Deck::toVector()
{
    Iterator tmpIt = begin();
    vector<Card> result;

    while (tmpIt._node->next != tail)
    {
        result.insert(result.end(), *tmpIt);
        tmpIt++;
    }

    return result;
}

Deck &Deck::fromVector(vector<Card> &from)
{
    //Defining variables
    size_type size = from.size();

    //Clear deck
    clear();

    //Step through list and insert cards into deck
    for (int i = 0; i < size; ++i)
    {
        insert(from.front(), end());
        from.erase(from.begin());
    }

    return *this;
}

Iterator Deck::cut(Iterator pos) {
    head->prev = tail;
    tail->next = head;

    head = pos._node->next;
    tail = pos._node->next->prev;

    return pos;
}

#endif //PLAYINGCARDSLIB_LIBRARY_CPP_DECK