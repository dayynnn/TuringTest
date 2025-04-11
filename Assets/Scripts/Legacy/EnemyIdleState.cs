using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public int _currTarget = 0;

    //constructor
    public EnemyIdleState(EnemyController enemy) : base(enemy)
    {
        //uses the base constructor from EnemyState.
        //anything below here is added on after.
    }

    public override void OnStateEnter()
    {
        _enemy._agent.destination = _enemy._targetPoints[_currTarget].position;
        Debug.Log("Enemy Idle Enter!!!");
        
    }
    public override void OnStateExit()
    {
        Debug.Log("Enemy Idle Exiting!!!");
    }

    public override void OnStateUpdate()
    {
        // choose a random targetpoint and move there.
        if (_enemy._agent.remainingDistance < 0.1f)
        {
            _currTarget++;
            if (_currTarget >= _enemy._targetPoints.Length) _currTarget = 0;
            _enemy._agent.destination = _enemy._targetPoints[_currTarget].position;
        }

        //check for player
        if (Physics.SphereCast(_enemy._enemyEye.position, _enemy._checkRadius, _enemy.transform.forward, out RaycastHit hit, _enemy._playerCheckDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player Found!");

                _enemy._player = hit.transform;
                _enemy._agent.destination = _enemy._player.position;

                //Move to follow state
                _enemy.ChangeState(new EnemyFollowState(_enemy));
            }
        }
    }
}
