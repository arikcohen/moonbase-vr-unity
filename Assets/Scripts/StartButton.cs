using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameManager game;

    public GameManager.GameDifficulty difficulty = GameManager.GameDifficulty.Standard;
    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Laser") {
            Debug.Log("start game");
            GameManager.difficulty = difficulty;
            game.StartGame();
        }
    }

}
