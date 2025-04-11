using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackState : ITurretState
{
    public void EnterState(LaserTurret turret)
    {
        turret.SetLaserActive(true);
    }

    public void UpdateState(LaserTurret turret)
    {
        if (!turret.CanSeePlayer())
        {
            turret.ChangeState(new IdleState());
        }
        else
        {
            turret.FireLaser();
        }
    }
}
