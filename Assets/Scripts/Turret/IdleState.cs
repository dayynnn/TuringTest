using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class IdleState : ITurretState
{
    public void EnterState(LaserTurret turret)
    {
        turret.SetLaserActive(false);
    }

    public void UpdateState(LaserTurret turret)
    {
        if (turret.CanSeePlayer())
        {
            turret.ChangeState(new AttackState());
        }
    }
}
