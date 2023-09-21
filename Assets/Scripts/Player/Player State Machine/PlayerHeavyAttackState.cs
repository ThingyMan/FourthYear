using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeavyAttackState : PlayerBaseState
{
    bool enterStateHandler = true;
    public PlayerHeavyAttackState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {
        if (enterStateHandler)
        {
            enterStateHandler = false;
            _ctx.Animator.SetBool(_ctx.PressedHeavyHash, true);
            _ctx.IsCurrentlyHeavyAttacking = true;
            HandleAttack();
        }
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void ExitState()
    {
        enterStateHandler = true;
        _ctx.Animator.SetBool(_ctx.PressedHeavyHash, false);
    }

    public override void InitialiseSubState()
    {

    }

    public override void CheckSwitchStates()
    {
        if (_ctx.IsCurrentlyHeavyAttacking == false)
        {
            SwitchState(_factory.Idle());
        }
    }

    void HandleAttack()
    {
        _ctx.EnteredNewAttack = false;

        //if (_ctx.LightAttackCount < 5 && _ctx.CurrentAttackResetRoutine != null)
        //{
        //    _ctx.StopCoroutine(_ctx.CurrentAttackResetRoutine);
        //}

        _ctx.Animator.SetInteger(_ctx.HeavyAttackIDHash, _ctx.PlayerOver._swordHeavyAttacks[_ctx.NextHeavyAttackID]);
        _ctx.Animator.SetTrigger(_ctx.HeavyAttackHash);
    }
}
