using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    private void OnEnable()
    {
        GameManager.AstroidDestroyed += DisplayScore;
    
    }
    private  void OnDisable()
    {
        GameManager.AstroidDestroyed -= DisplayScore;
    }
    private void DisplayScore()
    {
        scoreText.text = GameManager.PlayerScore.ToString("n0");
    }

    
}
