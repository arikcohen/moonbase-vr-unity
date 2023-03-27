using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    
    public Vector3 direction;


    [Header("Movement Speed")]
    public float maxSpeed = 5f;
    public float minSpeed = 2f;

    [Header("Rotational speed")]
    public float maxRotationalSpeed = 60f;
    public float minRotationalSpeed = 15f;
    private float _rotationalSpeed;
    private float _xAngle, _yAngle, _zAngle;

    private float asteroidSpeed;
    public float asteroidSpeedMultiplier;
    private bool speedAdjusted = false;
    void Start()
    {
        // calculate asteroid speed -- speed is higher for higer game difficult
        float effectiveMinSpeed = GameManager.difficulty == GameManager.GameDifficulty.Standard ? minSpeed : minSpeed * 1.0f;
        float effectiveMaxSpeed = GameManager.difficulty == GameManager.GameDifficulty.Standard ? maxSpeed : maxSpeed * 1.5f;
        asteroidSpeed = Random.Range(effectiveMinSpeed, effectiveMaxSpeed);
        
        //asteroidSpeedMultiplier gives more points for faster asteroids
        asteroidSpeedMultiplier = (asteroidSpeed - effectiveMinSpeed) / (effectiveMaxSpeed - effectiveMinSpeed);        
        
        _xAngle = Random.Range(0, 360);
        _yAngle = Random.Range(0, 360);
        _zAngle = Random.Range(0, 360);    
        transform.GetChild(0).transform.Rotate(_xAngle, _yAngle,_zAngle, Space.Self);

        _rotationalSpeed = Random.Range(minRotationalSpeed, maxRotationalSpeed);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direction * Time.deltaTime * asteroidSpeed);
        transform.GetChild(0).transform.Rotate(Vector3.up * Time.deltaTime * _rotationalSpeed);
    }

    // Slowdown speed on freeze ray
    public void FreezeRaySpeedAdjustment()
    {
        if (!speedAdjusted)
        {
            asteroidSpeed *= 0.5f;
            speedAdjusted = true;
        }
    }
}

