using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwappingWeaponState : PlayerBaseState
{
    public PlayerSwappingWeaponState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {
        _ctx.Animator.SetBool(_ctx.SwitchWeaponHash, true);
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void ExitState()
    {

    }

    public override void InitialiseSubState()
    {

    }

    public override void CheckSwitchStates()
    {
        if(_ctx.WeaponSwitchOver == true)
        {
            _ctx.WeaponSwitchOver = false;
            SwitchState(_factory.Idle());
        }
    }
}
