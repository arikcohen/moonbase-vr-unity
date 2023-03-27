using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamMove : MonoBehaviour
{
    public float thrust = 0.01f;
    private Rigidbody rb;
    public float scale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * thrust;
        transform.localScale = transform.localScale * scale;
        //Debug.Log(this.name + " moveLaser:" + transform.forward);
        Destroy(gameObject, 4f);
    }
}
