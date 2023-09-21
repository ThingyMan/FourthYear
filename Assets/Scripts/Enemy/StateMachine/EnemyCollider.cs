using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    public float _enemyHealth;
    public float _enemyHealthMax;
    public float _enemyDef;

    public float _postureMaxValue;
    public float _postureValue;
    public float _postureRecoverRate;
    public float _postureLaunchThreshold;
    public float _postureFlinchThreshold;
    public bool _canRecoverPosture = true;
    public bool _canTakePostureDamage = true;

    public bool wasLaunched = false;
    public bool wasHit;
    public bool canBeLaunched = false;
    public bool canBeFlinched = false;
    public float _postureDamageToTake = 0;

    WeaponCollider weaponCol;
    // Start is called before the first frame update
    void Start()
    {
        _enemyHealth = _enemyHealthMax;
        _postureValue = _postureMaxValue;
        weaponCol = GameObject.FindGameObjectWithTag("WeaponCol").GetComponent<WeaponCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        PostureSettings();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("hit");

            //PostureDamageCalc();
            wasHit = true;
            //DamageCalc();
            
        }
    }

    public void PostureSettings()
    {
        if (_canRecoverPosture && _postureValue < _postureMaxValue)
        {
            _postureValue += _postureRecoverRate * Time.deltaTime;
        }
        if (_postureValue <= _postureLaunchThreshold)
        {
            canBeLaunched = true;
        }
        else
        {
            canBeLaunched = false;
        }
        if (_postureValue <= _postureFlinchThreshold)
        {
            canBeFlinched = true;
        }
        else
        {
            canBeFlinched = false;
        }
    }



}
