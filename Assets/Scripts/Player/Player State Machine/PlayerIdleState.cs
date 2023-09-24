using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    bool switchWeapon = false;
    IEnumerator IRollResetRoutine()
    {
        yield return new WaitForSeconds(.2f);
        _ctx.LetGoOfRollChecker = true;
        _ctx.CanRoll = true;
    }
    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) {
    }
    public override void EnterState()
    {
        switchWeapon = false;
        InitialiseSubState();
        if(_ctx.IsGrounded == true)
        {
            _ctx.RollResetRoutine = _ctx.StartCoroutine(IRollResetRoutine());
        }
    }

    public override void UpdateState()
    {
        CheckSwitchStates();

        if(_ctx.IsSwithcingWeaponUp == true)
        {
            SwitchWeaponUp();
        }
        if(_ctx.IsSwithcingWeaponDown == true)
        {
            SwitchWeaponDown();
        }
    }

    public override void ExitState()
    {

    }

    public override void InitialiseSubState()
    {

    }

    public override void CheckSwitchStates()
    {
        if(switchWeapon == true)
        {
            switchWeapon = false;
            SwitchState(_factory.SwappingWeapon());
        }

        if(_ctx.LetGoOfRoll == true && _ctx.IsGrounded == true)
        {
            if(_ctx.RollHoldAmount < _ctx._rollMaxCharge)
            {
                SwitchState(_factory.Rolling());
            }
            else
            {
                SwitchState(_factory.Teleport());
            }
        }
        else
        {
            _ctx.LetGoOfRoll = false;
        }
        if(_ctx.RollHoldAmount >= _ctx._rollMaxCharge)
        {
            _ctx.TeleportComplete = false;
            _ctx.LetGoOfRoll = false;
            SwitchState(_factory.Teleport());
        }

        if (_ctx.IsAttacking == true && _ctx.TeleportComplete == true/* || _ctx.IsCurrentlyAttacking == true*/)
        {
            SwitchState(_factory.AttackL());
        }
        //if(_ctx.IsHeavyAttacking == true)
        //{
        //    SwitchState(_factory.Charging());
        //}

        if (_ctx.TiltingStick == true && _ctx.IsAttacking == false)
        {
            if(_ctx.CurrentSpeed < 0.51f)
            {
                SwitchState(_factory.Walk());
            }
            else
            {
                SwitchState(_factory.Run());
            }
        }
    }

    void SwitchWeaponUp()
    {
        if (_ctx.IsSwithcingWeaponUp)
        {
            if (_ctx.CurrentWeapon == _ctx.MaxWeaponID - 1)
            {
                _ctx.CurrentWeapon = 0;
            }
            else
            {
                _ctx.CurrentWeapon++;
            }
            switchWeapon = true;
        }
    }

    void SwitchWeaponDown()
    {
        if (_ctx.IsSwithcingWeaponDown)
        {
            if (_ctx.CurrentWeapon == 0)
            {
                _ctx.CurrentWeapon = _ctx.MaxWeaponID;
            }
            else
            {
                _ctx.CurrentWeapon--;
            }
            switchWeapon = true;
        }
    }
}
