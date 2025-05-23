using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private PooledObject bulletPrefab;
    [SerializeField] private int amountOfClones = 20;
    [SerializeField] private List<PooledObject> availableBullets;
    [SerializeField] private List<PooledObject> unavailableBullets;


    // Start is called before the first frame update
    void Start()
    {
        int currAmountOfClones = 0;
        while(currAmountOfClones < amountOfClones)
        {
            AddElementToPool();

            currAmountOfClones++;
        }    
    }

    void AddElementToPool() 
    {
        PooledObject clone = Instantiate(bulletPrefab);
        clone.LinkToPool(this);
        clone.gameObject.SetActive(false);
        clone.transform.SetParent(transform);
        availableBullets.Add(clone);
    }

    public PooledObject RetrieveAvailableBullet()
    {
        if(availableBullets.Count == 0)
        {
            AddElementToPool();
        }

        PooledObject firstAvailable = availableBullets[0];
        availableBullets.RemoveAt(0);
        unavailableBullets.Add(firstAvailable);
        
        firstAvailable.gameObject.SetActive(true);

        return firstAvailable;
    }

    //experimental way to reset bullets
    public void ResetBullet(PooledObject bulletToReset)
    {
        unavailableBullets.Remove(bulletToReset);
        availableBullets.Add(bulletToReset);

        bulletToReset.GetRigidBody().velocity = Vector3.zero;

        bulletToReset.gameObject.SetActive(false);

    }

}
