using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Input;

public class FireLaserGun : MonoBehaviour
{
    public Animator gunAnimator;
    
    public Transform  laserSpawnPoint;
    public GameObject laserBeamModel;

    public Transform laserParent;

    public void FireLaser(bool playAudio = true)
    {
        if (gunAnimator != null) 
            gunAnimator.SetTrigger("Fire");        

        
        if (playAudio)
            GetComponent<AudioSource>().Play();
        
        // instantiate the laser beam
        GameObject generatedLaserBeam = Instantiate(laserBeamModel, laserSpawnPoint.position, laserSpawnPoint.rotation);

        // put new laser beam in the correct parent
        generatedLaserBeam.transform.SetParent(laserParent);
    }
}
