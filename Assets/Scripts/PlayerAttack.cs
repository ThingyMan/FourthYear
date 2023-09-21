using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AttackAgain()
    {
        animator.ResetTrigger("Idle");
        if (animator.GetBool("CanAttack") == false)
        {
            animator.SetBool("CanAttack", true);
        }
        else
        {
            animator.SetBool("CanAttack", false);
        }
    }

    public void Idle()
    {
        animator.SetTrigger("Idle");
    }
    public void DisableIdle()
    {
        animator.ResetTrigger("Idle");
    }

    public void ResetHeavy()
    {
        animator.ResetTrigger("Heavy");
    }
}
