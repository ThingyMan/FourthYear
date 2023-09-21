using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public PlayerStateMachine playerState;
    public int selectedWeapon = 0;
    public bool changeWeapon = false;
    public WeaponID currentWeapon;
    public GameObject activeWeapon;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = playerState.gameObject.GetComponent<Animator>();
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {

        if (changeWeapon)
        {
            changeWeapon = false;
            SelectWeapon();
            //if(selectedWeapon >= transform.childCount - 1)
            //{
            //    selectedWeapon = 0;
            //}
        }
    }

    void SelectWeapon()
    {
        int i = selectedWeapon;
        selectedWeapon = playerState.CurrentWeapon;
        foreach (Transform weapon in transform)
        {
            if(i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;   
        }
    }
}
