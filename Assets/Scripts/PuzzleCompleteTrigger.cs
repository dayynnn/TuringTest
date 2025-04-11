using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCompleteTrigger : MonoBehaviour
{
    [SerializeField] GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameController.GameCompleted();
            //GetComponent<BoxCollider>().enabled = false;
        }
    }
   
}
