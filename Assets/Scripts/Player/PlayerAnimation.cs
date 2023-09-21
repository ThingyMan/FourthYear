using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private float maxSpeed = 5f;
    private PlayerMovement playerMove;
    private Vector3 forceDirection = Vector3.zero;
    public WeaponSwitching weaponSwap;
    EnemyTeleportPoint teleporter;

    public GameObject weaponCol;
    WeaponCollider weaponCollider;
    public Transform switchHandsTrans;

    WeaponID activeWeapon;

    public bool isSheathed = false;

    PlayerStateMachine _ctx;

    float currentForwardForce = 0;
    bool pushForward = false;
    bool startedNewAirAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        weaponCol = GameObject.FindGameObjectWithTag("WeaponCol");
        weaponCollider = weaponCol.GetComponent<WeaponCollider>();
        _ctx = GetComponent<PlayerStateMachine>();
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        playerMove = this.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        activeWeapon = weaponSwap.currentWeapon;
        animator.SetFloat("Speed", rb.velocity.magnitude / maxSpeed);
    }

    private void FixedUpdate()
    {
        if (pushForward)
        {
            pushForward = false;
            rb.velocity = Vector3.zero;
            rb.AddForce(gameObject.transform.forward * currentForwardForce, ForceMode.Impulse);
            //rb.AddForce(gameObject.transform.forward * currentForwardForce, ForceMode.Impulse);
        }
    }

    public void SetForce(string floats)
    {
        string[] strings = null;
        strings = floats.Split(',');
        activeWeapon.forwardForce = float.Parse(strings[0]);
        activeWeapon.backwardForce = float.Parse(strings[1]);
        activeWeapon.upwardsForce = float.Parse(strings[2]);
        activeWeapon.downwardsForce = float.Parse(strings[3]);
        activeWeapon.leftForce = float.Parse(strings[4]);
        activeWeapon.rightForce = float.Parse(strings[5]);
    }

    public void SetWeaponColliderSize(string floats)
    {
        string[] strings = null;
        strings = floats.Split(',');
        float sizeX = float.Parse(strings[0]) / 100000;
        float sizeY = float.Parse(strings[1]) / 1000;
        float sizeZ = float.Parse(strings[2]) / 1000;

        activeWeapon.gameObject.GetComponent<BoxCollider>().size = new Vector3 (sizeX, sizeY, sizeZ);
    }
    public void SetWeaponColliderCentre(string floats)
    {
        string[] strings = null;
        strings = floats.Split(',');
        float sizeX = float.Parse(strings[0]);
        float sizeY = float.Parse(strings[1]);
        float sizeZ = float.Parse(strings[2]);

        activeWeapon.gameObject.GetComponent<BoxCollider>().center = new Vector3(sizeX, sizeY, sizeZ);
    }

    public void AttackAnimStarted()
    {
        activeWeapon.ResetForces();
        _ctx.IsCurrentlyAttacking = true;
        weaponCol.gameObject.GetComponent<BoxCollider>().enabled = true;
        _ctx.EnteredNewAttack = true;
        _ctx.WillEnterNewAttack = false;
    }

    public void AttackAnimEnd()
    {
        _ctx.IsCurrentlyAttacking = false;
        weaponCollider.disableEnemyGravity = false;
        weaponCol.gameObject.GetComponent<BoxCollider>().enabled = false;
        _ctx.GoToIdle = true;

        for(var i = 0; i < weaponCollider.hitEnemies.Count; i++)
        {
            weaponCollider.hitEnemies[i].idHit = -1; 
        }

        weaponCollider.canLaunch = false;
        weaponCollider.postureDamage = 0;

        activeWeapon.ResetForces();
    }

    public void EnemyDragData(float newDrag)
    {
        weaponCollider.dragValue = newDrag;
    }

    public void IsNewAttack(int newID)
    {
        weaponCollider.attackID = newID;
    }

    public void AttackCanLaunch()
    {
        weaponCollider.canLaunch = true;
    }
    public void ResetLaunch()
    {
        weaponCollider.canLaunch = false;
    }

    public void SetPostureDamage(float damage)
    {
        weaponCollider.postureDamage = damage;
    }

    public void HeavyAttackEnd()
    {
        _ctx.IsCurrentlyHeavyAttacking = false;
    }

    public void DisableWeaponCollider()
    {
        weaponCol.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public void NoGravityAttack(float time)
    {
        weaponCollider.disableEnemyGravity = true;
        weaponCollider.disableGravityTime = time;
    }

    public void ResetEnemyGravityStat()
    {
        weaponCollider.disableEnemyGravity = false;
        weaponCollider.disableGravityTime = 0;
    }

    public void AllowMovement()
    {
        _ctx.CanMove = true;
    }

    public void DisableMovement()
    {
        _ctx.CanMove = false;
    }

    public void EnableGravity()
    {
        rb.useGravity = true;
    }

    public void DisableGravity()
    {
        rb.useGravity = false;
    }

    public void DisableRoll()
    {
        _ctx.CanRoll = false;
    }

    public void isRolling()
    {
        _ctx.IsRolling = true;
    }
    public void isNotRolling()
    {
        _ctx.IsRolling = false;
    }
    public void CompleteRoll()
    {
        _ctx.RollComplete = true;
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

    public void PushUp(float upwardsForce)
    {
        rb.AddForce(gameObject.transform.up * upwardsForce, ForceMode.Impulse);
    }

    public void PushDown(float downwardsForce)
    {
        rb.AddForce(gameObject.transform.up * -downwardsForce, ForceMode.Impulse);
    }

    public void PushForward(float forwardForce)
    {
        currentForwardForce = forwardForce;
        pushForward = true;
        
        //_ctx.testBool2 = true;
        //rb.AddForce(gameObject.transform.forward * forwardForce, ForceMode.Impulse);
    }

    public void PushBackward(float backWardsForce)
    {
        rb.AddForce(gameObject.transform.forward * -backWardsForce, ForceMode.Impulse);
    }

    public void PushLeft(float leftForce)
    {
        rb.AddForce(gameObject.transform.right * -leftForce, ForceMode.Impulse);
    }

    public void PushRight(float rightForce)
    {
        rb.AddForce(gameObject.transform.right * rightForce, ForceMode.Impulse);
    }




    public void SwitchWeapon()
    {
        _ctx.Animator.SetBool(_ctx.SwitchWeaponHash, false);
        weaponSwap.changeWeapon = true;
    }

    public void WeaponSwitchEnd()
    {
        _ctx.WeaponSwitchOver = true;
    }

    public void SwitchWeaponHands()
    {
        weaponCol.GetComponent<WeaponCollider>().switchHands = true;
    }

    public void SwitchHandsBackToNormal()
    {
        weaponCol.GetComponent<WeaponCollider>().switchHands = false;
    }

    public void SheathBlade()
    {
        if(weaponSwap.currentWeapon.weaponType == 1)
        {
            if (isSheathed == false)
            {
                isSheathed = true;
                weaponSwap.currentWeapon.gameObject.GetComponent<BladeSorter>().elapsedTime = 0f;
                weaponSwap.currentWeapon.gameObject.GetComponent<BladeSorter>().isCurrentlySheathed = true;
            }
        }
    }

    public void UnSheathBalde()
    {
        if (weaponSwap.currentWeapon.weaponType == 1)
        {
            if(isSheathed == true)
            {
                isSheathed = false;
                weaponSwap.currentWeapon.gameObject.GetComponent<BladeSorter>().elapsedTime = 0f;
                weaponSwap.currentWeapon.gameObject.GetComponent<BladeSorter>().isCurrentlySheathed = false;
            }
        }
    }

    public void LookAtTeleportPoint()
    {
        _ctx.IsTeleporting = true;
        _ctx.HasControlOverLookAt = false;
        teleporter = _ctx.ClosestObject.gameObject.GetComponent<EnemyTeleportPoint>();
        gameObject.transform.LookAt(teleporter.transform.position);
    }

    public void TeleportPlayer()
    {
        _ctx.TeleportComplete = false;
        _ctx.IsTeleporting = true;
        teleporter = _ctx.ClosestObject.gameObject.GetComponent<EnemyTeleportPoint>();

        teleporter.gameObject.GetComponent<Rigidbody>().useGravity = false;
        teleporter.gameObject.GetComponent<EnemyBasicData>().floatTime = 2f;
        teleporter.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        StartCoroutine(teleporter.gameObject.GetComponent<EnemyBasicData>().IGravityResetRoutine());

        gameObject.transform.position = teleporter.tpPoint.transform.position;
    }

    public void TeleportComplete()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.x = 0;
        rotationVector.z = 0;
        _ctx.TeleportComplete = true;
        _ctx.HasControlOverLookAt = true;
        gameObject.transform.rotation = Quaternion.Euler(rotationVector);
    }

    public void PlayerLanded()
    {
        _ctx.CanRoll = true;
    }
}
