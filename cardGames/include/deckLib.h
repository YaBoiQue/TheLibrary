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

    explicit Suit(const _suit &aSuit) : suit(aSuit) {};

    explicit Suit(const int &val) : suit(static_cast<_suit>((val % 4))) {};

    explicit Suit(const char &val) : suit(Suit::club) { fromChar(val); };

    //Information
    [[nodiscard]] bool isBlack() const;

    [[nodiscard]] bool isRed() const;

    [[nodiscard]] int toInt() const;

    [[nodiscard]] char toChar() const;

    [[nodiscard]] _suit value() const;

    //Manipulation
    bool fromInt(const int &val);

    bool fromChar(const char &val);

    //Operator overloads
    Suit &operator=(const Suit &rhs) = default;

    Suit &operator=(const int &rhs);

    Suit &operator=(const char &rhs);

    int operator*(const int &rhs) const;

    //input/output
    friend ostream &operator<<(ostream &out, const Suit &rhs);

    // Allow switch and comparisons.
    explicit operator _suit() const { return suit; }

    // Prevent usage: if(suit)
    explicit operator bool() const = delete;

    bool operator==(Suit a) const;

    bool operator!=(Suit a) const;

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
    [[nodiscard]] int value() const;
    [[nodiscard]] Suit suit() const;
    [[nodiscard]] int rank() const;
    [[nodiscard]] string ranktochar() const;

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
    struct Iterator;
    struct ReverseIterator;
    struct ConstantIterator;

#ifndef PLAYINGCARDSLIB_LIBRARY_H_DECK_ITERATOR
#define PLAYINGCARDSLIB_LIBRARY_H_DECK_ITERATOR
    struct Iterator {
        friend class Deck;

        using iterator_category = bidirectional_iterator_tag;
        using difference_type   = ptrdiff_t;
        using value_type        = Node;
        using pointer           = Node*;
        using reference         = Card&;

        //De/Constructors
        Iterator(pointer ptr) { _node = ptr; }
        Iterator(ReverseIterator rit) {_node = rit._node;}

        //Reference operators
        reference operator*()  { return _node->card;}
        pointer   operator->() { return _node;}

        //Prefix in/decrement
        Deck::Iterator& operator++() { _node = _node->next; return *this; }
        Deck::Iterator& operator--() { _node = _node->prev; return *this; }

        //Postfix in/decrement
        Deck::Iterator operator++(int) { Iterator tmp = *this; ++(*this); return tmp; }
        Deck::Iterator operator--(int) { Iterator tmp = *this; --(*this); return tmp; }

        friend bool operator== (const Iterator& a, const Iterator& b) { return a._node == b._node; }
        friend bool operator!= (const Iterator& a, const Iterator& b) { return a._node != b._node; }

        Deck::Iterator& operator+(int rhs);
        Deck::Iterator& operator-(int rhs);

        Deck::Iterator& operator=(ReverseIterator rhs) {_node = rhs._node; return *this;}

    private:
        pointer _node;

    };

    struct ReverseIterator {
        friend class Deck;

        using iterator_category = bidirectional_iterator_tag;
        using difference_type   = ptrdiff_t;
        using value_type        = Node;
        using pointer           = Node*;
        using reference         = Card&;

        //De/Constructors
        ReverseIterator(pointer ptr) { _node = ptr; }
        ReverseIterator(Iterator it) { _node = it._node;}

        //Reference operators
        reference operator*()  { return _node->card;}
        pointer   operator->() { return _node;}

        //Prefix in/decrement
        Deck::ReverseIterator& operator++() { _node = _node->prev; return *this; }
        Deck::ReverseIterator& operator--() { _node = _node->next; return *this; }

        //Postfix in/decrement
        Deck::ReverseIterator operator++(int) { ReverseIterator tmp = *this; ++(*this); return tmp; }
        Deck::ReverseIterator operator--(int) { ReverseIterator tmp = *this; --(*this); return tmp; }

        friend bool operator== (const ReverseIterator& a, const ReverseIterator& b) { return a._node == b._node; }
        friend bool operator!= (const ReverseIterator& a, const ReverseIterator& b) { return a._node != b._node; }


        Deck::ReverseIterator& operator=(Iterator rhs) {_node = rhs._node; return *this;}
    private:
        pointer _node;

    };


    struct ConstantIterator {
        friend class Deck;

        using iterator_category = forward_iterator_tag;
        using difference_type   = ptrdiff_t;
        using value_type        = Node;
        using pointer           = Node*;
        using reference         = Card&;

        //De/Constructors
        ConstantIterator(pointer ptr): _node(ptr) {}
        ConstantIterator(Iterator it): _node(it._node) {}
        ConstantIterator(ReverseIterator rit): _node(rit._node) {}

        //Reference operators
        reference operator*()  const {return _node->card;}
        pointer   operator->() const { return _node;}

        //Prefix in/decrement
        Deck::ConstantIterator& operator++() { _node->next; return *this; }
        Deck::ConstantIterator& operator--() { _node->prev; return *this; }

        //Postfix in/decrement
        Deck::ConstantIterator operator++(int) { ConstantIterator tmp = *this; ++(*this); return tmp; }
        Deck::ConstantIterator operator--(int) { ConstantIterator tmp = *this; --(*this); return tmp; }

        friend bool operator== (const ConstantIterator& a, const ConstantIterator& b) { return a._node == b._node; }
        friend bool operator!= (const ConstantIterator& a, const ConstantIterator& b) { return a._node != b._node; }


        Deck::ConstantIterator& operator=(Iterator rhs) {_node = rhs._node; return *this;}
        Deck::ConstantIterator& operator=(ReverseIterator rhs) {_node = rhs._node; return *this;}
    private:
        pointer _node;

    };

#endif //PLAYINGCARDSLIB_LIBRARY_H_DECK_ITERATOR

    //De/Constructors
    Deck(bool fill = false);

    Deck(const Deck& other);

    Deck(Deck&& other) noexcept ;
    ~Deck();

    //Manipulations
    void clear();
    void reset();                                       //Clears deck and fills with default values
    void shuffle(unsigned seed = 0);                    //Shuffles cards in deck
    Iterator cut(Iterator pos = Iterator(nullptr));
    Card draw(Iterator pos);
    Iterator remove(Iterator pos);
    bool insert(const Card& in, Iterator pos);

    //Information
    [[nodiscard]] Iterator          begin() const   { return {head->next};}
    [[nodiscard]] Iterator          end()   const   { return {tail};}
    [[nodiscard]] ConstantIterator  cbegin()        { return {head->next};}
    [[nodiscard]] ConstantIterator  cend()          { return {tail};}
    [[nodiscard]] ReverseIterator   rbegin()        { return {tail->prev};}
    [[nodiscard]] ReverseIterator   rend()          { return {head};}
    [[nodiscard]] size_type size() const;
    [[nodiscard]] bool empty() const;
    [[nodiscard]] Card& peek(Iterator pos);
    [[nodiscard]] Iterator seek(const Card& search, Iterator start = Iterator(nullptr));

    //Conversions
    vector<Card> toVector();

    Deck& fromVector(vector<Card>& from);

    //Overloads
    Deck& operator=(const Deck& rhs);               //Sets deck equal to right hand rhs
    Deck& operator=(Deck&& rhs) noexcept;
    bool operator==(const Deck& rhs);              //Checks if deck is equal to rhs
    inline friend ostream& operator<<(ostream& out, const Deck& rhs);    //Export deck to ostream
    inline friend ifstream& operator>>(ifstream& in, Deck& rhs);                //Import deck from istream


};

ostream &operator<<(ostream &out, const Deck &rhs)
{
    //Get beginning iterator
    Deck::Iterator tmpIt = rhs.begin();

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

#endif //PLAYINGCARDSLIB_LIBRARY_H_DECK

#endif //PLAYINGCARDSLIB_LIBRARY_H