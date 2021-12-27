using UnityEngine;
using UnityEngine.SceneManagement;


public class MorgueDoor : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync("Level1Part2");
        }
    }
}
