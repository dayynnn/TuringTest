using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityAbility : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private CharacterController controller;
    private const float gravityAcceleration = -9.81f;
    private float currentGravity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsOnGround())
        {
            currentGravity += gravityAcceleration * Time.deltaTime;
        }
        else if(currentGravity < 0) 
        {
            currentGravity = 0f;  
        }

        Vector3 gravityVec = new Vector3();
        gravityVec.y = currentGravity;
        controller.Move(gravityVec * Time.deltaTime);
    }

    public bool IsOnGround()
    {
        return Physics.CheckSphere(transform.position, 0.1f, groundLayer);

    }

    public void AddForce(Vector3 force)
    {
        currentGravity = force.y;
    }
}
