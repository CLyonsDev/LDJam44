using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReferences : MonoBehaviour
{
    public static GameReferences refs;

    public Inventory PlayerInventory;
    public StringVariable CurrentCamera;
    public GameObject PlayerGameObject;

    private void Awake()
    {
        refs = this;
        PlayerGameObject = GameObject.FindGameObjectWithTag("Player").transform.root.gameObject;
    }

    public void MovePlayer(Transform pos)
    {
        PlayerGameObject.GetComponent<Rigidbody>().MovePosition(pos.position);
        PlayerGameObject.GetComponent<Rigidbody>().MoveRotation(pos.rotation);
    }
}
