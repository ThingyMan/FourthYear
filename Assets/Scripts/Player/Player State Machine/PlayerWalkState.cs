using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    bool enterStateHandler = true;
    public PlayerWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {
        if (enterStateHandler)
        {
            enterStateHandler = false;
            InitialiseSubState();
        }
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void ExitState()
    {
        enterStateHandler = true;
    }

    public override void InitialiseSubState()
    {

    }

    public override void CheckSwitchStates()
    {
        if (_ctx.LetGoOfRoll == true && _ctx.IsGrounded == true)
        {
            if (_ctx.RollHoldAmount < _ctx._rollMaxCharge)
            {
                SwitchState(_factory.Rolling());
            }
            else
            {
                SwitchState(_factory.Teleport());
            }
        }
        else
        {
            _ctx.LetGoOfRoll = false;
        }
        if (_ctx.RollHoldAmount >= _ctx._rollMaxCharge)
        {
            _ctx.TeleportComplete = false;
            _ctx.LetGoOfRoll = false;
            SwitchState(_factory.Teleport());
        }

        if (_ctx.IsHeavyAttacking == true)
        {
            SwitchState(_factory.Charging());
        }

        if (_ctx.TiltingStick == false)
        {
            SwitchState(_factory.Idle());
        }
        else if (_ctx.TiltingStick == true && _ctx.Animator.GetFloat(_ctx.MoveSpeedHash) > 0.51f)
        {
            SwitchState(_factory.Run());
        }
    }
}
