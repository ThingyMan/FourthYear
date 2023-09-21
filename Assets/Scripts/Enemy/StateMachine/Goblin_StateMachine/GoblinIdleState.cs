using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinIdleState : GoblinBaseState
{
    public GoblinIdleState(GoblinStateMachine currentContext, GoblinStateFactory goblinStateFactory)
    : base(currentContext, goblinStateFactory)
    {

    }

    public override void EnterState()
    {
        _ctx.Animator.SetBool(_ctx.LaunchedHash, false);
        _ctx.Animator.ResetTrigger(_ctx.HitHash);
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void ExitState()
    {

    }

    public override void CheckSwitchStates()
    {

        if (_ctx.enemyCol.wasHit == true)
        {
            _ctx.enemyCol.wasHit = false;

            if (_ctx.enemyCol.wasLaunched == true && _ctx.enemyCol.canBeLaunched == true)
            {
                _ctx.HasLanded = false;
                SwitchState(_factory.Launched());
            }
            
            if(_ctx.enemyCol.canBeFlinched == true)
            {
                SwitchState(_factory.Flinch());
            }


        }
    }

    public override void InitialiseSubState()
    {

    }



}
