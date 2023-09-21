using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnimation : MonoBehaviour
{
    Rigidbody rb;
    GoblinStateMachine _ctx;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _ctx = GetComponent<GoblinStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
