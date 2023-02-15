using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSuperpower : MonoBehaviour
{
    public string superPower = "Freeze";

    public void UpdateActivePower(string[] values) {
        var power = values[0];
        Debug.Log("power activated " + power);
        this.superPower = power;
    }
}
