using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDeathState : GoblinBaseState
{
    public GoblinDeathState(GoblinStateMachine currentContext, GoblinStateFactory goblinStateFactory)
    : base(currentContext, goblinStateFactory)
    {
        _isRootState = true;
        InitialiseSubState();
    }

    public override void EnterState()
    {
        _ctx.Animator.SetTrigger(_ctx.HitHash);
        _ctx.Animator.SetBool(_ctx.DeathHash, true);
    }

    public override void UpdateState()
    {
        
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

    }
}
