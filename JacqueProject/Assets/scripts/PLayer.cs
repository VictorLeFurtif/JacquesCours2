using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    public int playerHealth = 100;
    public TMP_Text playerHealthText;
    public FightManager ftManager;
    public Robot robot;
    
    void Start()
    {
        playerHealthText.text = ""+playerHealth;
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

    public void Heal()
    {
        if (playerHealth < 75)
        {
            pvPlayer += 25;
            pvPlayer = Mathf.Clamp(pvPlayer,0,100);
            ftManager.sliderPlayer.value = pvPlayer;
        }
        else
        {
            pvPlayer = 100;
            pvPlayer = Mathf.Clamp(pvPlayer,0,100);
            ftManager.sliderPlayer.value = pvPlayer;
            
        }
        EndTurn();
    }
    public void AttackFire()
    {
        robot.pvIa -= 25;
        robot.pvIa = Mathf.Clamp(robot.pvIa,0,100);
        ftManager.sliderIA.value = robot.pvIa;
        EndTurn();
    }
    public void AttackWater()
    {
        robot.pvIa -= 25;
        robot.pvIa = Mathf.Clamp(robot.pvIa,0,100);
        ftManager.sliderIA.value = robot.pvIa;
        EndTurn();
    }
    public void Run()
    {
        int chancenumber = Random.Range(1, 3);
        if (chancenumber == 2)
        {
            ftManager.DisableCanvasGameRun();
            ftManager.runText.gameObject.SetActive(true);
        }
        EndTurn();
    }
    public void EndTurn()
    {
        ftManager.ChangeStateFighter(FightManager.FightState.IA);
    }
}
