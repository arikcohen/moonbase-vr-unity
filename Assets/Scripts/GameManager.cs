using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public enum GameState 
    {
        Intro,
        Playing,
        GameOver
    }
    
    public enum GameDifficulty
    {        
        Standard,
        Hard
    }
    public delegate void AsteroidHandler();
    public static event AsteroidHandler AstroidDestroyed;


    public Image sliderTimerImage;
    public float gameDuration =30f;
    private float sliderDurationCurrentValue = 1;

    public UnityEvent onGameManagerStarted;
    public UnityEvent onStartGame;
    public UnityEvent onGameOver;
    public UnityEvent onNewHighScore;
    private static int _playerScore = 0;
    public static int PlayerScore {
        get { 
            return _playerScore; 
        }
        set {
           _playerScore = value;           
        }
    }

    public static GameDifficulty difficulty = GameDifficulty.Standard;

    public TextMeshProUGUI difficultyText;
    public static GameState state = GameState.Intro;
   
     public void Start ()
     {
         onGameManagerStarted.Invoke();
     }
     public void Update()
    {
        if (state == GameState.Playing) {
            sliderTimerImage.fillAmount = (sliderDurationCurrentValue - Time.deltaTime / gameDuration);
            sliderDurationCurrentValue = sliderTimerImage.fillAmount;
            if (sliderDurationCurrentValue <= 0) {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        int currentHighScore = PlayerPrefs.GetInt("highscore-" + difficulty.ToString(), 0);
        if (PlayerScore > currentHighScore)
        {
            onNewHighScore.Invoke();
            PlayerPrefs.SetInt("highscore-" + difficulty.ToString(), PlayerScore);
        }
        state = GameState.GameOver;
        onGameOver.Invoke();
    }

    public static int AsteroidHit(float asteroidSpeedMultiplier, float astroidDistanceMulitplier)
    {
        int asteroidScore = 0;
        if (state == GameState.Playing) {
            // score is a base score based on difficulty * multiplier for speed * multiplier for distance
            float asteroidBaseScore = (difficulty == GameDifficulty.Standard) ? 500f : 750f;

            asteroidScore = (int) ((1f + asteroidSpeedMultiplier /2) * astroidDistanceMulitplier * asteroidBaseScore);
            
            PlayerScore += (int) asteroidScore;
            AstroidDestroyed(); 
        }
        return asteroidScore;
    }

    
    public void StartGame()
    {
        
        PlayerScore = 0;
        sliderTimerImage.fillAmount = 1;
        sliderDurationCurrentValue = 1;
        difficultyText.text = difficulty == GameDifficulty.Standard ? "Standard" : "Hard";

        state = GameState.Playing;
        onStartGame.Invoke();
    }
}
