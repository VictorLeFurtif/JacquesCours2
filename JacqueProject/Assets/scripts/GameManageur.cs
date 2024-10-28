using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManageur : MonoBehaviour

{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;


    public enum GameState
    {
        Game,
        Menu
    }

    public GameState m_currentGameState = GameState.Menu;

    public void ChangeGameState(GameState newGameState)
    {
        switch (m_currentGameState)
        {
            case GameState.Menu:
                DiasableMenu();
                break;
            case GameState.Game:
                DiasableGame();
                break;
        }

        m_currentGameState = newGameState;

        switch (newGameState)
        {
            case GameState.Game:
                SetUpGame();
                break;
            case GameState.Menu:
                SetUpMenu();
                break;
        }
    }

    public void SetUpGame()
    {
        game.SetActive(true);
    }

    public void SetUpMenu()
    {
        menu.SetActive(true);
    }

    public void DiasableMenu()
    {
        menu.SetActive(false);
    }

    public void DiasableGame()
    {
        game.SetActive(false);
    }
}