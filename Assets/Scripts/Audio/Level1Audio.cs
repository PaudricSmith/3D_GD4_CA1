using UnityEngine;


public class Level1Audio : MonoBehaviour
{
    [SerializeField] private Level level;
    [SerializeField] private AudioSource audioSource;


    private void Start()
    {
        audioSource.volume = level.MusicVolume;
        
    }

}
