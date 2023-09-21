using UnityEngine;

public class EnemyBaseState
{
    //protected bool _isRootState = false;
    //protected EnemyStateMachine _ctx;
    //protected EnemyStateMachine _factory;
    //public EnemyBaseState _currentSubState;
    //public EnemyBaseState _currentSuperState;
    //public EnemyBaseState(EnemyStateMachine currentContext, EnemyStateFactory enemyStateFactory)
    //{
    //    _ctx = currentContext;
    //    _factory = enemyStateFactory;
    //}

    //public abstract void EnterState();
    //public abstract void UpdateState();
    //public abstract void ExitState();
    //public abstract void CheckSwitchStates();
    //public abstract void InitialiseSubState();

    //protected void SwitchState(EnemyBaseState newState)
    //{
    //    // current state exits state
    //    ExitState();

    //    // new state enters state
    //    newState.EnterState();

    //    if (_isRootState)
    //    {
    //        // switch current state of context
    //        _ctx.CurrentState = newState;
    //    }
    //    else if (_currentSuperState != null)
    //    {
    //        // set the current super states sub state to the new state
    //        _currentSuperState.SetSubState(newState);
    //    }
    //}

    //public void UpdateStates()
    //{
    //    UpdateState();
    //    if (_currentSubState != null)
    //    {
    //        _currentSubState.UpdateStates();
    //    }
    //}

    //protected void SetSuperState(EnemyBaseState newSuperState)
    //{
    //    _currentSuperState = newSuperState;
    //}

    //protected void SetSubState(EnemyBaseState newSubState)
    //{
    //    _currentSubState = newSubState;
    //    newSubState.SetSuperState(this);

    //    //uncomment if subState isnt doing EnterState(); but doing so can also make it do EnterState(); twice
    //    newSubState.EnterState();
    //}
}
