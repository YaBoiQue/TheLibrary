#pragma once

#include <vector>
#include <string>

using namespace std;

#ifndef __character__H__
#define __character__H__


enum abilityList
{
    Strength,
    Constitution,
    Dexterity,
    Intelligence,
    Wisdom,
    Charisma
};

enum skillList
{
    Acrobatics = Dexterity,
    Arcana = Intelligence,
    Athletics = Strength,
    Bluff = Charisma,
    Diplomacy = Charisma,
    Dungeoneering = Wisdom,
    Endurance = Constitution,
    Heal = Wisdom,
    History = Intelligence,
    Insight = Wisdom,
    Intimidate = Charisma,
    Nature = Wisdom,
    Perception = Wisdom,
    Religion = Intelligence,
    Stealth = Dexterity,
    Streetwise = Charisma,
    Thievery = Dexterity
};

enum resistanceList
{
    Acid,
    Cold,
    Fire,
    Force,
    Lightning,
    Necrotic,
    Poison,
    Psychic,
    Radiant,
    Thunder,
    Bludgeoning,
    Slashing,
    Piercing,
    Nonmagical
};

enum raceList
{
    Dragonborn,
    Dwarf,
    Elf,
    Gnome,
    HalfElf,
    Halfling,
    HalfOrc,
    Human,
    Tiefling
};

enum classeList
{
    Barbarian,
    Bard,
    Cleric,
    Druid,
    Fighter,
    Monk,
    Paladin,
    Ranger,
    Rogue,
    Sorcerer,
    Warlock,
    Wizard
};

enum sizeList
{
    small,
    medium,
    large
};


class character_
{
public:
    //Con/Deconstructors
    character_ ( );
    ~character_ ( );


    /*--------Character Details--------*/
    //Replacement Functions
    bool repName ( string name );
    bool repLevel ( int level );
    bool repXP ( int xp );
    bool repRace ( raceList race );
    bool repClass ( classeList cClass );
    bool repParPath ( string parPath );
    bool repEpicDest ( string epicDestiny );
    bool repSize ( sizeList size );
    bool repAge ( int age );
    bool repGen ( bool gender );
    bool repDeity ( string deity );
    bool repAffil ( string affil );

    //Manipulation Functions
    bool addLevel ( int add );
    bool addXP ( int add );


    /*--------Initiative--------*/
    //Replacement Functions
    bool repMisc ( int misc );


    /*--------Ability Scores--------*/
    //Replacement functions

    //Modifier functions






};


class initiative_
{
private:
    int misc;


public:
    //Con/Deconstructors
    initiative_ ( );
    ~initiative_ ( );

    //Replacement Functions
    bool repMisc ( int replace );

    //Information Functions
    int score ( );

};


class abilities_ : public skills_
{
private:
    int abilScore[6] = { 0 };
    int abilMod[6] = { 0 };


public:
    //Con/Deconstructors
    abilities_ ( );
    ~abilities_ ( );

    //Replacement Functions
    bool repStr ( int strScore );
    bool repCon ( int conScore );
    bool repDex ( int dexScore );
    bool repInt ( int intScore );
    bool repWis ( int wisScore );
    bool repCha ( int chaScore );

    //Information Functions
    int strMod ( );
    int conMod ( );
    int dexMod ( );
    int intMod ( );
    int wisMod ( );
    int chaMod ( );

    int strScr ( );
    int conScr ( );
    int dexScr ( );
    int intScr ( );
    int wisScr ( );
    int chaScr ( );

};


class hitPoints_
{
private:
    int maxHP, curHP, surgesDay, surgesUsed, tempHP, savThrMod;
    vector<resistanceList> resistances;
    vector<string> conditions;
    bool secWind, savThrFails[3];

public:
    //Con/Deconstructors
    hitPoints_ ( );
    ~hitPoints_ ( );

    //Replacement Functions
    bool maxHP ( int replace );
    bool curHP ( int replace );
    bool surgDay ( int replace );
    bool surgUsed ( int replace );
    bool tempHP ( int replace );
    bool savThrMod ( int replace );

    //Manipulation Functions
    bool addMax ( int add );
    bool addSurDay ( int add );
    bool addSurUsed ( int add );
    bool addHP ( int add );
    bool subHP ( int sub );
    bool maxHP ( );
    bool addTemp ( int add );
    bool subTemp ( int sub );
    bool clrTemp ( );

    //Insert Functions
    bool resist ( resistanceList resistance );
    bool cond ( string condition );

    //Remove Functions
    bool _resist ( resistanceList resistance );
    bool _cond ( int pos );

    //Set Functions
    bool setWind ( );
    bool _setWind ( );
    bool setThrow ( );
    bool _setThrow ( );

    //Information Functions
    int maxHP ( );
    int curHP ( );
    int surgDay ( );
    int surgUsed ( );
    int tempHP ( );
    int savThrMod ( );
    vector<resistanceList> resistances ( );
    vector<string> conditions ( );
    bool secWind ( );
    bool savThr ( );

};


class skills_
{
private:

    int* abilMod[17] = { 0 };
    int armPen[17] = { 0 };
    int misc[17] = { 0 };
    bool trained[17] = { false };


public:
    //Con/Deconstructor
    skills_ ( );
    ~skills_ ( );

    //Manipulation
    bool repMod ( skillList skill, int* replace );
    bool repTrnd ( skillList skill, bool trnd );
    bool repArmPen ( skillList skill, int replace );
    bool repMisc ( skillList skill, int replace );

    //Information
    int bonus ( skillList skill );
    int armPen ( skillList skill );
    int misc ( skillList skill );
    bool trained ( skillList skill );

};


class defenses_
{
private:
    int defenses[4][6];


public:
    //Con/Deconstructors
    defenses_ ( );
    ~defenses_ ( );

    //Defenses
    //Replacement Functions
    bool repAc ( int mods[] );
    bool repFort ( int mods[] );
    bool repRef ( int mods[] );
    bool repWill ( int mods[] );

    bool repAc ( int mod, int pos );
    bool repFort ( int mod, int pos );
    bool repRef ( int mod, int pos );
    bool repWill ( int mod, int pos );

    //Manipulation functions
    bool modAc ( int mod, int pos );
    bool modFort ( int mod, int pos );
    bool modRef ( int mod, int pos );
    bool modWill ( int mod, int pos );

    //Information functions
    int acScore ( );
    int fortScore ( );
    int refScore ( );
    int willScore ( );

    int acMod ( int pos );
    int fortMod ( int pos );
    int refMod ( int pos );
    int willMod ( int pos );

};


class actionPoints_
{
private:
    int numPoints = 1;

public:
    //Con/Deconstructors
    actionPoints_ ( );
    ~actionPoints_ ( );

    //Manipulation Functions
    bool increase ( );
    bool decrease ( );

    //Information Functions
    int points ( );

};


class features_
{

};


class movement_
{

};


class senses_
{

};


class attackWorkspace_
{

};


class damageWorkspace_
{

};


class basicAttacks_
{

};


class feats_
{

};

#endif