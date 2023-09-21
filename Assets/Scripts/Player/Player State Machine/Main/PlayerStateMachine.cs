using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
{
    #region VARIABLES
    //Debugging
    public bool testBool;
    public bool testBool2;
    public float testFloat = 50;

    public float sphereRadius;
    public LayerMask _groundLayer;

    //states
    PlayerBaseState _currentState;
    PlayerStateFactory _states;
    public int CurrentWeapon;
    int maxWeaponID = 1;
    bool _isSwitchingWeaponU = false;
    bool _isSwitchingWeaponD = false;
    bool _weaponSwitchOver = false;

    //active states
    public string activeState;
    public string activeSubState;

    //getter and setter
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

    //General Player Info
    public PlayerOverseer _playerOver;
    public Controls playerControls;
    [SerializeField] public Rigidbody rb;
    public Vector3 forceDirection = Vector3.zero;
    Animator _animator;
    Vector3 _forwardDirection;
    Vector3 _lateralMove;
    bool _hasControlOverLookAt = true;
    public GameObject[] AllObjects;
    public GameObject ClosestObject;
    float distance;
    public float pointRaidus;


    //Camera
    [SerializeField] private Camera playerCamera;

    //Input Actions
    InputAction _moveAction;
    private InputAction roll;

    //MOVEMENT VARIABLES
    //general movement variables
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float maxMovementSpeed = 5f;
    bool _isGrounded = true;
    public float _currentSpeed = 0f;
    public bool _titlingStick = false;
    bool _canMove = true;
    bool _isIdle = true;
    bool _isWalking = false;
    bool _isRunning = false;
    //rolling variables
    Coroutine _rollResetRoutine = null;
    Coroutine _teleportResetRoutine = null;
    public float rollForce = 1f;
    bool _isRolling = false;
    bool _canRoll = true;
    float _rollCoolDown = 1f;
    public float _rollHoldAmount = 0f;
    public float _rollMaxCharge;
    public float _rollChargeRate;
    bool _isHoldingRoll = false;
    bool _letGoOfRoll = false;
    bool _rollComplete = false;
    bool _isTeleporting = false;
    bool _teleportComplete = true;
    bool _letGoOfRollChecker = true;

    //ATTACKING VARIABLES
    Coroutine _currentAttackResetRoutine = null;
    bool _isAttacking = false;
    bool _isLightAttacking = false;
    bool _isHeavyAttacking = false;
    bool _isCharging = false;
    bool _isCurrentlyAttacking = false;
    bool _isCurrentlyHeavyAttacking = false;
    bool _enteredNewAttack = false;
    bool _willEnterNewAttack = false;
    int _nextHeavyAttackID = 0;
    bool _goToIdle = false;
    bool _teleportAttack = false;
    bool _doNotAttack = false;
    // animation hashes
    int _lightAttackHash;
    int _heavyAttackHash;
    int _lightAttackCount;
    int _heavyAttackCount;
    int _isChargingHash;
    int _chargeLevelHash;
    int _moveSpeedHash;
    int _lightAttackCountHash;
    int _heavyAttackCountHash;
    int _heavyAttackIDHash;
    int _pressedHeavyHash;
    int _teleportAttackHash;
    int _switchWeaponHash;
    int _weaponIDHash;
    int _isGroundedHash;
    int _rollHash;
    int _teleportHash;
    int _teleportLevelHash;


    #endregion

    #region GETTER & SETTERS
        #region MAIN
    public PlayerOverseer PlayerOver { get { return _playerOver; } set { _playerOver = value; } }
    public Animator Animator { get { return _animator; } }
    public InputAction MoveAction { get { return _moveAction; } }
    public Coroutine CurrentAttackResetRoutine { get { return _currentAttackResetRoutine; } set { _currentAttackResetRoutine = value; } }
    public Coroutine RollResetRoutine { get { return _rollResetRoutine; } set { _rollResetRoutine = value; } }
    public Coroutine TeleportResetRoutine { get { return _teleportResetRoutine; } set { _teleportResetRoutine = value; } }
    public Vector3 ForwardDireciton { get { return _forwardDirection; } set { _forwardDirection = value; } }
    public bool HasControlOverLookAt { get { return _hasControlOverLookAt; } set { _hasControlOverLookAt = value; } }

    #endregion  

        #region STATES
    public bool IsSwithcingWeaponUp { get { return _isSwitchingWeaponU; } set { _isSwitchingWeaponU = value; } }
    public bool IsSwithcingWeaponDown { get { return _isSwitchingWeaponD; } set { _isSwitchingWeaponD = value; } }
    public int MaxWeaponID { get { return maxWeaponID; } set { maxWeaponID = value; } }
    public bool WeaponSwitchOver { get { return _weaponSwitchOver; } set { _weaponSwitchOver = value; } }
    #endregion

        #region GENERAL MOVEMENT VARIABLES
    public bool TiltingStick { get { return _titlingStick; } }
    public float CurrentSpeed { get { return _currentSpeed; } set { _currentSpeed = value; } }
    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }
    public bool CanMove { get { return _canMove; } set { _canMove = value; } }
    public bool IsIdle { get { return _isIdle; } }
    public bool IsWalking { get { return _isWalking; } }
    public bool IsRunning { get { return _isRunning; } }
    #endregion

        #region ROLLING & TELEPORT VARIABLES
    public bool IsRolling { get { return _isRolling; } set { _isRolling = value; } }
    public bool CanRoll { get { return _canRoll; } set { _canRoll = value; } }
    public float RollCoolDown { get { return _rollCoolDown; } }
    public bool LetGoOfRoll { get { return _letGoOfRoll; } set { _letGoOfRoll = value; } }
    public float RollHoldAmount { get { return _rollHoldAmount; } set { _rollHoldAmount = value; } }
    public float RollMaxCharge { get { return _rollMaxCharge; } set { _rollMaxCharge = value; } }
    public float RollChargeRate { get { return _rollChargeRate; } set { _rollChargeRate = value; } }
    public bool RollComplete { get { return _rollComplete; } set { _rollComplete = value; } }
    public bool TeleportComplete { get { return _teleportComplete; } set { _teleportComplete = value; } }
    public bool LetGoOfRollChecker { get { return _letGoOfRollChecker; } set { _letGoOfRollChecker = value; } }
    public bool IsTeleporting { get { return _isTeleporting; } set { _isTeleporting = value; } }
    #endregion

        #region ATTACKING VARIABLES
    public bool IsAttacking { get { return _isAttacking; } set { _isAttacking = value; } }
    public bool IsLightAttacking { get { return _isLightAttacking; } }
    public bool IsHeavyAttacking { get { return _isHeavyAttacking; } }
    public bool IsCharging { get { return _isCharging; } }
    public bool IsCurrentlyAttacking { get { return _isCurrentlyAttacking; } set { _isCurrentlyAttacking = value; } }
    public bool IsCurrentlyHeavyAttacking { get { return _isCurrentlyHeavyAttacking; } set { _isCurrentlyHeavyAttacking = value; } }
    public int NextHeavyAttackID { get { return _nextHeavyAttackID; } set { _nextHeavyAttackID = value; } }
    public bool GoToIdle { get { return _goToIdle; } set { _goToIdle = value; } }
    public bool WillEnterNewAttack { get { return _willEnterNewAttack; } set { _willEnterNewAttack = value; } }
    public bool TeleportAttack { get { return _teleportAttack; } set { _teleportAttack = value; } }
    public bool EnteredNewAttack { get { return _enteredNewAttack; } set { _enteredNewAttack = value; } }
    public bool DoNotAttack { get { return _doNotAttack; } set { _doNotAttack = value; } }
    #endregion

        #region ANIMATION HASHES
    public int IsGroundedHash { get { return _isGroundedHash; } set { _isGroundedHash = value; } }
    public int MoveSpeedHash { get { return _moveSpeedHash; } set { _moveSpeedHash = value; } }

    public int WeaponIDHash { get { return _weaponIDHash; } set { _weaponIDHash = value; } }
    public int SwitchWeaponHash { get { return _switchWeaponHash; } set { _switchWeaponHash = value; } }

    public int LightAttackHash { get { return _lightAttackHash; } }
    public int HeavyAttackHash { get { return _heavyAttackHash; } }
    public int IsChargingHash { get { return _isChargingHash; } }
    public int LightAttackCount { get { return _lightAttackCount; } set { _lightAttackCount = value; } }
    public int HeavyAttackCount { get { return _heavyAttackCount; } set { _heavyAttackCount = value; } }
    public int LightAttackCountHash { get { return _lightAttackCountHash; } set { _lightAttackCountHash = value; } }
    public int HeavyAttackCountHash { get { return _heavyAttackCountHash; } set { _heavyAttackCountHash = value; } }
    public int HeavyAttackIDHash { get { return _heavyAttackIDHash; } set { _heavyAttackIDHash = value; } }
    public int PressedHeavyHash { get { return _pressedHeavyHash; } set { _pressedHeavyHash = value; } }
    public int ChargeLevel { get { return _chargeLevelHash; } set { _chargeLevelHash = value; } }

    public int RollHash { get { return _rollHash; } set { _rollHash = value; } }
    public int TeleportHash { get { return _teleportHash; } set { _teleportHash = value; } }
    public int TeleportLevelHash { get { return _teleportLevelHash; } set { _teleportLevelHash = value; } }


    #endregion

    #endregion
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        playerControls = new Controls();
        _states = new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        //_currentState._currentSubState = _states.Idle();
        _currentState.EnterState();

        #region ANIMATOR STRINGS TO HASH
        _lightAttackHash = Animator.StringToHash("AttackLight");
        _heavyAttackHash = Animator.StringToHash("AttackHeavy");
        _lightAttackCountHash = Animator.StringToHash("LightAttackCount");
        _heavyAttackCountHash = Animator.StringToHash("HeavyAttackCount");
        _heavyAttackIDHash = Animator.StringToHash("HeavyAttackID");
        _pressedHeavyHash = Animator.StringToHash("PressedHeavy");
        _isChargingHash = Animator.StringToHash("IsCharging");
        _chargeLevelHash = Animator.StringToHash("ChargeLevel");
        _moveSpeedHash = Animator.StringToHash("Speed");
        _switchWeaponHash = Animator.StringToHash("SwapWeapon");
        _weaponIDHash = Animator.StringToHash("Weaponid");
        _isGroundedHash = Animator.StringToHash("IsGrounded");
        _rollHash = Animator.StringToHash("Roll");
        _teleportHash = Animator.StringToHash("Teleport");
        #endregion
    }

    private void OnEnable()
    {
        playerControls.PlayerSword.AttackL.started += DoAttack;
        playerControls.PlayerSword.AttackL.canceled += DoAttack;
        playerControls.PlayerSword.AttackH.started += DoAttackH;
        playerControls.PlayerSword.AttackH.canceled += DoAttackH;
        playerControls.PlayerSword.Roll.started += DoRoll;
        playerControls.PlayerSword.Roll.canceled += DoRoll;
        playerControls.PlayerSword.Roll.canceled += DoRollCancel;
        playerControls.PlayerSword.ChangeWeaponUp.started += DoChangeUp;
        playerControls.PlayerSword.ChangeWeaponUp.canceled += DoChangeUp;
        playerControls.PlayerSword.ChangeWeaponUp.started += DoChangeDown;
        playerControls.PlayerSword.ChangeWeaponUp.canceled += DoChangeDown;

        roll = playerControls.PlayerSword.Roll;
        _moveAction = playerControls.PlayerSword.Move;
        playerControls.PlayerSword.Enable();
    }

    private void OnDisable()
    {
        playerControls.PlayerSword.AttackL.started -= DoAttack;
        playerControls.PlayerSword.AttackL.canceled -= DoAttack;
        playerControls.PlayerSword.AttackH.started -= DoAttackH;
        playerControls.PlayerSword.AttackH.canceled -= DoAttackH;
        playerControls.PlayerSword.Roll.started -= DoRoll;
        playerControls.PlayerSword.Roll.canceled -= DoRoll;
        playerControls.PlayerSword.Roll.canceled -= DoRollCancel;
        playerControls.PlayerSword.Disable();
    }

    private void Update()
    {
        _currentState.UpdateStates();

        _currentSpeed = rb.velocity.magnitude / maxMovementSpeed;
        GroundedCheck();
        SpeedChecker();

        //if(Physics.CheckSphere(transform.position, sphereRadius, _groundLayer))
        //{
        //    testBool = true;
        //}

        if(_isHoldingRoll == true)
        {
            DoRollCharge();
        }
        else
        {
            _rollHoldAmount = 0;
        }

        _forwardDirection = this.gameObject.transform.forward;

        if (_canRoll)
        {
            testBool = true;
        }
        else
        {
            testBool = false;
        }

        if(_isTeleporting == false)
        {
            testBool2 = true;
        }
        else
        {
            testBool2 = false;
        }

        activeState = _currentState.ToString();
        activeSubState = _currentState._currentSubState.ToString();
    }

    void SpeedChecker()
    {
        //_animator.SetFloat(_moveSpeedHash, _currentSpeed);

        if(_currentSpeed < 0f)
        {
            _currentSpeed = 0f;
        }
        else if(CurrentSpeed > maxMovementSpeed)
        {
            CurrentSpeed = maxMovementSpeed;
        }
    }

    private void FixedUpdate()
    {
        if (_canMove == true)
        {
            //get location 
            forceDirection += _moveAction.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementSpeed;
            forceDirection += _moveAction.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementSpeed;

            rb.AddForce(forceDirection, ForceMode.Impulse);
            forceDirection = Vector3.zero;
        }

        //player falls faster overtime
        if (rb.velocity.y < 0f)
        {
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        }

        if (_isRolling == false)
        {
            //stops the player moving too fast 
            Vector3 horizontalVelocity = rb.velocity;
            horizontalVelocity.y = 0f;
            if (horizontalVelocity.sqrMagnitude > maxMovementSpeed * maxMovementSpeed)
            {
                rb.velocity = horizontalVelocity.normalized * maxMovementSpeed + Vector3.up * rb.velocity.y;
            }
        }

        //if (testBool2)
        //{
        //    testBool2 = false;
        //    rb.AddForce(gameObject.transform.forward * testFloat, ForceMode.Impulse);
        //}

        FindClosestEnemy();

        if (_hasControlOverLookAt)
        {
            LookAt();
        }

    }

    void FindClosestEnemy()
    {
        AllObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < AllObjects.Length; i++)
        {
            distance = Vector3.Distance(this.transform.position, AllObjects[i].transform.position);

            if (distance < pointRaidus)
            {
                ClosestObject = AllObjects[i];
            }
        }
    }

    private void LookAt()
    {
        //player looks in direction they move
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if (_moveAction.ReadValue<Vector2>().sqrMagnitude > 0.01f && direction.sqrMagnitude > 0.01f)
        {
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
            _titlingStick = true;
        }
        else
        {
            _titlingStick = false;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void GroundedCheck()
    {
        if (Physics.CheckSphere(transform.position, sphereRadius, _groundLayer))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }

        //Ray ray = new Ray(this.transform.position + Vector3.up, Vector3.down);
        //if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
        //{
        //    _isGrounded = true;
        //}
        //else
        //{
        //    _isGrounded = false;
        //}
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
        _isLightAttacking = obj.ReadValueAsButton();
        _isAttacking = obj.ReadValueAsButton();
        //animator.ResetTrigger("HeavyAttack");
        //animator.SetTrigger("GroundedAttack");
    }

    private void DoAttackH(InputAction.CallbackContext obj)
    {
        _isHeavyAttacking = obj.ReadValueAsButton();
        //animator.ResetTrigger("HeavyAttack");
        //animator.SetTrigger("HeavyAttack");
    }

    private void DoRollCharge()
    {
        if(_canRoll == true)
        {
            _rollHoldAmount += _rollChargeRate;
        }
    }

    private void DoRoll(InputAction.CallbackContext obj)
    {
        _isHoldingRoll = obj.ReadValueAsButton();

        if (_canRoll == true)
        {
            //_canRoll = false;
            //_isRolling = true;
            //Vector3 rollDirection;
            //rollDirection = this.gameObject.transform.forward;
            //forceDirection += rollDirection * rollForce;

            //rb.AddForce(forceDirection, ForceMode.Impulse);
            //forceDirection = Vector3.zero;

            //_animator.SetTrigger("pRoll");

            //StartCoroutine(RollCoolDownTimer());
        }
    }

    private void DoRollCancel(InputAction.CallbackContext obj)
    {
        if(_letGoOfRollChecker == true)
        {
            _letGoOfRoll = true;
        }
    }

    void DoChangeUp(InputAction.CallbackContext obj)
    {
        _isSwitchingWeaponU = obj.ReadValueAsButton();
    }

    void DoChangeDown(InputAction.CallbackContext obj)
    {
        _isSwitchingWeaponD = obj.ReadValueAsButton();
    }

    IEnumerator RollCoolDownTimer()
    {
        yield return new WaitForSeconds(_rollCoolDown);
        _canRoll = true;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, sphereRadius);
    }

    public void PushPlayer(float upwardsForce, float downwardsForce, float forwardForce, float backWardsForce, float leftForce, float rightFroce)
    {
        //isRolling();
        //Vector3 rollDirection;
        //rollDirection = this.gameObject.transform.forward;
        //forceDirection += rollDirection * force;

        rb.AddForce(gameObject.transform.forward * forwardForce, ForceMode.Impulse);
        rb.AddForce(gameObject.transform.forward * -backWardsForce, ForceMode.Impulse);
        rb.AddForce(gameObject.transform.up * upwardsForce, ForceMode.Impulse);
        rb.AddForce(gameObject.transform.up * -downwardsForce, ForceMode.Impulse);
        rb.AddForce(gameObject.transform.right * rightFroce, ForceMode.Impulse);
        rb.AddForce(gameObject.transform.right * -leftForce, ForceMode.Impulse);
        //forceDirection = Vector3.zero;
    }
}
