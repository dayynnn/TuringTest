using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAbility : MonoBehaviour
{
    public LineRenderer laserRenderer;
    public Transform weaponTip;
    public float laserDistance = 15f;
    public float laserDamage = 1;
    public LayerMask obstacleMask;

    private bool isFiring;

    private float nextDamageTime = 0f;
    [SerializeField] private float damageCooldown = 2f; // 2 seconds cooldown

void Start()
    {
        laserRenderer.enabled = false;
    }

    void Update()
    {
        if (isFiring)
        {
            //StartFiring();
            FireLaser();
            
        }
    }

    public void Firing(Transform target)
    {
        isFiring = true;
        laserRenderer.enabled = true;
        Debug.Log("Laser firing at: " + target.name);
    }

    public void NotFiring()
    {
        isFiring = false;
        laserRenderer.enabled = false;
    }

    private void FireLaser()
    {
        if (!weaponTip) return;

        RaycastHit hit;
        Vector3 direction = weaponTip.forward;
        if (Physics.Raycast(weaponTip.position, direction, out hit, laserDistance, obstacleMask))
        {
            laserRenderer.SetPosition(0, weaponTip.position);
            laserRenderer.SetPosition(1, hit.point);

            if (hit.collider.CompareTag("Player"))
            {
                if (Time.time >= nextDamageTime)
                {
                    hit.collider.GetComponent<HealthSystem>()?.DecreaseHealth(laserDamage);
                    nextDamageTime = Time.time + damageCooldown; // Set the next allowed damage time
                }
            }
        }
        else
        {
            laserRenderer.SetPosition(0, weaponTip.position);
            laserRenderer.SetPosition(1, weaponTip.position + direction * laserDistance);
        }
        Debug.DrawRay(weaponTip.position, direction * laserDistance, Color.red);
    }
}
