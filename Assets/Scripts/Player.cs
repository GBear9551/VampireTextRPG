using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Parameters

    // Cache

    // State Variables

    // List of choices, append the player's choices to this list. 
    int playerHP = 100; // Health points
    int playerMP = 100; // (Vampiria)Mana points 
    int playerBP = 100; // Blood points

    // Declare and initialize variables
    int bloodThirst = 0;
    int curseLevel = 0;
    string playerLocation = "Castle";

    // StoryLine
    int currentAct = 1;
    int currentChapter = 1;
    int storyProgress = 0;

/*    // Events
    var events = {
combat: ["Vampire Hunter", "Werewolf Attack", "Castle Siege"],
interestingHappenings: ["Mysterious Stranger", "Eerie Noises", "Hidden Treasure"],
randomizedEvents: ["Sudden Storm", "Festival Celebration", "Ancient Relic Discovery"]
};

// Player Input
function getPlayerChoice(choices)
{
    // Code to get player's choice
    // Returns the chosen option
}

// Update Story Line Parameters: Characters, Stats, BloodThirst, Curses, Gifts, Items,
function updateStoryParameters()
{
    // Code to update character stats, bloodthirst level, curses, gifts, items, etc.
}

// If player hp == 0, defeat story summary
function handleDefeat()
{
    // Code to display defeat message and story summary
}

// Repeat
while (playerHP > 0)
{
    // Display current chapter and story progress
    console.log("Chapter " + currentChapter + ", Progress: " + storyProgress);

*/


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
