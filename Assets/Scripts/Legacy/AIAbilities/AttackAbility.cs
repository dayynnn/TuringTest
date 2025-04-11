using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///This ability is specific for AI characters which can attack the player in different ways.
///</summary>
public class AttackAbility : MonoBehaviour
{
    [SerializeField] private float _damageToGive;
    [SerializeField] private float _attackCooldown;

    private bool _isAttacking;
    public float _attackTimer;
    private HealthSystem _targetToAttack;

    private void Update()
    {
        if(_isAttacking)
        {
            //Start timer
                //after timer:
                    //attack
                        //reset timer
            Debug.Log("Timer Start Check");
            _attackTimer += Time.deltaTime;
            if (_attackTimer >= _attackCooldown) 
            {
                Attack();
                _attackTimer = 0;
            }
        }
    }

    public void StartAttack(Transform target)
    {
        _targetToAttack = target.GetComponent<HealthSystem>();
        Debug.Log("Started Attacking with another script");
        _isAttacking = true;
    }
    public void Attack()
    {
        // Deal damage to target
        if (_targetToAttack)
        {
            _targetToAttack.DecreaseHealth(_damageToGive);
        }
    }
    public void StopAttack()
    {
        Debug.Log("Stopped Attacking with another script");
        _isAttacking = false;
    }

}
