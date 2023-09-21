using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStickForce : MonoBehaviour
{
    public float stickPushForce = 0f;
    private Rigidbody rb;
    public float maxForce = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        stickPushForce = rb.velocity.magnitude / maxForce;
    }
}
