using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EscapeDoor : MonoBehaviour
{
    private bool isAlertShowing;
    private bool isWinMusicPlaying;
    private float alertTime = 2.0f;

    private PickupData escapeKeyPickupData;

    [SerializeField] private Level morgueLevelSO;
    [SerializeField] private ListPickupDataVariableSO playerInventorySO;
    [SerializeField] private GameObject escapeKeyPrefab;
    [SerializeField] private GameObject alertPanel;
    [SerializeField] private GameObject morgueMusic;
    [SerializeField] private GameObject escapePanel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip doorLockedSFX;
    [SerializeField] private AudioClip winMusic;


    private void Awake()
    {
        //escapeKeyPickupData = escapeKeyPrefab.GetComponent<PickupData>();

        escapePanel.SetActive(false);
        Time.timeScale = 1;
        morgueLevelSO.HasEscapeKey = false;

    }


    public void CheckEscapeDoor()
    {
        if (morgueLevelSO.HasEscapeKey)
        {
            if (isWinMusicPlaying == false)
            {
                isWinMusicPlaying = true;

                // Show Escape win text 
                escapePanel.SetActive(true);

                // Stop morgue music
                morgueMusic.GetComponent<AudioSource>().Stop();

                // Play win music
                audioSource.PlayOneShot(winMusic);

                // Stop time
                Time.timeScale = 0;

                // Remove key form inventory
                int index = playerInventorySO.List.IndexOf(escapeKeyPickupData);

                for (int i = 0; i < playerInventorySO.Count(); i++)
                {
                    // Remove all items when restarting level except 'Napkin' as it came from the City level.
                    if (playerInventorySO.List[i].name != PickupName.Napkin)
                        playerInventorySO.Remove(playerInventorySO.List[i]);
                }
                
            }
        }
        else
        {
            // Show alert message that the door is locked
            alertPanel.GetComponentInChildren<Text>().text = "The Door is Locked!";
            StartCoroutine(AlertTimer(alertTime));

            // Play door locked SFX
            audioSource.PlayOneShot(doorLockedSFX);
        }
    }


    private IEnumerator AlertTimer(float alertTime)
    {
        if (isAlertShowing == false)
        {
            isAlertShowing = true;
            alertPanel.SetActive(true);

            yield return new WaitForSeconds(alertTime);

            isAlertShowing = false;
            alertPanel.SetActive(false);
        }
    }
}
