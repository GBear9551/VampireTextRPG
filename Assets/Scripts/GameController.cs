using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{

    public Text displayText;

    [HideInInspector] public RoomNavigation roomNavigation = null;
    [HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string>();
    
    /*
        Options:
           font size scale: -1,1
           sound effects: true or false
           ambient sounds: true or false
           vibrations: true or false
           
    */



    
    List<string> actionLog = new List<string>();



    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>();

    }

    void Start()
    {

        DisplayRoomText();
        DisplayLoggedText();

    }


    public void DisplayLoggedText()
    {

        string seperator = "\n";
        string logAsText = string.Join(seperator, actionLog.ToArray());

        displayText.text = logAsText;

    }

    public void DisplayRoomText()
    {
        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n",interactionDescriptionsInRoom.ToArray());

        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;

        LogStringWithReturn(combinedText);
    }

    void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
    }


    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }

        
}
