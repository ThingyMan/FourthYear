using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public Controls playerControls;
    private InputAction move;
    private InputAction roll;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float maxMovementSpeed = 5f;
    [SerializeField] private float rollForce = 1f;
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField] private Camera playerCamera;

    public Animator animator;
    public bool testBool;

    public bool canMove;
    public bool isRolling;
    private bool canRoll = true;
    public float rollCoolDown;

    public bool isIdle;

    private void Awake()
    {
        playerControls = new Controls();
    }

    private void OnEnable()
    {
        playerControls.PlayerSword.AttackL.started += DoAttack;
        playerControls.PlayerSword.AttackH.started += DoAttackH;
        playerControls.PlayerSword.Roll.started += DoRoll;

        roll = playerControls.PlayerSword.Roll;
        move = playerControls.PlayerSword.Move;
        playerControls.PlayerSword.Enable();
    }

    private void OnDisable()
    {
        playerControls.PlayerSword.AttackL.started -= DoAttack;
        playerControls.PlayerSword.Roll.started -= DoRoll;
        playerControls.PlayerSword.AttackH.started -= DoAttackH;
        playerControls.PlayerSword.Disable();
    }

    private void FixedUpdate()
    {
        if(canMove == true)
        {
            //get location 
            forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementSpeed;
            forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementSpeed;

            rb.AddForce(forceDirection, ForceMode.Impulse);
            forceDirection = Vector3.zero;
        }

        //player falls faster overtime
        if(rb.velocity.y < 0f)
        {
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        }

        if(isRolling == false)
        {
            //stops the player moving too fast 
            Vector3 horizontalVelocity = rb.velocity;
            horizontalVelocity.y = 0f;
            if (horizontalVelocity.sqrMagnitude > maxMovementSpeed * maxMovementSpeed)
            {
                rb.velocity = horizontalVelocity.normalized * maxMovementSpeed + Vector3.up * rb.velocity.y;
            }
        }

        LookAt();
    }

    private void LookAt()
    {
        //player looks in direction they move
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if(move.ReadValue<Vector2>().sqrMagnitude > 0.01f && direction.sqrMagnitude > 0.01f)
        {
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }

    //gets camera position
    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0f;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0f;
        return right.normalized;
    }

    private void DoAttack(InputAction.CallbackContext obj)
    {
        animator.ResetTrigger("HeavyAttack");
        animator.SetTrigger("GroundedAttack");
    }

    private void DoAttackH(InputAction.CallbackContext obj)
    {
        animator.ResetTrigger("HeavyAttack");
        animator.SetTrigger("HeavyAttack");
    }

    private void DoRoll(InputAction.CallbackContext obj)
    {
        if (canRoll == true)
        {
            canRoll = false;
            isRolling = true;
            Vector3 rollDirection;
            rollDirection = this.gameObject.transform.forward;
            forceDirection += rollDirection * rollForce;

            rb.AddForce(forceDirection, ForceMode.Impulse);
            forceDirection = Vector3.zero;

            animator.SetTrigger("pRoll");

            StartCoroutine(RollCoolDown());
        }
    }

    IEnumerator RollCoolDown()
    {
        yield return new WaitForSeconds(rollCoolDown);
        canRoll = true;

    }

    private bool IsGrounded()
    {
        //checks if player is grounded
        Ray ray = new Ray(this.transform.position + Vector3.up , Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
            return true;
        else
            return false;
    }
}
