using System;
using TMPro;
using UnityEngine;

public enum GameState
{
    Paused,
    Playing
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameState gameState = GameState.Playing;
    
    public GameOverScreen  gameOverScreen;
    public TextMeshProUGUI coins;
    private int _coins = 0;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartGame();
    }

    public void AddCoin(int ammount)
    {
        _coins += ammount;
        coins.text = _coins.ToString();
    }

    public void GameOver(bool isWin)
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverScreen.TriggerGameState(isWin, _coins);
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        gameState = GameState.Paused;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        gameState = GameState.Playing;
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        gameState = GameState.Playing;
    }
    
}
