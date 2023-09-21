using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    int _initialCount;
    bool wasHeavyPressed = false;
    bool idleCoroutineEnded = false;
    bool enterStateHandler = true;
    IEnumerator IAttackResetRoutine()
    {
        yield return new WaitForSeconds(.3f);
        _ctx.LightAttackCount = 0;
        idleCoroutineEnded = true;
    }

    public PlayerAttackState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {

        //if (_ctx.DoNotAttack == true)
        //{
        //    _ctx.DoNotAttack = false;
        //    idleCoroutineEnded = true;
        //}
        //else
        {
            if (enterStateHandler)
            {
                enterStateHandler = false;
                idleCoroutineEnded = false;
                _ctx.IsTeleporting = false;
                //reset heavy
                wasHeavyPressed = false;
                _ctx.WillEnterNewAttack = true;
                HandleAttack();
                _initialCount = _ctx.Animator.GetInteger(_ctx.LightAttackCount);
                InitialiseSubState();
            }
        }
    }

    public override void UpdateState()
    {


        if (_ctx.IsHeavyAttacking == true)
        {
            wasHeavyPressed = true;
        }

        CheckSwitchStates();

        if (_ctx.IsAttacking)
        {
            _ctx.IsAttacking = false;

            //if the player has entered a new attack and its not the last one in the combo
            if(_ctx.EnteredNewAttack == true && _ctx.LightAttackCount < 5)
            {
                //allow the player to attack again quickly
                HandleAttack();
                
            }
        }

        if(_ctx.GoToIdle == true)
        {
            _ctx.GoToIdle = false;
            _ctx.CurrentAttackResetRoutine = _ctx.StartCoroutine(IAttackResetRoutine());
        }
    }

    public override void ExitState()
    {
        wasHeavyPressed = false;
        enterStateHandler = true;
        idleCoroutineEnded = false;

        if(_ctx.LightAttackCount == 5)
        {
            _ctx.LightAttackCount = 0;
        }
        _ctx.CurrentAttackResetRoutine = _ctx.StartCoroutine(IAttackResetRoutine());

        _ctx.Animator.SetBool(_ctx.PressedHeavyHash, false);
        _ctx.Animator.ResetTrigger(_ctx.LightAttackHash);
    }

    public override void InitialiseSubState()
    {

    }

    public override void CheckSwitchStates()
    {
        if (wasHeavyPressed == true)
        {
            SwitchState(_factory.AttackH());
        }

        if (idleCoroutineEnded == true)
        {
            if(_ctx._titlingStick == false)
            {
                SwitchState(_factory.Idle());
            }
            else if(_ctx._titlingStick == true && _ctx.CurrentSpeed < 0.51f)
            {
                SwitchState(_factory.Walk());
            }
            else
            {
                SwitchState(_factory.Run());
            }
        }

        if (_ctx.RollHoldAmount >= _ctx._rollMaxCharge)
        {
            _ctx.TeleportComplete = false;
            _ctx.LetGoOfRoll = false;
            SwitchState(_factory.Teleport());
        }

        if (_ctx.DoNotAttack)
        {
            _ctx.DoNotAttack = false;
            SwitchState(_factory.Idle());
        }
    }

    void HandleAttack()
    {
        _ctx.StopCoroutine(IAttackResetRoutine());
        _ctx.EnteredNewAttack = false;
        _ctx.IsCurrentlyAttacking = true;

        if (_ctx.LightAttackCount < 5 && _ctx.CurrentAttackResetRoutine != null)
        {
            _ctx.StopCoroutine(_ctx.CurrentAttackResetRoutine);
        }

        _ctx.NextHeavyAttackID = _ctx.LightAttackCount;
        _ctx.Animator.SetTrigger(_ctx.LightAttackHash);

        if(_ctx.TeleportAttack == false)
        {
            _ctx.LightAttackCount += 1;
            _ctx.Animator.SetInteger(_ctx.LightAttackCountHash, _ctx.LightAttackCount);
        }
        _ctx.TeleportAttack = false;
    }
}
