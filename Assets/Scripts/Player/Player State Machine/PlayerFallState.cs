using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    IEnumerator IRollResetRoutine()
    {
        yield return new WaitForSeconds(.2f);
        _ctx.LetGoOfRollChecker = true;
        _ctx.CanRoll = true;
    }

    public PlayerFallState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) 
    {
        _isRootState = true;
        InitialiseSubState();
        _ctx.RollResetRoutine = _ctx.StartCoroutine(IRollResetRoutine());
    }
    public override void EnterState()
    {
        _ctx.Animator.SetBool(_ctx.IsGroundedHash, false);
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
        //if (_ctx.IsCurrentlyAttacking == false && _ctx.IsCurrentlyHeavyAttacking == false)
        {
            if (_ctx.TiltingStick == false)
            {
                SetSubState(_factory.Idle());
            }
            else if (_ctx.TiltingStick == true && _ctx.CurrentSpeed < 0.51f)
            {
                SetSubState(_factory.Walk());
            }
            else
            {
                SetSubState(_factory.Run());
            }
        }
        //if (_ctx.TeleportAttack == true)
        //{
        //    _ctx.DoNotAttack = true;
        //    SwitchState(_factory.AttackL());
        //}
    }

    public override void CheckSwitchStates()
    {
        if (_ctx.IsGrounded == true)
        {
            SwitchState(_factory.Grounded());
        }
    }
}
