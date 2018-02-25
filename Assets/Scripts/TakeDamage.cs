using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TakeDamage : MonoBehaviour
{
    public int hitPoints = 5;
    public string tagName = "HeroWeapon";
    private NavMeshAgent agent;
    private Animator anim;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagName)
        {
			agent.ResetPath();
            anim.SetBool("move", false);
            hitPoints -= 1;

            if (hitPoints > 0)
            {
                anim.SetTrigger("damage");
            }
            else if(hitPoints == 0)
            {
                anim.SetTrigger("pushback");
			} else {
                // TODO: fall to pieces
				GameObject.Destroy(gameObject);
            }
        }
    }
}
