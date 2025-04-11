using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurretState
{
    void EnterState(LaserTurret turret);
    void UpdateState(LaserTurret turret);
}

