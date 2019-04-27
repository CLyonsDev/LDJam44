using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    public int[] IdOrder;
    public int ProgressionIndex = 0;

    public void ButtonPress(int id)
    {
        if(IdOrder[0] == id)
        {
            ProgressionIndex++;
        }

        if(ProgressionIndex+1 == IdOrder.Length)
        {
            Debug.Log("Puzzle Complete!");
        }
    }
}
