using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerController : MonoBehaviour
{
    //declare ref variable
    public Controls playerControls;
    CharacterController characterController;
    Animator animator;

    //variables to store the players input values
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;

    private void Awake()
    {
        playerControls = new Controls();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

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

    }

    // Update is called once per frame
    void Update()
    {
        handleAnimation();
        characterController.Move(currentMovement * Time.deltaTime);
    }

    private void OnEnable()
    {
        //enable controls
        playerControls.PlayerSword.Enable();
    }

    private void OnDisable()
    {
        //disable controls
        playerControls.PlayerSword.Disable();
    }
}
