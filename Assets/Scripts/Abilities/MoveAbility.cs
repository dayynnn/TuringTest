using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAbility : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed;

    [Header("References")]
    [SerializeField] private CharacterController controller;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Move(Vector3 moveDirection)
    {
        Vector3 forwardMovement = moveDirection.z * transform.forward;
        Vector3 sideMovement = moveDirection.x * transform.right;

        Vector3 movementVector = (forwardMovement + sideMovement);
        movementVector.y = 0;

        controller.Move((movementVector) * Time.deltaTime * moveSpeed);
    }


}
