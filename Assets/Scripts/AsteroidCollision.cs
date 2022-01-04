using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteroidCollision : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExplosion;

    public GameObject pointsCanvas;

    static Vector3 cameraLocation = new Vector3(94.4469986f,0.209999993f,118.072998f);
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid") {

            Destroy(collision.gameObject);
            Instantiate(asteroidExplosion, collision.transform.position, collision.transform.rotation);


            float speed = collision.gameObject.GetComponent<AsteroidMovement>().asteroidSpeedMultiplier;
            float distance = Vector3.Distance(transform.position, cameraLocation);

            int score = GameManager.AsteroidHit(speed, distance/60f);

            if (score != 0) {
                GameObject displayScore = Instantiate(pointsCanvas, transform.position, Quaternion.identity);
                displayScore.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = score.ToString("n0");
                displayScore.transform.localScale = new Vector3(transform.localScale.x * (distance /10),
                                                                transform.localScale.y * (distance /10),
                                                                transform.localScale.z * (distance /10));
                
                //Debug.Log("added score:" + score + "speed: "+ speed + "distance" + distance); 
            }

            Destroy(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
