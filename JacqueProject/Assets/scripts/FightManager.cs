using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ia;
    public int playerHealth = 100;
    public int iaHealth = 100;
    public TMP_Text playerHealthText;
    public TMP_Text iaHealthText;
    
    void Start()
    {
        playerHealthText.text = ""+playerHealth;
        iaHealthText.text = ""+iaHealth;
    }

    public int pvPlayer
    {
        get => playerHealth;

        set
        {
            playerHealth = value;
            UpdatePlayerHealth();
        }
    }

    public void UpdatePlayerHealth()
    {
        playerHealthText.text = ""+playerHealth;
    }
    
    public int pvIa
    {
        get => iaHealth;

        set
        {
            iaHealth = value;
            UpdateIaHealth();
        }
    }

    public void UpdateIaHealth()
    {
        iaHealthText.text = ""+iaHealth;
    }
    
    
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
    
    
}
