using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportState : PlayerBaseState
{
    IEnumerator ITeleportResetRoutine()
    {
        yield return new WaitForSeconds(.5f);
        _ctx.LetGoOfRollChecker = true;
        _ctx.CanRoll = true;
    }
    public PlayerTeleportState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {
        _ctx.LetGoOfRollChecker = false;
        _ctx.RollHoldAmount = 0;
        _ctx.LetGoOfRoll = false;
        HandleTeleport();
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void ExitState()
    {
        _ctx.TeleportComplete = true;
        _ctx.Animator.ResetTrigger(_ctx.TeleportHash);
        _ctx.TeleportResetRoutine = _ctx.StartCoroutine(ITeleportResetRoutine());
        _ctx.IsTeleporting = false;
    }

    public override void InitialiseSubState()
    {

    }

    public override void CheckSwitchStates()
    {
        if (_ctx.IsAttacking == true)
        {
            _ctx.TeleportResetRoutine = _ctx.StartCoroutine(ITeleportResetRoutine());
            _ctx.TeleportAttack = true;
            SwitchState(_factory.AttackL());
        }

        if (_ctx.TeleportComplete == true)
        {
            _ctx.TeleportComplete = false;
            //Debug.Log("HELLO FUCKER :)");
            SwitchState(_factory.Idle());
        }
    }

    public void HandleTeleport()
    {
        _ctx.Animator.SetTrigger(_ctx.TeleportHash);
    }
}
