using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [field: Header("player health"), SerializeField]
    public int Health { get; private set; }


    [field: Header("player spell n°1"), SerializeField]
    public List<Spell> spell { get; private set; }

    // Always use Instance to modify readonly.value
    public PlayerDataInstance Instance()
    {
        return new PlayerDataInstance(this);
    }
}

//Create data but that we can modify without any issues
public class PlayerDataInstance
{
    public int health;
    public Spell spell1;
    public Spell spell2;
    public Spell heal;

    public bool IsDead()
    {
        return health <= 0;
    }

    public PlayerDataInstance(PlayerData data)
    {
        health = data.Health;
        spell1 = data.spell[0];
        spell2 = data.spell[1];
        heal = data.spell[2];
    }

    public void ApplySpell(Spell spell)
    {
        switch (spell.spellElement)
        {
            case Spell.element.water:
                health -= spell.power;
                break;
            case Spell.element.fire:
                health -= spell.power;
                break;
            case Spell.element.heal:
                health += spell.power;
                break;
        }
    }
}