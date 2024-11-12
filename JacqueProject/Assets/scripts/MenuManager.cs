using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameManageur m_gameManageur;

    public void ClickOnPlay()
    {
        m_gameManageur.ChangeGameState(GameManageur.GameState.Game);
    }
}