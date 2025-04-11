using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private bool lockDoorAfterExit;

    public GameObject door;
    public float timer;

    private void OnTriggerEnter(Collider other)
    {
        //Change door color (vfx)
    }

    private void OnTriggerStay(Collider other)
    {
        /*
         
        timer += Time.deltaTime;
        if(timer >= 1){door.SetActive(false);}
        
         * */
        //detect every frame im in front of the door
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            door.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (lockDoorAfterExit)
        {
            door.SetActive(true);
        }
        timer = 0;
    }

}
