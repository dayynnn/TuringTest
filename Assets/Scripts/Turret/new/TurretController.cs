using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private TurretState _currState;

    public Transform weaponTip;
    public Transform player;
    public float detectionRange = 15f;
    public LayerMask obstacleMask;

    private LaserAbility _laserAbility;

    [SerializeField] private Transform head;

    private void Awake()
    {
        _laserAbility = GetComponent<LaserAbility>();
        _currState = new TurretIdleState(this);
    }

    void Start()
    {
        _currState.OnStateEnter();
    }

    void Update()
    {
        if (CanSeePlayer()) 
        { 
            head.LookAt(player);
        }
        _currState.OnStateUpdate();
    }

    public void ChangeState(TurretState state)
    {
        _currState.OnStateExit();
        _currState = state;
        _currState.OnStateEnter();
    }

    public bool CanSeePlayer()
    {
        if (!player || !weaponTip)
        {
            Debug.Log("Player or Weapontip is not assigned.");
            return false;
        }
        //player.position += Vector3.up * 1f;
        Vector3 direction = (player.position - weaponTip.position).normalized;
        Ray ray = new Ray(weaponTip.position, direction);

        if (Physics.Raycast(weaponTip.position, direction, out RaycastHit hit, detectionRange, obstacleMask))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
            Debug.Log("Raycast Hit: " + hit.collider.name);
            return hit.collider.CompareTag("Player");
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            Debug.Log("Raycast did not hit anything.");
            return false;
        }
    }

    public void StartFiring()
    {
        _laserAbility.Firing(player);
    }

    public void StopFiring()
    {
        _laserAbility.NotFiring();
    }
}
