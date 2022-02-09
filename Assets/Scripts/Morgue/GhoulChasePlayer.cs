using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class GhoulChasePlayer : MonoBehaviour
{
    private bool isDying = false;
    private bool canChasePlayer = false;
    private bool contactWithPlayer = false;
    private bool hasPlayerYellowGem = false;

    [SerializeField] private GameEventSO OnPlayerDeath;

    [SerializeField] private ListPickupDataVariableSO playerInventorySO;
    [SerializeField] private Level morgueLevelSO;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AudioClip playerDeathSFX;
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
                if (contactWithPlayer && hasPlayerYellowGem && isDying == false)
                {
                    print("In if (hasPlayerYellowGem && isDying == false)");

                    isDying = true;

                    if (audioSource.clip == walkSFX)
                        audioSource.Stop();

                    // Play ghoul dying SFX
                    audioSource.clip = deathSFX;
                    audioSource.Play();

                    // Play death animation
                    ghoulAnimation.Play("Death");

                    canChasePlayer = false;

                    // Update the level data
                    morgueLevelSO.HasDefeatedGhoul = true;

                    return;
                }
                else 
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


    /// <summary>
    /// Called by the Game Event Listener Component attached to this game object
    /// Sets the player gem bool to true
    /// </summary>
    public void PlayerHasYellowGem()
    {
        hasPlayerYellowGem = true;
    }


    /// <summary>
    /// When the Ghoul comes in contact with Player
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SuitedMan")
        {
            contactWithPlayer = true;

            StartCoroutine(PlayerDeathTimer(3));

            print(other.gameObject.name + "*****************************************************************");
        }
    }


    private IEnumerator PlayerDeathTimer(float alertTime)
    {
        yield return new WaitForSeconds(1);

        // Player scream SFX
        playerAudioSource.PlayOneShot(playerDeathSFX);

        yield return new WaitForSeconds(2);

        // After 3 seconds, end game
        print(" GAME OVER *****************************************************************");

        OnPlayerDeath.Raise();
    }
}
