using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float closeEnoughDist;

    public Interactable ThingToActivateUponArival;

    private NavMeshAgent agent;
    private Animator anim;

    private bool isWalking = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(isWalking)
        {
            Debug.Log(Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(agent.destination.x, 0, agent.destination.z)));
            if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(agent.destination.x, 0, agent.destination.z)) <= closeEnoughDist)
            {
                agent.SetDestination(transform.position);
                isWalking = false;
                anim.SetBool("IsWalking", false);
                ThingToActivateUponArival.Activate();
                anim.SetTrigger("Interact");
            }
        }
    }

    public void MoveToInteract(Vector3 dest, Interactable thing)
    {
        isWalking = true;
        agent.SetDestination(dest);
        anim.SetBool("IsWalking", isWalking);

        ThingToActivateUponArival = thing;
    }
}
