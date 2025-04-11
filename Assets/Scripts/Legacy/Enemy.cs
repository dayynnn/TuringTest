using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private Transform _enemy;
    [SerializeField] private float _playerCheckDistance;
    [SerializeField] private float _checkRadius = 0.4f;

    int _currTarget = 0;
    private NavMeshAgent _agent;

    public bool isIdle = true;
    public bool isPlayerFound;
    public bool isCloseToPlayer;

    public Transform _player;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        // Tell agent where the first point is.
        _agent.destination = _targetPoints[_currTarget].position;
    }

    private void Update()
    {
        if (isIdle)
        {
            Idle();
        }else if (isPlayerFound)
        {
            if (isCloseToPlayer)
            {
                AttackPlayer();
            }
            else
            {
                FollowPlayer();
            }
        }
    }

    void Idle()
    {
        // this'll choose the next destination in the array 
        if (_agent.remainingDistance < 0.1f)
        {
            _currTarget++;
            if(_currTarget >= _targetPoints.Length)
            {
                _currTarget = 0;
                _agent.destination = _targetPoints[_currTarget].position;
            }
        }
        //check for the player
        if (Physics.SphereCast(_enemy.position, _checkRadius, transform.forward, out RaycastHit hit, _playerCheckDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player found");
                isIdle = false;
                isPlayerFound = true;
                _player = hit.transform;
                _agent.destination = _player.position;
            }
        }
    }

    void FollowPlayer()
    {
        if (_player != null)
        {
            //check distance, if within threshold, then follow or attack
            // if player 10 units away, dont follow/attack.
            if (Vector3.Distance(transform.position, _player.position) > 10) 
            {
                isPlayerFound = false;
                isIdle = true;
            }

            if (Vector3.Distance(transform.position, _player.position) < 2)
            {
                isCloseToPlayer = true;
            }
            else
            {
                isCloseToPlayer = false;
            }

            _agent.destination = _player.position;  
        }
        else
        {
            isPlayerFound = false;
            isIdle = true;
            isCloseToPlayer = false; 
        }
    }

    void AttackPlayer()
    {
        if (_player != null)
        {
            Debug.Log("Attacking!!!!!!!!");
            if (Vector3.Distance(transform.position, _player.position) > 2)
            {
                isCloseToPlayer = false;
            }
        }
        else
        {
            Debug.Log("No player found in game.");
        }
    }
}
