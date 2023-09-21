using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinGroundedState : GoblinBaseState
{
    public GoblinGroundedState(GoblinStateMachine currentContext, GoblinStateFactory goblinStateFactory)
    : base(currentContext, goblinStateFactory)
    {
        _isRootState = true;
        InitialiseSubState();
    }

    public override void EnterState()
    {
        _ctx.Animator.SetBool(_ctx.GroundedHash, true);
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
        SetSubState(_factory.Idle());
    }

    public override void CheckSwitchStates()
    {
        if(_ctx.IsGrounded == false)
        {
            SwitchState(_factory.Fall());
        }
    }

}
