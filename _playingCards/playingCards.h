#pragma once

#include <vector>
#include <algorithm>
#include <random>

using namespace std;

#ifndef __playingCards__H__
#define __playingCards__H__

#ifndef __CARD__PARAM__
#define __CARD__PARAM__

namespace card_ {

    namespace faces_ {
        enum class faceList {
            ace,
            two,
            three,
            four,
            five,
            six,
            seven,
            eight,
            nine,
            ten,
            jack,
            queen,
            king
        };
        faceList fromInt(int n) {
            if (n == 0) {
                return faceList::ace;
            }
            if (n == 1) {
                return faceList::two;
            }
            if (n == 2) {
                return faceList::three;
            }
            if (n == 3) {
                return faceList::four;
            }
            if (n == 4) {
                return faceList::five;
            }
            if (n == 5) {
                return faceList::six;
            }
            if (n == 6) {
                return faceList::seven;
            }
            if (n == 7) {
                return faceList::eight;
            }
            if (n == 8) {
                return faceList::nine;
            }
            if (n == 9) {
                return faceList::ten;
            }
            if (n == 10) {
                return faceList::jack;
            }
            if (n == 11) {
                return faceList::queen;
            }
            if (n == 12) {
                return faceList::king;
            }
            return faceList();
        }
    }
    namespace suits_ {
        enum colorList {
            red,
            black
        };

        enum class suitList {
            club = colorList::black,
            diamond = colorList::red,
            heart = colorList::red,
            spade = colorList::black
        };

        inline suitList fromInt(int n) {
            if (n == 0) {
                return suitList::club;
            }
            if (n == 1) {
                return suitList::diamond;
            }
            if (n == 2) {
                return suitList::heart;
            }
            if (n == 3) {
                return suitList::spade;
            }
            return suitList();
        }
    }

    struct cardStruct {
        faces_::faceList face;
        suits_::suitList suit;

        inline cardStruct fromInt(int n) {
            face = faces_::fromInt(n % 13);
            suit = suits_::fromInt(n / 13);
        }
    };
}

#endif

class playingCards :
    protected vector<card_::cardStruct>
{
    //Defaults
    enum faceOrder {
        ace = card_::faces_::faceList::ace,
        two = card_::faces_::faceList::two,
        three = card_::faces_::faceList::three,
        four = card_::faces_::faceList::four,
        five = card_::faces_::faceList::five,
        six = card_::faces_::faceList::six,
        seven = card_::faces_::faceList::seven,
        eight = card_::faces_::faceList::eight,
        nine = card_::faces_::faceList::nine,
        ten = card_::faces_::faceList::ten,
        jack = card_::faces_::faceList::jack,
        queen = card_::faces_::faceList::queen,
        king = card_::faces_::faceList::king
    };
    enum suitOrder {
        club = card_::suits_::suitList::club,
        diamond = card_::suits_::suitList::diamond,
        heart = card_::suits_::suitList::heart,
        spade = card_::suits_::suitList::spade
    };

public:


    //Copy/Decon/Constructors
    playingCards(bool set = false, bool shuffle = false);
    playingCards(playingCards* deck, bool shuffle = false);
    ~playingCards();

    //Iterators
    inline iterator begin() { return vector::begin(); }
    inline iterator end() { return vector::end(); }
    inline reverse_iterator rbegin() { return vector::rbegin(); }
    inline reverse_iterator rend() { return vector::rend(); }
    inline const_iterator cbegin() { return vector::cbegin(); }
    inline const_iterator cend() { return vector::cend(); }
    inline const_reverse_iterator crbegin() { return vector::crbegin(); }
    inline const_reverse_iterator crend() { return vector::crend(); }
    
    //Capacity
    inline int size() { return vector::size(); }
    inline bool empty() { return vector::empty(); }

    //Element Access
    inline card_::cardStruct operator[](size_type i) { return vector::operator[](i); }
    inline card_::cardStruct at(size_type i) { return vector::at(i); }
    inline card_::cardStruct front() { return vector::front(); }
    inline card_::cardStruct back() { return vector::back(); }

    //Modifiers
    inline void assign(int n, const card_::cardStruct& val) { vector::assign(n, val); }
    inline void assign(iterator it1, iterator it2) { vector::assign(it1, it2); }
    inline void push_back(const card_::cardStruct& card) { vector::push_back(card); }
    inline void pop_back() { vector::pop_back(); }
    inline void insert(iterator pos, const card_::cardStruct& card) { vector::insert(pos, card); }
    inline void insert(iterator pos, size_type n, const card_::cardStruct& card) { vector::insert(pos, n, card); }
    inline void insert(iterator pos, iterator from, iterator to) { vector::insert(pos, from, to); }
    inline iterator erase(iterator pos) { vector::erase(pos); }
    inline iterator erase(iterator from, iterator to) { vector::erase(from, to); }
    inline void swap(playingCards& deck) { vector::swap(deck); }
    inline void clear() { vector::clear(); }
    inline iterator emplace(const_iterator pos, card_::cardStruct&& card) { vector::emplace(pos, card); }
    inline void emplace_back(card_::cardStruct&& card) { vector::emplace_back(card); }

    //Relational Operators
    friend bool operator== (const playingCards& lhs, const playingCards& rhs);
    friend bool operator!= (const playingCards& lhs, const playingCards& rhs);
    friend bool operator< (const playingCards& lhs, const playingCards& rhs);
    friend bool operator<= (const playingCards& lhs, const playingCards& rhs);
    friend bool operator> (const playingCards& lhs, const playingCards& rhs);
    friend bool operator>= (const playingCards& lhs, const playingCards& rhs);

    //PlayingCard specific
    inline bool shuffle() { 
        random_device rd;
        auto rng = default_random_engine{rd()}; 
        std::shuffle(begin(), end(), rng); 
    }
    bool set();


};

#endif
