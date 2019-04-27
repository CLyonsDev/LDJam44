using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    public int ButtonID;

    public ButtonPuzzle Puzzle;

    public override void Activate()
    {
        base.Activate();
        Debug.Log("Clicked button " + ButtonID);
    }
}
