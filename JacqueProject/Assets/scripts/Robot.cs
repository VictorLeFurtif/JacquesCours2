using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Robot : MonoBehaviour
{
    public TMP_Text iaHealthText;
    public PLayer playerManager;
    public FightManager ftManager;
    public PlayerData data; // Data that we cant modify
    public PlayerDataInstance inGameData; // Data that we can modify thanks to PlayerData
    public AiBehaviorData aiBData;

    public void Awake()
    {
        inGameData = data.Instance(); // Let us handle the data from PlayerData
    }

    void Start()
    {
        iaHealthText.text = "" + inGameData.health; // Show health at begging
    }

    public int pvIa
    {
        get
        {
            if (inGameData == null)
            {
                inGameData = data.Instance();
            }

            return inGameData.health;
        }

        set
        {
            inGameData.health = value; // Set pvIA value to inGameDta.health value
            UpdateIaHealthUI();
            if (inGameData.IsDead())
            {
                ftManager.WinPlayer();
            }
        }
    }

    private void UpdateIaHealthUI()
    {
        iaHealthText.text = "" + pvIa;
    }

    public enum AIState
    {
        loosing,
        winning,
    }

    public AIState m_currentAIState = AIState.winning;

    public void DetermineState(int hp)
    {
        m_currentAIState = hp <= data.Health * aiBData.ratioForLoosing ? AIState.loosing : AIState.winning;
    }

    public void ManageAITurn()
    {
        DetermineState(pvIa);
        switch (m_currentAIState)
        {
            case AIState.loosing:
                ManageLoosing();
                break;
            case AIState.winning:
                ManageWinning();
                break;
            default: throw new ArgumentOutOfRangeException();
        }

        ftManager.EndTurn(FightManager.FightState.IA);
    }

    public void ManageLoosing()
    {
        var rand = Random.Range(0, 100);
        if (rand > aiBData.ratioRunLoosing)
        {
            ftManager.RunAway(FightManager.FightState.IA);

            Debug.Log("Ai s'enfuit");
            return;
        }

        if (rand > aiBData.ratioHealLoosing)
        {
            Heal();
            Debug.Log("Ai se Heal");
            return;
        }

        Attack();
        Debug.Log("AI attaque");
    }

    public void Attack()
    {
        playerManager.inGameData.ApplySpell(inGameData.spell1);
        playerManager.pvPlayer = Mathf.Clamp(playerManager.pvPlayer, 0, data.Health);
        ftManager.sliderPlayer.value = playerManager.pvPlayer;
    }

    public void Heal()
    {
        inGameData.ApplySpell(inGameData.heal);
        pvIa = Mathf.Clamp(pvIa, 0, data.Health);
        ftManager.sliderIA.value = pvIa;
    }

    public void ManageWinning()
    {
        var rand = Random.Range(0, 100);
        if (rand > aiBData.ratioRunWinning)
        {
            ftManager.RunAway(FightManager.FightState.IA);
            Debug.Log("Ai s'enfuit");
            return;
        }

        if (rand > aiBData.ratioHealWinning)
        {
            Heal();
            Debug.Log("Ai se Heal");
            return;
        }

        Attack();
        Debug.Log("AI attaque");
    }
}