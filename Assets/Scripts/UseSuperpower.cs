using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSuperpower : MonoBehaviour
{
    CurrentSuperpower power;
    
    public GameObject superpowerModel;
    public Transform spawnPoint;

    public Transform superpowerParent;

    public void ActivatePower(CallbackContext context, bool playAudio = false) {
        
        
        if (playAudio)
            GetComponent<AudioSource>().Play();
        
        // instantiate the laser beam
        GameObject generatedBeam = Instantiate(superpowerModel, spawnPoint.position, spawnPoint.rotation);

        // put new laser beam in the correct parent
        generatedBeam.transform.SetParent(superpowerParent);
    }

}
