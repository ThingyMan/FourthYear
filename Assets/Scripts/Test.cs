using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    //declare ref variable
    public Controls playerControls;
    CharacterController characterController;
    Animator animator;

    private InputAction move;

    //variables to store the players input values
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;

    Rigidbody rb;
    public float maxSpeed = 5f;

    private void Awake()
    {
        playerControls = new Controls();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        playerControls.PlayerSword.Move.started += onMovementInput;
        playerControls.PlayerSword.Move.canceled += onMovementInput;
        playerControls.PlayerSword.Move.performed += onMovementInput;
    }

    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void handleAnimation()
    {
        animator.SetFloat("Speed", rb.velocity.magnitude / maxSpeed);
    }

    private void LookAt()
    {
        //player looks in direction they move
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.01f && direction.sqrMagnitude > 0.01f)
        {
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleAnimation();
        characterController.Move(currentMovement * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        
    }

    private void OnEnable()
    {
        //enable controls
        playerControls.PlayerSword.Enable();
        move = playerControls.PlayerSword.Move;
    }

    private void OnDisable()
    {
        //disable controls
        playerControls.PlayerSword.Disable();
    }
}

