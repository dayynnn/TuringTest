using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretIdleState : TurretState
{
    public TurretIdleState(TurretController turret) : base(turret) { }

    public override void OnStateEnter()
    {
        _turret.StopFiring();
    }

    public override void OnStateExit()
    {
        Debug.Log("Turret exiting idle state.");
    }

    public override void OnStateUpdate()
    {
        if (_turret.CanSeePlayer())
        {
            Debug.Log("Player detected! Switching to attack mode.");
            _turret.ChangeState(new TurretAttackState(_turret));
        }
    }
}
