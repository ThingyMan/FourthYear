
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponID : MonoBehaviour
{
    public int weaponType;
    public WeaponSwitching weaponSwitcher;
    public GameObject player;

    public BoxCollider col;

    public float minDmg;
    public float maxDmg;

    public float shakeAmount;
    public float shakeTime;

    public float ChangeTime;
    public int RestoreTime;
    public float Delay;

    public float forwardForce;
    public float backwardForce;
    public float upwardsForce;
    public float downwardsForce;
    public float leftForce;
    public float rightForce;


    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        weaponSwitcher.currentWeapon = this;
        weaponSwitcher.animator.SetInteger("WeaponId", weaponType);
        player = GameObject.FindGameObjectWithTag("Player");
        col = GameObject.FindGameObjectWithTag("WeaponCol").GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetForces()
    {
        forwardForce = 0;
        backwardForce = 0;
        upwardsForce = 0;
        downwardsForce = 0;
        leftForce = 0;
        rightForce = 0;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (col.gameObject.CompareTag("Enemy"))
    //    {
    //        Cinemachine_Shake.Instance.ShakeCam(shakeAmount, shakeTime);
    //        Time_Stop.Instance.StopTime(ChangeTime, RestoreTime, Delay);

    //        other.gameObject.GetComponent<Rigidbody>().AddForce(player.transform.forward * forwardForce, ForceMode.Impulse);
    //        other.gameObject.GetComponent<Rigidbody>().AddForce(player.transform.up * upwardsForce, ForceMode.Impulse);
    //        other.gameObject.GetComponent<Rigidbody>().AddForce(player.transform.up * -downwardsForce, ForceMode.Impulse);
    //        other.gameObject.GetComponent<Rigidbody>().AddForce(player.transform.right * rightForce, ForceMode.Impulse);
    //        other.gameObject.GetComponent<Rigidbody>().AddForce(player.transform.right * -leftForce, ForceMode.Impulse);
    //    }

    //}
}
