using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavAnimation : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        bool move = agent.velocity.magnitude > agent.radius && agent.remainingDistance > agent.radius;
        anim.SetBool("move", move);
        anim.SetFloat("velx", agent.velocity.x);
        anim.SetFloat("vely", agent.velocity.y);
    }
}
