using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInteractionText : MonoBehaviour
{
    public static DisplayInteractionText Instance;
    public TextMeshProUGUI textMesh;

    private void Awake()
    {
        Instance = this;
    }

    public void SetText(string txt)
    {
        if (textMesh.text == txt)
            return;

        textMesh.SetText(txt);
    }
}
