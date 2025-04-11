using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Puzzle : MonoBehaviour
{
    // Every puzzle will keep track of all IPuzzlePiece in children
    protected IPuzzlePiece[] allPuzzlePieces;

    private void Awake()
    {
        //Find all components that are children of this GameObject
        allPuzzlePieces = GetComponentsInChildren<IPuzzlePiece>();
    }
    //An event to happen when it is completed, recommended to be used for custom and specific things
    public UnityEvent OnPuzzleCompleted;

    //public bool isPuzzleActive;

    // bool to set TRUE when the puzzle is completed
    public bool isPuzzleComplete;

    public abstract bool CheckSolution();
}
