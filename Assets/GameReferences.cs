using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameReferences : MonoBehaviour
{
    public static GameReferences refs;

    public Inventory PlayerInventory;
    public StringVariable CurrentCamera;
    public GameObject PlayerGameObject;

    NavMeshAgent agent;
    Rigidbody rb;

    private void Awake()
    {
        refs = this;
        PlayerGameObject = GameObject.FindGameObjectWithTag("Player").transform.root.gameObject;
        agent = PlayerGameObject.GetComponent<NavMeshAgent>();
        rb = PlayerGameObject.GetComponent<Rigidbody>();
    }

    public void MovePlayer(Transform pos)
    {
        //PlayerGameObject.GetComponent<Rigidbody>().MovePosition(pos.position);

        agent.Warp(pos.position);
        rb.MoveRotation(pos.rotation);
    }
}
