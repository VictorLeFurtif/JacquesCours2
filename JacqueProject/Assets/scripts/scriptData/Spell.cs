using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Create spell List so we can use them to fight and we can also have different type of it.
[CreateAssetMenu]
public class Spell : ScriptableObject
{
    public string spellName;

    [field: Header("player power"), SerializeField]
    public int power { get; private set; }
    
    public element spellElement;

    public enum element
    {
        water,
        fire,
        heal,
        run
    }
}