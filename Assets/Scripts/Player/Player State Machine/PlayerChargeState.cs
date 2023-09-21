using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargeState : PlayerBaseState
{
    float chargeAmount = 0f;
    float chargeRate = 0.005f;

    public PlayerChargeState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {
        _ctx.Animator.SetBool(_ctx.IsChargingHash, true);
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
        

        if(_ctx.IsHeavyAttacking == true)
        {
            ChargeFunction();
        }
        else
        {
            _ctx.Animator.SetBool(_ctx.IsChargingHash, false);
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
        if(_ctx.IsCharging == false)
        {

        }
    }

    void ChargeFunction()
    {
        chargeAmount += chargeRate;
        _ctx.Animator.SetFloat(_ctx.ChargeLevel, chargeAmount);
    }
}
