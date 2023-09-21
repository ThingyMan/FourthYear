public class EnemyStateFactory
{
    EnemyStateMachine _context;

    public EnemyStateFactory(EnemyStateMachine currentContext)
    {
        _context = currentContext;
    }
    //public EnemyBaseState Grounded()
    //{
    //    return new PlayerGroundedState(_context, this);
    //}
    //public EnemyBaseState Idle()
    //{
    //    return new PlayerIdleState(_context, this);
    //}
    //public EnemyBaseState Rolling()
    //{
    //    return new PlayerRollState(_context, this);
    //}
    //public EnemyBaseState Walk()
    //{
    //    return new PlayerWalkState(_context, this);
    //}
    //public EnemyBaseState Run()
    //{
    //    return new PlayerRunState(_context, this);
    //}
    //public EnemyBaseState AttackL()
    //{
    //    return new PlayerAttackState(_context, this);
    //}
    //public EnemyBaseState AttackH()
    //{
    //    return new PlayerHeavyAttackState(_context, this);
    //}
    //public EnemyBaseState Charging()
    //{
    //    return new PlayerChargeState(_context, this);
    //}

    //public EnemyBaseState SwappingWeapon()
    //{
    //    return new PlayerSwappingWeaponState(_context, this);
    //}

    //public EnemyBaseState Falling()
    //{
    //    return new PlayerFallState(_context, this);
    //}

    //public EnemyBaseState Teleport()
    //{
    //    return new PlayerTeleportState(_context, this);
    //}

}
