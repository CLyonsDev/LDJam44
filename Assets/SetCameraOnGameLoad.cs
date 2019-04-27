using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraOnGameLoad : MonoBehaviour
{
    public StringReference cam;
    public Inventory inv;

    void Start()
    {
        cam.Value = "Cryochamber Camera";

        Camera[] cams = Resources.FindObjectsOfTypeAll<Camera>();
        foreach (Camera camera in cams)
        {
            if(camera.transform.root.name != cam.Value && camera.transform.root.CompareTag("GameCamera"))
            {
                camera.transform.root.gameObject.SetActive(false);
            }
        }

        inv.Clear();
    }
}
