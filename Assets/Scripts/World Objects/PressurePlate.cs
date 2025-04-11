using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour, IPuzzlePiece
{
    [SerializeField] private bool unlockWithAnyObject;
    [SerializeField] private Rigidbody[] correctRigidbodies;
    [SerializeField] private Animator anim;

    public UnityEvent OnPressureStart = new UnityEvent();
    public UnityEvent OnPressureEnd = new UnityEvent();

    protected bool isPressed;
    

    private void OnTriggerEnter(Collider other)
    {
        foreach (Rigidbody rb in correctRigidbodies)
        {
            if (unlockWithAnyObject || rb == other.attachedRigidbody)
            {
                OnPressureStart?.Invoke();
                isPressed = true;
                Debug.Log("Unlocked");
                unlockWithAnyObject = true;
                return;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (Rigidbody rb in correctRigidbodies)
        {
            if (unlockWithAnyObject || rb == other.attachedRigidbody)
            {
                OnPressureEnd?.Invoke();
                isPressed = false; //Turns Animator Off
                Debug.Log("Closed");
                unlockWithAnyObject = true;
                return;
            }
        }
    }
    public bool IsCorrect()
    {
        return isPressed;
    }

    //public void LinkedToPuzzle(Puzzle p)
    //{

    //}

    public void SetDoorOpen()
    {
        anim.SetBool("DoorOpen", true);

        anim.SetBool("DoorClose", false);   
    }  
    public void SetDoorClosed()
    {
        anim.SetBool("DoorOpen", false);

        anim.SetBool("DoorClose", true);   
    }

}
