using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Robot : MonoBehaviour
{
    public int iaHealth = 100;
    public TMP_Text iaHealthText;
    public PLayer playerManager;
    public FightManager ftManager;
    
    void Start()
    {
        iaHealthText.text = ""+iaHealth;
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
    
    
    public enum AIState
    {
        loosing,
        winning, 
    }

    public AIState m_currentAIState = AIState.winning;
        
    public void DetermineState(int hp)
    {
        m_currentAIState = hp < 50 ? AIState.loosing : AIState.winning;
    }
        
    public void ManageAITurn()
    {
        DetermineState(iaHealth);
        switch (m_currentAIState )
        {
            case AIState.loosing:ManageLoosing(); break;
            case AIState.winning: ManageWinning(); break;
            default: throw new ArgumentOutOfRangeException();
        }   
        EndTurn();
    }

    public void ManageLoosing()
    {
        var rand = Random.Range(0, 100);
        if (rand> 85)
        {
            RunAway();
            ftManager.DisableCanvasGameRun();
            Debug.Log("Ai s'enfuit");
            return;
        } 
        
        if(rand > 70)
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
        playerManager.pvPlayer -= 20;
        playerManager.pvPlayer = Mathf.Clamp(playerManager.pvPlayer,0,100);
        ftManager.sliderPlayer.value = playerManager.pvPlayer;

    }
    
    public void Heal()
    {
        if (iaHealth < 75)
        {
            pvIa += 25;
            pvIa = Mathf.Clamp(pvIa, 0, 100);
            ftManager.sliderIA.value = pvIa;
        }
        else
        {
            pvIa = 100;
            pvIa = Mathf.Clamp(pvIa, 0, 100);
            ftManager.sliderIA.value = pvIa;
        }
    }
    
    public void RunAway()
    {
        int chancenumber = Random.Range(1, 3);
        if (chancenumber == 2)
        {
            ftManager.DisableCanvasGameRun();
            ftManager.runText2.gameObject.SetActive(true);
        }
      
    }
    
    public void ManageWinning()
    {
        var rand = Random.Range(0, 100);
        if (rand> 95)
        {
            RunAway();
            Debug.Log("Ai s'enfuit");
            return;
        } 
        
        if(rand > 70)
        {
            Heal();
            Debug.Log("Ai se Heal");
            return;
        }
        Attack();
        Debug.Log("AI attaque");

    }

    public void EndTurn()
    {
        ftManager.ChangeStateFighter(FightManager.FightState.Player);
    }

}
