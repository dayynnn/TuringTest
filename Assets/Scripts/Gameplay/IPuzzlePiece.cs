using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPuzzlePiece 
{
    //OPTIONAL: 
    //public void LinkedToPuzzle(Puzzle p);
    
    //similar to IsPuzzleComplete() from PUzzle.cs, but for an individual piece
    public bool IsCorrect();
    
}
