using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavFollowTarget : MonoBehaviour
{
    public bool active = true;
    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        if (!target)
            target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (active && Vector3.Distance(destination, target.position) > 1.0f)
        {
            destination = target.position;
            agent.SetDestination(destination);
        }
    }
}
