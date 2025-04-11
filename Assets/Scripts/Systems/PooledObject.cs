using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    [SerializeField] private float timeToReset = 15f;
    [SerializeField] private float currTimer = 0;

    [SerializeField] private Rigidbody bulletRb;

    private ObjectPooling linkedPool;

    public void LinkToPool(ObjectPooling pool)
    {
        linkedPool = pool;    
    }

    private void OnEnable()
    {
        currTimer = 0;
    }

    private void Update()
    {
        if (currTimer < timeToReset)
        {
            currTimer += Time.deltaTime;
        }
        else
        {
            bulletRb.velocity = Vector3.zero;
            linkedPool.ResetBullet(this);
        }
    }

    public Rigidbody GetRigidBody()
    {
        return bulletRb;
    }
}
