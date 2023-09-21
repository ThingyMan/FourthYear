using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollState : PlayerBaseState
{
    IEnumerator IRollResetRoutine()
    {
        yield return new WaitForSeconds(.2f);
        _ctx.LetGoOfRollChecker = true;
        _ctx.CanRoll = true;
    }
    public PlayerRollState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {
        _ctx.LetGoOfRollChecker = false;
        _ctx.RollHoldAmount = 0;
        _ctx.LetGoOfRoll = false;
        HandleRoll();
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void ExitState()
    {
        _ctx.Animator.ResetTrigger(_ctx.RollHash);
        _ctx.RollResetRoutine = _ctx.StartCoroutine(IRollResetRoutine());
    }

    public override void InitialiseSubState()
    {

    }

    public override void CheckSwitchStates()
    {
        if(_ctx.RollComplete == true)
        {
            _ctx.RollComplete = false;
            _ctx.RollResetRoutine = _ctx.StartCoroutine(IRollResetRoutine());
            SwitchState(_factory.Idle());
        }
        //if (_ctx.move.ReadValue<Vector2>().sqrMagnitude > 0.01f && direction.sqrMagnitude > 0.01f)
        //{
        //    this._ctx.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        //}
    }

    public void HandleRoll()
    {
        _ctx.Animator.SetTrigger(_ctx.RollHash);
        _ctx.forceDirection += _ctx.ForwardDireciton * _ctx.rollForce;
    }
}
