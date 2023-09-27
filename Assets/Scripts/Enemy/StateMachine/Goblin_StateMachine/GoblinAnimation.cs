using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnimation : MonoBehaviour
{
    Rigidbody rb;
    GoblinStateMachine _ctx;

    bool isDead = false;
    public GameObject DeathVfx;
    public GameObject parentPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _ctx = GetComponent<GoblinStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == true)
        {
            isDead = false;
            StartCoroutine(DeathRoutine());
        }
    }

    IEnumerator DeathRoutine()
    {
        yield return new WaitForSecondsRealtime(2f);
        Instantiate(DeathVfx, gameObject.transform.position, parentPos.transform.rotation, parentPos.transform);
        Destroy(gameObject);
    }

    public void ResetHit()
    {
        _ctx.Animator.ResetTrigger(_ctx.HitHash);
    }

    public void Dead()
    {
        isDead = true;
    }
}
