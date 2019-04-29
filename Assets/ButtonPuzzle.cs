using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    public int[] IdOrder;
    public int ProgressionIndex = 0;
    private bool solved = false;

    public GameObject[] GameObjectsToEnableOnCompletion;
    public GameObject[] GameObjectsToDisableOnCompletion;

    public string DoorToUnlockOnCompletion;

    Animator anim;

    public AudioClip Wrong;
    public AudioClip Right;
    public AudioClip Complete;

    public void ButtonPress(int id)
    {
        if (solved == true)
            return;

        if(IdOrder[ProgressionIndex] == id)
        {
            ProgressionIndex++;
            AudioManager.Instance.PlayGlobalClip(Right, 0.75f);
        }
        else
        {
            ProgressionIndex = 0;
            AudioManager.Instance.PlayGlobalClip(Wrong, 0.75f);
        }

        if(ProgressionIndex == IdOrder.Length)
        {
            Debug.Log("Puzzle Complete!");
            solved = true;
            AudioManager.Instance.PlayGlobalClip(Complete, 0.75f);
        }

        if (solved)
        {
            Touchpad[] doors = Resources.FindObjectsOfTypeAll<Touchpad>();
            foreach (Touchpad door in doors)
            {
                if (door.Name.Equals(DoorToUnlockOnCompletion))
                {
                    Debug.Log("Door " + DoorToUnlockOnCompletion + " unlocked.");
                    door.IsLocked = false;
                    door.Activate();
                    //door.GetComponentInChildren<Animator>().SetTrigger("Open");
                    foreach (GameObject go in GameObjectsToEnableOnCompletion)
                    {
                        go.SetActive(true);
                    }
                    foreach (GameObject go in GameObjectsToDisableOnCompletion)
                    {
                        go.SetActive(false);
                    }
                    break;
                }
            }
        }
    }
}
