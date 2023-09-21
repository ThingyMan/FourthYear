using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) {
        _isRootState = true;
        InitialiseSubState();
    }

    public float maxSpeed = 5f;

    public override void EnterState()
    {
        _ctx.IsGrounded = true;
        _ctx.Animator.SetBool(_ctx.IsGroundedHash, true);
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
        CalculateSpeed();
    }

    public void CalculateSpeed()
    {
        _ctx.Animator.SetFloat(_ctx.MoveSpeedHash, _ctx.CurrentSpeed);
    }

    public override void ExitState()
    {

    }

    public override void InitialiseSubState()
    {
        //if(_ctx.IsCurrentlyAttacking == false && _ctx.IsCurrentlyHeavyAttacking == false)
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
        //if (_ctx.IsAttacking == true)
        //{
        //    if (_ctx.IsLightAttacking == true)
        //    {
        //        SetSubState(_factory.AttackL());
        //    }
        //    else if (_ctx.IsHeavyAttacking == true)
        //    {
        //        SetSubState(_factory.Charging());
        //    }
        //}
    }

    public override void CheckSwitchStates()
    {
        if(_ctx.IsGrounded == false && _ctx.IsTeleporting == false)
        {
            SwitchState(_factory.Falling());
        }

    }
}
