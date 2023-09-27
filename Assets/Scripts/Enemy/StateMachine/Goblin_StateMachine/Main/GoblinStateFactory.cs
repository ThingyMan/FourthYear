using UnityEngine.UIElements;

public class GoblinStateFactory
{
    GoblinStateMachine _context;

    public GoblinStateFactory(GoblinStateMachine currentContext)
    {
        _context = currentContext;
    }

    public GoblinBaseState Death()
    {
        return new GoblinDeathState(_context, this);
    }
    public GoblinBaseState Grounded()
    {
        return new GoblinGroundedState(_context, this);
    }

    public GoblinBaseState Fall()
    {
        return new GoblinFallState(_context, this);
    }

    public GoblinBaseState Launched()
    {
        return new GoblinLaunchedState(_context, this);
    }

    public GoblinBaseState Flinch()
    {
        return new GoblinFlinchState(_context, this);
    }

    public GoblinBaseState Idle()
    {
        return new GoblinIdleState(_context, this);
    }


}
