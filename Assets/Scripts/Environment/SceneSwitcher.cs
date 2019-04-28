using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : Interactable
{
    public StringVariable CameraVariable;
    public string CameraToSwitchTo;

    public override void Activate()
    {
        base.Activate();

        Camera[] cams = Resources.FindObjectsOfTypeAll<Camera>();
        GameObject currentCamera = null;
        GameObject nextCamera = null;

        foreach (Camera camera in cams)
        {
            if(camera.transform.root.name == CameraVariable.Value)
            {
                currentCamera = camera.gameObject;
            }
            if (camera.transform.root.name == CameraToSwitchTo)
            {
                nextCamera = camera.gameObject;
            }
        }

        if(currentCamera == null || nextCamera == null)
        {
            Debug.LogError("SceneSwitcher::Activate() -- Current camera or next camera is null!");
            return;
        }

        if(currentCamera == nextCamera)
        {
            Debug.LogError("SceneSwitcher::Activate() -- Current camera cannot switch to the same camera! Make sure the triggers to not overlap.");
            return;
        }

        Debug.Log(currentCamera.name);
        Debug.Log(nextCamera.name);

        nextCamera.SetActive(true);
        currentCamera.SetActive(false);
        CameraVariable.Value = CameraToSwitchTo;
    }
}
