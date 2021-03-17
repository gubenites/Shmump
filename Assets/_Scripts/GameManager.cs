using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public static GameManager _instance;
    
    public enum GameState { MENU, GAME, PAUSE, ENDGAME };

    public GameState gameState { get; private set; }
    public int vidas;
    public int pontos;

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public static GameManager GetInstance()
    {
     
        if (_instance == null)
        {
            Debug.Log("Entrei");       
            _instance = new GameManager();
        }

        return _instance;
    }
    private GameManager()
    {
        vidas = 10;
        gameState = GameState.MENU;
    }

    public void ChangeState(GameState nextState)
    {
        if (nextState == GameState.GAME) Reset();
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        vidas = 10;
        
    }

}


