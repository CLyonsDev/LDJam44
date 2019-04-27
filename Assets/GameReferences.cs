using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReferences : MonoBehaviour
{
    public static GameReferences refs;

    public Inventory PlayerInventory;
    public StringVariable CurrentCamera;

    private void Awake()
    {
        refs = this;
    }
}
