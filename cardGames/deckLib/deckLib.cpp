#include "deckLib.h"

typedef Deck::Iterator Iterator;

#ifndef PLAYINGCARDSLIB_LIBRARY_CPP_SUIT
#define PLAYINGCARDSLIB_LIBRARY_CPP_SUIT

//Information
bool Suit::isBlack() const
{
    //Return true if club or spade
    return ((suit == club) || (suit == spade));
}

bool Suit::isRed() const
{
    //Return true if heart or diamond
    return ((suit == heart) || (suit == diamond));
}

int Suit::toInt() const
{
    //Returns integer value of suit
    return static_cast<int>(suit);
}

char Suit::toChar() const
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
bool Suit::fromInt(const int &val)
{
    //Sets suit value from int
    if (val > 3) { return false; }
    suit = static_cast<_suit>(val);

    return true;
}

bool Suit::fromChar(const char &val)
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

bool Suit::operator==(Suit a) const
{
    //Return if values are equal
    return suit == a.suit;
}

bool Suit::operator!=(Suit a) const
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

Suit::_suit Suit::value() const {
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

int Card::value() const
{
    //Return calculated card value
    return _rank + (_suit.toInt() * 13);
}

Suit Card::suit() const
{
    //Return card suit
    return _suit;
}

int Card::rank() const
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
    out << setfill(' ') << rhs.ranktochar();

    //Output suit
    out << rhs.suit() << " ";

    //Return output stream
    return out;
}

string Card::ranktochar() const {
    char tmp;
    switch(rank())
    {
        case 0:
            return "A";
        case 10:
            return "J";
        case 11:
            return "Q";
        case 12:
            return "K";
        default:
            return to_string(rank()+1);
    }
}

#endif //PLAYINGCARDSLIB_LIBRARY_CPP_CARD


#ifndef PLAYINGCARDSLIB_LIBRARY_CPP_ITERATOR
#define PLAYINGCARDSLIB_LIBRARY_CPP_ITERATOR

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

#endif


#ifndef PLAYINGCARDSLIB_LIBRARY_CPP_DECK
#define PLAYINGCARDSLIB_LIBRARY_CPP_DECK

//De/Constructors
Deck::Deck(bool fill)
{
    //Set head and tail as null
    head = new Node();
    tail = new Node();
    head->next = tail;
    tail->prev = head;

    //If fill is true then add cards
    if (fill)
        reset();
}

Deck::Deck(const Deck& old)
{
    //Defining variables
    Node *copyptr = old.head;

    //Setting head and tail
    head = new Node();
    tail = new Node();
    head->next = tail;
    tail->prev = head;

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

    //Setting head and tail
    head = new Node();
    tail = new Node();
    head->next = tail;
    tail->prev = head;

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
    while(head->next != tail)
    {
        //Set tmpptr to head and increment head
        tmpptr = head->next;
        head->next = head->next->next;
        //Delete tmpptr
        delete tmpptr;
    }


    //Setting head and tail
    tail = new Node();
    head->next = tail;
    tail->prev = head;
}

void Deck::reset()
{
    //Clear the deck of cards
    clear();

    //Fill the deck with cards ascending
    for (int i = 0; i < 52; ++i)
        insert(Card(i), end());
}

Card Deck::draw(Iterator pos)
{
    if (pos == end())
        return Card();

    //Defining variables
    Node *ptr = pos._node;
    Card card = Card(*pos);

    //Ghost node
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

bool Deck::insert(const Card &in, Iterator pos)
{
    //Defining variables
    Node *newNode = new Node(Card(in), pos._node, pos._node->prev);


    //Insert node
    pos._node->prev->next = newNode;
    pos._node->prev = newNode;

    //Return iterator to node
    return true;
}

size_type Deck::size() const
{
    //Defining variables
    Node *tmpptr = head->next;
    size_type size = 0;

    //While tmpptr isn't null
    while (tmpptr != tail)
    {
        //Increment size and ptr
        ++size;
        tmpptr = tmpptr->next;
    }

    //Return size
    return size;
}

bool Deck::empty() const
{
    //If head is null return true
    if (head->next == tail)
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

    fromVector(list);
}

vector<Card> Deck::toVector()
{
    Node* tmpptr = head->next;
    vector<Card> result;

    while (tmpptr != tail)
    {
        result.insert(result.end(), tmpptr->card);
        tmpptr = tmpptr->next;
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