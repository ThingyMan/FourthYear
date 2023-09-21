using UnityEngine;

public abstract class GoblinBaseState
{
    protected bool _isRootState = false;
    protected GoblinStateMachine _ctx;
    protected GoblinStateFactory _factory;
    public GoblinBaseState _currentSubState;
    public GoblinBaseState _currentSuperState;
    public GoblinBaseState(GoblinStateMachine currentContext, GoblinStateFactory goblinStateFactory)
    {
        _ctx = currentContext;
        _factory = goblinStateFactory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();
    public abstract void InitialiseSubState();

    protected void SwitchState(GoblinBaseState newState)
    {
        // current state exits state
        ExitState();

        // new state enters state
        newState.EnterState();

        if (_isRootState)
        {
            // switch current state of context
            _ctx.CurrentState = newState;
        }
        else if (_currentSuperState != null)
        {
            // set the current super states sub state to the new state
            _currentSuperState.SetSubState(newState);
        }
    }

    public void UpdateStates()
    {
        UpdateState();
        if(_currentSubState != null)
        {
            _currentSubState.UpdateStates();
        }
    }

    protected void SetSuperState(GoblinBaseState newSuperState)
    {
        _currentSuperState = newSuperState;
    }

    protected void SetSubState(GoblinBaseState newSubState)
    {
        _currentSubState = newSubState;
        newSubState.SetSuperState(this);

        //uncomment if subState isnt doing EnterState(); but doing so can also make it do EnterState(); twice
        newSubState.EnterState();
    }
}
