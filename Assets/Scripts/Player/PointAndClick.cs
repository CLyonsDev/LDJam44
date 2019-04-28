using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClick : MonoBehaviour
{
    public LayerMask InteractableMask;

    public StringReference CurrentCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            // Fire ray
            GameObject camGO = GameObject.Find(CurrentCamera.Value);
            Camera cam = camGO.GetComponentInChildren<Camera>();

            if(cam == null || camGO == null)
            {
                Debug.LogError("PointAndClick::Update() -- Camera not found on " + CurrentCamera);
                return;
            }

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, InteractableMask))
            {
                Debug.LogWarning(hit.transform.name);
                if(hit.transform.root.gameObject.layer == LayerMask.NameToLayer("Interactable"))
                {
                    Debug.Log("Interact");
                    hit.transform.GetComponent<Interactable>().Activate();
                }
            }
        }
    }
}
