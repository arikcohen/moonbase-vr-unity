using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI difficulty;
   
    public void DisplayGameOver()
    {
        score.text = GameManager.PlayerScore.ToString("n0");
        difficulty.text = (GameManager.difficulty == GameManager.GameDifficulty.Standard) ? "Standard" : "Hard";
        highScore.text = PlayerPrefs.GetInt("highscore-" + GameManager.difficulty.ToString(), GameManager.PlayerScore).ToString("n0");
    }


}
