using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TakeDamage : MonoBehaviour
{
    public int hitPoints = 5;
    public float sinkRate = 0.5f, destroyDepth = 2f;
    public string tagName = "HeroWeapon";
    private NavMeshAgent agent;
    private Animator anim;
    private bool dead = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagName)
        {
			if(agent.enabled)
	            agent.ResetPath();
            anim.SetBool("move", false);
            hitPoints -= 1;

            if (hitPoints > 0)
            {
                anim.SetTrigger("damage");
            }
            else if (hitPoints == 0)
            {
                anim.SetTrigger("pushback");
                GetComponent<NavFollowTarget>().active = false;
				agent.enabled = false;
            }
            else if (!dead)
            {
                dead = true;
                anim.SetTrigger("death");
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }

    void Update()
    {
        if (dead)
        {
            Vector3 pos = transform.position;
            pos.y -= sinkRate * Time.deltaTime;
            transform.position = pos;
			float terrainY = Terrain.activeTerrain.transform.TransformPoint(0f, Terrain.activeTerrain.SampleHeight(pos), 0f).y;
            if (pos.y < terrainY - destroyDepth)
                GameObject.Destroy(gameObject);
        }
    }
}
