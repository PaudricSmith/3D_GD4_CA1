using UnityEngine;
using UnityEngine.AI;


public class GhoulChasePlayer : MonoBehaviour
{
    private bool canChasePlayer = false;
    [SerializeField] private Animation ghoulAnimation;
    [SerializeField] private NavMeshAgent ghoulAgent;
    [SerializeField] private Transform player;


    private void Awake()
    {
        ghoulAgent.speed = 0;
        ghoulAnimation.Play("Idle");
    }


    private void Update()
    {
        if (canChasePlayer)
        {
            ghoulAgent.SetDestination(player.position);

            if (ghoulAgent.velocity.x == 0 && ghoulAgent.velocity.z == 0)
            {
                ghoulAnimation.Stop("Walk");
                ghoulAnimation.Play("Attack1");
            }
            else
            {
                ghoulAnimation.Stop("Attack1");
                ghoulAnimation.Play("Walk");
            }
        }
    }


    public void ChasePlayer()
    {
        canChasePlayer = true;
        ghoulAgent.speed = 0.75f;
    }
}
