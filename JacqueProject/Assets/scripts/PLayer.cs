using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PLayer : MonoBehaviour
{
    public TMP_Text playerHealthText;
    public FightManager ftManager;
    public Robot robot;
    public PlayerData data; // Data that we cant modify
    public PlayerDataInstance inGameData; // Data that we can modify thanks to PlayerData

    public void Awake()
    {
        inGameData = data.Instance(); // Let us handle the data from PlayerData
    }


    void Start()
    {
        playerHealthText.text = "" + inGameData.health;
    }

    public int pvPlayer
    {
        get => inGameData.health;

        set
        {
            inGameData.health = value;
            UpdatePlayerHealth();
            if (inGameData.IsDead())
            {
                ftManager.WinIA();
            }
        }
    }

    public void UpdatePlayerHealth()
    {
        playerHealthText.text = "" + pvPlayer;
    }

    public void Heal()
    {
        inGameData.ApplySpell(inGameData.heal);
        pvPlayer = Mathf.Clamp(pvPlayer, 0, data.Health);
        ftManager.sliderPlayer.value = pvPlayer;
        ftManager.EndTurn(FightManager.FightState.Player);
        Debug.Log("Tu te heales");
    }

    public void AttackFire()
    {
        robot.inGameData.ApplySpell(inGameData.spell1);
        robot.pvIa = Mathf.Clamp(robot.pvIa, 0, data.Health);
        ftManager.sliderIA.value = robot.pvIa;
        ftManager.EndTurn(FightManager.FightState.Player);
        Debug.Log("Tu attaques feu");
    }

    public void AttackWater()
    {
        robot.inGameData.ApplySpell(inGameData.spell2);
        robot.pvIa = Mathf.Clamp(robot.pvIa, 0, data.Health);
        ftManager.sliderIA.value = robot.pvIa;
        ftManager.EndTurn(FightManager.FightState.Player);
        Debug.Log("Tu attaques eau");
    }
}