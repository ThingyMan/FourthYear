using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinStateMachine : MonoBehaviour
{
    public GameObject player;
    public Collider playerCol;
    public bool testBool;
    public bool showGizmo = false;

    public string activeState;
    public string activeSubState;

    public float sphereRadius;
    public LayerMask _groundLayer;
    public Transform groundCheckPos;
    public float dragDecreaseRate;

    //Setup variables
    public EnemyCollider enemyCol;
    GoblinBaseState _currentState;
    GoblinStateFactory _states;
    [SerializeField] public Rigidbody rb;
    public Animator _animator;
    bool _isGrounded = true;
    bool _hasLanded = true;

    //Movement Variables
    //[SerializeField] private float movementSpeed = 1f;
    //[SerializeField] private float maxMovementSpeed = 5f;

    //Posture variables
    //public float _postureMaxValue;
    //public float _postureValue;
    //public float _postureRecoverRate;
    //public float _postureBreakThreshold;
    //bool _canRecoverPosture = true;

    //animation hashes
    int _groundedHash;
    int _hitHash;
    int _launchedHash;
    int _smashedHash;
    int _postureHash;
    int _flinchHash;
    int _deathHash;


    #region GETTERS & SETTERS

    public GoblinBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public Animator Animator { get { return _animator; } }

    #region COMBAT VARIABLES
    //public bool CanRecoverPosture { get { return _canRecoverPosture; } set { _canRecoverPosture = value; } }

    #endregion

    #region MOVEMENT VARIABLES
    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }
    public bool HasLanded { get { return _hasLanded; } set { _hasLanded = value; } }
    #endregion

    #region ANIMATION HASHES
    public int GroundedHash { get { return _groundedHash; } set { _groundedHash = value; } }
    public int HitHash { get { return _hitHash; } set { _hitHash = value; } }
    public int LaunchedHash { get { return _launchedHash; } set { _launchedHash = value; } }
    public int SmashedHash { get { return _smashedHash; } set { _smashedHash = value; } }
    public int PostureHash { get { return _postureHash; } set { _postureHash = value; } }
    public int FlinchHash { get { return _flinchHash; } set { _flinchHash = value; } }
    public int DeathHash { get { return _deathHash; } set { _deathHash = value; } }
    #endregion



    #endregion

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCol = player.GetComponent<Collider>();
        //Physics.IgnoreCollision(playerCol, GetComponent<Collider>());

        enemyCol = GetComponent<EnemyCollider>();
        groundCheckPos = gameObject.transform.Find("Ground_Check_Pos");
        _animator = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        _states = new GoblinStateFactory(this);
        _currentState = _states.Grounded();
        //_currentState._currentSubState = _states.Idle();
        _currentState.EnterState();

        _groundedHash = Animator.StringToHash("Grounded");
        _hitHash = Animator.StringToHash("Hit");
        _launchedHash = Animator.StringToHash("Launched");
        _smashedHash = Animator.StringToHash("Smashed");
        _postureHash = Animator.StringToHash("Posture");
        _flinchHash = Animator.StringToHash("Flinch");
        _deathHash = Animator.StringToHash("Dead");

        Animator.SetBool(_groundedHash, true);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateStates();
        GroundCheck();

        //if (_canRecoverPosture && _postureValue < _postureMaxValue)
        //{
        //    _postureValue += _postureRecoverRate;
        //}

        Animator.SetFloat(_postureHash, enemyCol._postureValue);

        if (_isGrounded)
        {
            testBool = true;
        }
        else
        {
            testBool = false;
        }

        activeState = _currentState.ToString();
        activeSubState = _currentState._currentSubState.ToString();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0f && rb.useGravity == true)
        {
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        }
    }

    void GroundCheck()
    {
        if (Physics.CheckSphere(groundCheckPos.position, sphereRadius, _groundLayer))
        {
            _isGrounded = true;
            rb.drag = 1;
        }
        else
        {
            _isGrounded = false;
        }

        if (rb.drag > 1)
        {
            rb.drag -= dragDecreaseRate * Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        if (showGizmo == true)
        {
            Gizmos.DrawSphere(groundCheckPos.position, sphereRadius);
        }
    }
}
