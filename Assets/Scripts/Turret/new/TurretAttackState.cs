using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackState : TurretState
{
    public TurretAttackState(TurretController turret) : base(turret) { }
    
    public override void OnStateEnter()
    {
        Debug.Log("Entering Attacking State");

        _turret.StartFiring();
    }

    public override void OnStateExit()
    {
        _turret.StopFiring();
    }

    public override void OnStateUpdate()
    {
        if (!_turret.CanSeePlayer())
        {
            Debug.Log("Lost sight of player. Returning to idle.");
            _turret.ChangeState(new TurretIdleState(_turret));
        }
    }
}
