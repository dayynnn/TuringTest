using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactability : MonoBehaviour
{
    [SerializeField] private LayerMask interactionFilter;
    [SerializeField] private Transform interactionTip;
    [SerializeField] private GrabbingAbility grabbingAbility;
    

     public void Interact()
     {
        Ray customRay = new Ray(interactionTip.position, interactionTip.forward * 5f);
        RaycastHit tempHit;

        if (!Physics.Raycast(customRay, out tempHit, 5f, interactionFilter))
        {
            grabbingAbility.DropDownObject();
            return;
        }

        IInteractable interactFeature = tempHit.collider.GetComponent<IInteractable>();
        if(interactFeature != null )
        {
            interactFeature.StartInteraction();
        }
        else if(tempHit.rigidbody)
        {
            grabbingAbility.PickUpObject(tempHit.rigidbody);
        }       
        //Debug.DrawRay(interactionTip.position, interactionTip.forward * 5f, Color.red);
     }
}