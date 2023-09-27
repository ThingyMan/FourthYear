using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinFallState : GoblinBaseState
{
    public GoblinFallState(GoblinStateMachine currentContext, GoblinStateFactory goblinStateFactory)
    : base(currentContext, goblinStateFactory)
    {
        _isRootState = true;
        InitialiseSubState();
    }

    public override void EnterState()
    {
        _ctx.IsGrounded = false;
        _ctx.Animator.SetBool(_ctx.GroundedHash, false);
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
        SetSubState(_factory.Launched());
    }

    public override void CheckSwitchStates()
    {
        if (_ctx.enemyCol._enemyHealth <= 0)
        {
            SwitchState(_factory.Death());
        }
        if (_ctx.IsGrounded == true)
        {
            SwitchState(_factory.Grounded());
        }
    }
}
