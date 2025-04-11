using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LookAbility : MonoBehaviour
{
    [SerializeField] private Transform _head;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Look(Vector3 lookDirection)
    {

        _head.transform.localRotation = Quaternion.Euler(-lookDirection.y, 0, 0);
        transform.rotation = Quaternion.Euler(0, lookDirection.x, 0);

    }
}
