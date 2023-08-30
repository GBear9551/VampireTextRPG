using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "TextAdventure/Room")]
public class Room : ScriptableObject 
{

    [TextArea] // Allows the text in the editor to be displayed bigger.
    public string description = null;
    public string roomName = null;
    public Exit[] exits = null;

}
