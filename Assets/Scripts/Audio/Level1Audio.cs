using UnityEngine;


public class Level1Audio : MonoBehaviour
{
    [SerializeField] private Level level1;
    [SerializeField] private AudioSource audioSource;


    private void Start()
    {
        audioSource.volume = level1.MusicVolume;
    }


    //private void Update()
    //{
    //    audioSource.volume = level1.MusicVolume;
    //}
}
