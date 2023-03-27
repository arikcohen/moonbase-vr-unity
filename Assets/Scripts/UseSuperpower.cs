using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class UseSuperpower : MonoBehaviour
{      
    public GameObject superpowerModel;
    public Transform spawnPoint;

    public Transform superpowerParent;

    public void ActivatePower(InputAction.CallbackContext context ) {
        // check to see that eye tracking is enabled
        if (this.GetComponent<OVREyeGaze>().EyeTrackingEnabled)     
        { 
            if (context.performed)
            {
                 //            if (playAudio)
                //                GetComponent<AudioSource>().Play();
                
                // instantiate the laser beam
                GameObject generatedBeam = Instantiate(superpowerModel, spawnPoint.position, spawnPoint.rotation);

                // put new laser beam in the correct parent
                generatedBeam.transform.SetParent(superpowerParent);
            }
        }
        else {
            Debug.Log("no eye tracking and attempted to use superpowers");
        }
    }

}
