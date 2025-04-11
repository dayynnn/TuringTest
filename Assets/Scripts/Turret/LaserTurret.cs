using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LaserTurret : MonoBehaviour
{
    [Header("Turret Settings")]
    public float maxLaserDistance = 20f;
    public int laserDamage = 20;
    public LayerMask obstacleMask;
    public float _checkRadius;

    [Header("References")]
    //public Transform weaponTip;  // Where the laser starts from
    public Transform player;
    public LineRenderer laser;

    [Header("Turret Checks")]
    public bool isIdle = true;
    public bool isPlayerFound;
    


    //private ITurretState currentState;

    void Start()
    {
        laser.enabled = false;  // Hide laser initially
        //ChangeState(new IdleState());
    }

    void Update()
    {
        if (isIdle)
        {
            Idle();
            //currentState.UpdateState(this);
        }   
        else if (isPlayerFound)
        {
            FireLaser();
        }
    }

   public void ChangeState(ITurretState newState)
    {
        //currentState = newState;
        //currentState.EnterState(this);
    }

    public bool CanSeePlayer()
    {
        if (!player || !transform) return false;
        
        RaycastHit hit;
        Vector3 direction = (player.position - transform.position).normalized + transform.forward;
        laser.enabled = true;

        if (Physics.Raycast(transform.position, direction, out hit, maxLaserDistance, obstacleMask))
        {
            laser.SetPosition(1, hit.point);
            return hit.collider.CompareTag("Player");
        }
        else
        {
            laser.SetPosition(1, transform.position + (transform.forward * maxLaserDistance));
        }
        Debug.DrawRay(transform.position, direction * maxLaserDistance, Color.red);
        return false;
    }

    void AttackPlayer()
    {
        if (player != null)
        {
            Debug.Log("Attacking!!!!!!!!");
            if (Vector3.Distance(transform.position, player.position) > 2)
            {
               // isCloseToPlayer = false;
            }
        }
        else
        {
            Debug.Log("No player found in game.");
        }
    }
    public void FireLaser()
    {

        RaycastHit hit;
        laser.enabled = true;
        if (!player)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            if (Physics.Raycast(transform.position, direction, out hit, maxLaserDistance, obstacleMask))
            {
                //DrawLaser(transform.position, hit.point);
                if (hit.collider.CompareTag("Player"))
                {
                    laser.SetPosition(1, hit.point);
                    hit.collider.GetComponent<HealthSystem>()?.DecreaseHealth(laserDamage);
                }
            }
            else
            {
                laser.SetPosition(1, transform.position + (transform.forward * maxLaserDistance));
                //DrawLaser(transform.position, transform.position + direction * maxLaserDistance);
            }
        }

    }

    public void SetLaserActive(bool active)
    {
        laser.enabled = active;
    }

    /*private void DrawLaser(Vector3 start, Vector3 end)
    {
        laser.SetPosition(0, start);
        laser.SetPosition(1, end);
    }*/

    void Idle()
    {
       //check for the player
        if (Physics.SphereCast(player.position, _checkRadius, transform.forward, out RaycastHit hit, maxLaserDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player found");
                isIdle = false;
                isPlayerFound = true;
                player = hit.transform;
            }
        }
    }

   

}
