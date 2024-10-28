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
    public BallScript bS;
    
    public enum FightState
    {
        Player,
        IA
    }
    
    public FightState m_currentFighter = FightState.Player;

    public void ChangeStateFighter(FightState newFightState)
    {
        switch (m_currentFighter)
        {
            case FightState.Player: PlayerUIDis();
                break;
            case FightState.IA: IAUIdis();
                break;
        }

        m_currentFighter = newFightState;

        switch (newFightState)
        {
            case FightState.Player: PlayerUISet();
                break;
            case FightState.IA: IAUISet();
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
    
    public void ClicktoHeal()
    {
        playerManager.Heal();
        Debug.Log("Heal player");
    }

    public void AttackFire()
    {
        playerManager.AttackFire();
        bS.AnimBall();
        Debug.Log("Attaque Player fire");
    }
    
    public void AttackWater()
    {
        playerManager.AttackWater();
        bS.AnimBall();
        Debug.Log("Attaque player water");
    }

    public void ClickToRun()
    {
        playerManager.Run();
        Debug.Log("Run away");
    }

    public void DisableCanvasGameRun()
    {
        foreach (var i in canvasGameList)
        {
            i.SetActive(false);
        }
    }

    private void Update()
    {
        Win();
    }

    public void Win()
    {
        if (playerManager.playerHealth <= 0)
        {
            DisableCanvasGameRun();
            aiVictory.gameObject.SetActive(true);
        }
        if (robot.iaHealth <= 0)
        {
            DisableCanvasGameRun();
            playerVictory.gameObject.SetActive(true);
        }
    }
}
