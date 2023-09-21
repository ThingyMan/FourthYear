using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicData : MonoBehaviour
{
    public bool showGizmo = false;
    public Rigidbody rb;
    public Coroutine noGravityTime;
    public float floatTime;

    public int idHit;
    public float dragDecreaseRate;

    public bool isGrounded = true;
    public float sphereRadius;
    public LayerMask _groundLayer;
    //public Transform groundCheckPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //groundCheckPos = gameObject.transform.Find("Ground_Check_Pos");
    }

    // Update is called once per frame
    void Update()
    {
        //if(rb.useGravity == true)
        //{
        //    GroundCheck();
        //}

        //if(rb.drag > 1)
        //{
        //    rb.drag -= dragDecreaseRate * Time.deltaTime;
        //}
    }

    void GroundCheck()
    {
        //if (Physics.CheckSphere(groundCheckPos.position, sphereRadius, _groundLayer))
        //{
        //    isGrounded = true;
        //    rb.drag = 1;
        //}
        //else
        //{
        //    isGrounded = false;
        //}
    }

    public IEnumerator IGravityResetRoutine()
    {
        yield return new WaitForSeconds(floatTime);
        //rb.drag = 15;
        floatTime = 0f;
        rb.useGravity = true;
    }

    private void OnDrawGizmos()
    {
        //if(showGizmo == true)
        //{
        //    Gizmos.DrawSphere(groundCheckPos.position, sphereRadius);
        //}
    }
}
