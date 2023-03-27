using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceResponses: MonoBehaviour
{    

    public void UpdateActivePower(string[] values) {
        var power = values[0];
        Debug.Log("power activated " + power);
        GameManager.currentSuperPower = (GameManager.Superpowers) Array.IndexOf(GameManager.SuperpowerStrings, power);
    }
}
