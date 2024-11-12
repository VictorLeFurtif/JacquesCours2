using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class FightManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ia;
    public PLayer playerManager;
    public Robot robot;
    public TMP_Text runText;
    public TMP_Text runText2;
    [SerializeField] private List<GameObject> canvasGameList;
    public TMP_Text aiVictory;
    public TMP_Text playerVictory;
    public Slider sliderPlayer;
    public Slider sliderIA;
    
    public enum FightState
    {
        Player,
        IA
    }

    public void EndTurn(FightState fighter)
    {
        switch (fighter)
        {
            case FightState.Player:
                ChangeStateFighter(FightManager.FightState.IA);
                break;
            case FightState.IA:
                ChangeStateFighter(FightManager.FightState.Player);
                break;
        }
    }

    public FightState m_currentFighter = FightState.Player;

    private void ChangeStateFighter(FightState newFightState)
    {
        switch (m_currentFighter)
        {
            case FightState.Player:
                PlayerUIDis();
                break;
            case FightState.IA:
                IAUIdis();
                break;
        }

        m_currentFighter = newFightState;

        switch (newFightState)
        {
            case FightState.Player:
                PlayerUISet();
                break;
            case FightState.IA:
                IAUISet();
                break;
        }
    }

    public void PlayerUISet()
    {
        player.SetActive(true);
    }

    public void IAUISet()
    {
        ia.SetActive(true);
        robot.ManageAITurn();
    }

    public void PlayerUIDis()
    {
        player.SetActive(false);
    }

    public void IAUIdis()
    {
        ia.SetActive(false);
    }

    public void ClickOnPassTour()
    {
        ChangeStateFighter(FightState.IA);
    }

    public void ClickToHeal()
    {
        playerManager.Heal();
        Debug.Log("Heal player");
    }

    public void AttackFire()
    {
        playerManager.AttackFire();
        Debug.Log("Attaque Player fire");
    }

    public void AttackWater()
    {
        playerManager.AttackWater();
        Debug.Log("Attaque player water");
    }

    public void ClickToRun()
    {
        RunAway(FightState.Player);
        Debug.Log("Run away");
    }

    public void DisableCanvasGameRun()
    {
        foreach (var i in canvasGameList)
        {
            i.SetActive(false);
        }
    }

    public void WinPlayer()
    {
        DisableCanvasGameRun();
        playerVictory.gameObject.SetActive(true);
    }

    public void WinIA()
    {
        DisableCanvasGameRun();
        aiVictory.gameObject.SetActive(true);
    }

    public void RunAway(FightState fighter)
    {
        int chancenumber = Random.Range(1, 4);
        if (chancenumber == 2)
        {
            DisableCanvasGameRun();
            switch (fighter)
            {
                case FightState.Player:
                    runText.gameObject.SetActive(true);
                    return;
                case FightState.IA:
                    runText2.gameObject.SetActive(true);
                    return;
            }
        }

        switch (fighter)
        {
            case FightState.Player:
                EndTurn(FightManager.FightState.Player);
                break;
            case FightState.IA:
                EndTurn(FightManager.FightState.IA);
                break;
        }
    }
}