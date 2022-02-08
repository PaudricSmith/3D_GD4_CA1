using UnityEngine;
using UnityEngine.AI;


public class GhoulChasePlayer : MonoBehaviour
{
    private bool canChasePlayer = false;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip walkSFX;
    [SerializeField] private AudioClip attackSFX;
    [SerializeField] private AudioClip deathSFX;
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
        // If the chase event has been called which sets the canChasePlayer bool to true
        if (canChasePlayer)
        {
            // Move the Ghoul towards the Player at the speed of the Nav Agent
            ghoulAgent.SetDestination(player.position);

            // If the Ghoul is not moving so has stopped at the Player
            if (ghoulAgent.velocity.x == 0 && ghoulAgent.velocity.z == 0)
            {
                // If the walking SFX clip is playing then stop it so the attack clip can play as soon as the Ghoul attacks
                if (audioSource.clip == walkSFX)
                    audioSource.Stop();

                // Wait till a clip has stopped playing untill playing it again
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = attackSFX;
                    audioSource.Play();
                }

                // Play Attack animation
                ghoulAnimation.Play("Attack1");
            }
            else // If the Ghoul is chasing the Player
            {
                // Wait till a clip has stopped playing untill playing it again
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = walkSFX;
                    audioSource.Play();
                }

                // Play Attack animation
                ghoulAnimation.Play("Walk");
            }
        }
    }


    /// <summary>
    /// Called by the Game Event Listener Component attached to this game object
    /// Sets the chase bool to true and sets the movement speed
    /// </summary>
    public void ChasePlayer()
    {
        canChasePlayer = true;
        ghoulAgent.speed = 0.75f;
    }
}
