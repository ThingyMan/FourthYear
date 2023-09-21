using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinLaunchedState : GoblinBaseState
{
    public GoblinLaunchedState(GoblinStateMachine currentContext, GoblinStateFactory goblinStateFactory)
    : base(currentContext, goblinStateFactory)
    {

    }

    public override void EnterState()
    {
        _ctx.Animator.SetTrigger(_ctx.HitHash);
        //_ctx.Animator.ResetTrigger(_ctx.HitHash);
        _ctx.Animator.SetBool(_ctx.LaunchedHash, true);
        _ctx.enemyCol.wasLaunched = false;
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
        if (_ctx.IsGrounded && _ctx.HasLanded == true)
        {
            SwitchState(_factory.Idle());
        }
    }
}
