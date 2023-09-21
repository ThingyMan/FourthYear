public class PlayerStateFactory
{
    PlayerStateMachine _context;

    public PlayerStateFactory(PlayerStateMachine currentContext)
    {
        _context = currentContext;
    }
    public PlayerBaseState Grounded()
    {
        return new PlayerGroundedState(_context, this);
    }
    public PlayerBaseState Idle() { 
        return new PlayerIdleState(_context, this);
    }
    public PlayerBaseState Rolling()
    {
        return new PlayerRollState(_context, this);
    }
    public PlayerBaseState Walk() {
        return new PlayerWalkState(_context, this);
    }
    public PlayerBaseState Run() {
        return new PlayerRunState(_context, this);
    }
    public PlayerBaseState AttackL() {
        return new PlayerAttackState(_context, this);
    }
    public PlayerBaseState AttackH()
    {
        return new PlayerHeavyAttackState(_context, this);
    }
    public PlayerBaseState Charging()
    {
        return new PlayerChargeState(_context, this);
    }

    public PlayerBaseState SwappingWeapon()
    {
        return new PlayerSwappingWeaponState(_context, this);
    }

    public PlayerBaseState Falling()
    {
        return new PlayerFallState(_context, this);
    }

    public PlayerBaseState Teleport()
    {
        return new PlayerTeleportState(_context, this);
    }

}
