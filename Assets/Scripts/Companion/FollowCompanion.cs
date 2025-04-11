using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowCompanion : MonoBehaviour
{
    private NavMeshAgent _agent;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _playerInput = FindObjectOfType<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = _playerInput.gameObject.transform.position;
    }
}
