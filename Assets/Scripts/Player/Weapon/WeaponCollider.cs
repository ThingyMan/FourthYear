using System.Collections;
using System.Collections.Generic;
//using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public Transform objectToFollow;
    public WeaponSwitching weaponHolder;
    public WeaponID currentWeapon;

    public bool switchHands = false;
    public Transform switchHandTrans;

    public PlayerOverseer playerOver;

    public bool switchedWeapon = false;
    bool handIsNormalCheck = true;
    public Transform[] weaponTransforms;

    public float minDmg;
    public float maxDmg;
    public float postureDamage;

    public List<EnemyBasicData> hitEnemies = new List<EnemyBasicData>();

    public bool disableEnemyGravity = false;
    public float disableGravityTime = 0f;
    public int attackID = 0;

    public bool canLaunch = false;

    public float dragValue = 1f;

    public GameObject[] VFXs;
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = weaponHolder.currentWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = objectToFollow.position;
        gameObject.transform.rotation = objectToFollow.rotation;
        currentWeapon = weaponHolder.currentWeapon;

        minDmg = currentWeapon.minDmg;
        maxDmg = currentWeapon.maxDmg;

        if (switchHands == true)
        {
            handIsNormalCheck = false;
            //use the set tranform for the left hand (might need to make a list of transforms there)
            currentWeapon.gameObject.transform.position = switchHandTrans.transform.position;
            currentWeapon.gameObject.transform.rotation = switchHandTrans.transform.rotation;
        }
        else
        {
            //do this check so it only changes the position once 
            if(handIsNormalCheck == false)
            {
                handIsNormalCheck = true;
                //use the list of transforms on the "Weapon_Transforms" children
                currentWeapon.transform.position = weaponTransforms[currentWeapon.weaponType].position;
                currentWeapon.transform.rotation = weaponTransforms[currentWeapon.weaponType].rotation;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //id check so the enemy doesnt get multihit by regular attacks
            if(other.GetComponent<EnemyBasicData>().idHit != attackID)
            {
                //change the enemy's current id to match the attack for the statement above
                other.GetComponent<EnemyBasicData>().idHit = attackID;

                //add the enemy to the list of hit enemies to reset their id once the attack is finished
                hitEnemies.Add(other.GetComponent<EnemyBasicData>());

                //if (canLaunch)
                //{
                //    other.gameObject.GetComponent<EnemyCollider>().wasLaunched = true;
                //}

                //if the attack cancels the enemies gravity
                if (disableEnemyGravity == true)
                {
                    //keep them in the air for a certain amount of time
                    other.gameObject.GetComponent<EnemyBasicData>().rb.useGravity = false;
                    other.gameObject.GetComponent<EnemyBasicData>().floatTime = disableGravityTime;
                    StartCoroutine(other.gameObject.GetComponent<EnemyBasicData>().IGravityResetRoutine());
                }

                if (other.GetComponent<EnemyCollider>()._canTakePostureDamage == true)
                {
                    float _postureDamageToTake;
                    _postureDamageToTake = postureDamage;
                    other.GetComponent<EnemyCollider>()._postureValue -= _postureDamageToTake;
                }

                DamageCalc(other.GetComponent<EnemyCollider>());

                

                Cinemachine_Shake.Instance.ShakeCam(currentWeapon.shakeAmount, currentWeapon.shakeTime);
                Time_Stop.Instance.StopTime(currentWeapon.ChangeTime, currentWeapon.RestoreTime, currentWeapon.Delay);

                if (other.GetComponent<EnemyCollider>().canBeLaunched)
                {
                    //push enemy with the force applied to weapon
                    other.gameObject.GetComponent<Rigidbody>().AddForce(currentWeapon.player.transform.forward * currentWeapon.forwardForce, ForceMode.Impulse);
                    other.gameObject.GetComponent<Rigidbody>().AddForce(currentWeapon.player.transform.up * currentWeapon.upwardsForce, ForceMode.Impulse);
                    other.gameObject.GetComponent<Rigidbody>().AddForce(currentWeapon.player.transform.up * -currentWeapon.downwardsForce, ForceMode.Impulse);
                    other.gameObject.GetComponent<Rigidbody>().AddForce(currentWeapon.player.transform.right * currentWeapon.rightForce, ForceMode.Impulse);
                    other.gameObject.GetComponent<Rigidbody>().AddForce(currentWeapon.player.transform.right * -currentWeapon.leftForce, ForceMode.Impulse);
                    //other.gameObject.GetComponent<Rigidbody>().drag = dragValue;
                }

                if(canLaunch == true)
                {
                    other.GetComponent<EnemyCollider>().wasLaunched = true;
                }
            }
        }
    }

    public void PostureDamageCalc()
    {

    }

    public void DamageCalc(EnemyCollider enemy)
    {
        float randomDamage;
        float damageToTake;

        enemy.wasHit = true;

        randomDamage = Random.Range(minDmg, maxDmg);

        damageToTake = randomDamage -= enemy._enemyDef;

        enemy._enemyHealth -= damageToTake;
    }
}
