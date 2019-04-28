using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    public int[] IdOrder;
    public int ProgressionIndex = 0;
    private bool solved = false;

    public string DoorToUnlockOnCompletion;

    public void ButtonPress(int id)
    {
        if (solved == true)
            return;

        if(IdOrder[ProgressionIndex] == id)
        {
            ProgressionIndex++;
        }
        else
        {
            ProgressionIndex = 0;
        }

        if(ProgressionIndex == IdOrder.Length)
        {
            Debug.Log("Puzzle Complete!");
            solved = true;
        }

        if(solved)
        {
            Touchpad[] doors = Resources.FindObjectsOfTypeAll<Touchpad>();
            foreach (Touchpad door in doors)
            {
                if (door.Name.Equals(DoorToUnlockOnCompletion))
                {
                    Debug.Log("Door " + DoorToUnlockOnCompletion + " unlocked.");
                    door.IsLocked = false;
                    door.Activate();
                    break;
                }
            }
        }
    }
}
