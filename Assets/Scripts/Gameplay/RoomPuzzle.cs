using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPuzzle : Puzzle
{
    private void Update()
    {
        if (CheckSolution() && isPuzzleComplete == false)
        {
            OnPuzzleCompleted?.Invoke();
            isPuzzleComplete = true;   
        }
    }

    public override bool CheckSolution()
    {
        foreach (IPuzzlePiece piece in allPuzzlePieces)
        {
            if (!piece.IsCorrect())
            {
                return false;
            }
        }
        return true ;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            isPuzzleActive = true;
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPuzzleActive = false;
        }
    }*/
}
/*private void Awake()
    {
        allPuzzlePieces = GetComponentsInChildren<IPuzzlePiece>();    
        foreach (IPuzzlePiece piece in allPuzzlePieces)
        {
            piece.LinkedToPuzzle(this);
        }
    }*/


