using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAbility : MonoBehaviour
{

    [Header("Shooting Settings")]
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private float shootingForce;

    ObjectPooling objectPoolingCache;

    // Start is called before the first frame update
    private void Awake()
    {
        objectPoolingCache = FindObjectOfType<ObjectPooling>();
    }

    public void Shoot()
    {
        if (objectPoolingCache == null) return;

        Rigidbody clonedRb = objectPoolingCache.RetrieveAvailableBullet().GetRigidBody();
        if(clonedRb == null) return;
        clonedRb.position = weaponTip.position;
        clonedRb.rotation = weaponTip.rotation;

        //Instantiate(projectilePrefab, weaponTip.position, weaponTip.rotation);
        clonedRb.AddForce(weaponTip.forward * shootingForce);
    }
}
