using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadUIOnLevelLoad : MonoBehaviour
{
    void Start()
    {
        FadeToBlack.Instance.FadeFromBlack();
    }
}
