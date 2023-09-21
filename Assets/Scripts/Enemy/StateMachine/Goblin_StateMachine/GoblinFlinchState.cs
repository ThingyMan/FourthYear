using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinFlinchState : GoblinBaseState
{
    public GoblinFlinchState(GoblinStateMachine currentContext, GoblinStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory)
    {

    }

    public override void EnterState()
    {
        _ctx.Animator.SetTrigger(_ctx.FlinchHash);
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void ExitState()
    {
        _ctx.Animator.ResetTrigger(_ctx.FlinchHash);
    }

    public override void InitialiseSubState()
    {

    }

    public override void CheckSwitchStates()
    {
        if (_ctx.IsGrounded)
        {
            SwitchState(_factory.Idle());
        }
    }
}
