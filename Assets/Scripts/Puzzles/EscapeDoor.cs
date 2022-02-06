using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EscapeDoor : MonoBehaviour
{
    private bool isAlertShowing;
    private bool isWinMusicPlaying;
    private float alertTime = 2.0f;
    private float timer = 0.0f;

    [SerializeField] private Level morgueLevelSO;
    [SerializeField] private ListPickupDataVariableSO playerInventorySO;

    [SerializeField] private GameObject timerText;
    [SerializeField] private GameObject alertPanel;
    [SerializeField] private GameObject morgueMusic;
    [SerializeField] private GameObject escapePanel;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip doorLockedSFX;
    [SerializeField] private AudioClip winMusic;

    public float Timer { get => timer; set => timer = value; }


    private void Awake()
    {
        escapePanel.SetActive(false);
        Time.timeScale = 1;
        Timer = 0.0f;
        morgueLevelSO.HasEscapeKey = false;
    }


    void Update()
    {
        Timer += Time.deltaTime;

        print(GetTimerText());
    }

    
    public string GetTimerText()
    {
        double roundedTime = System.Math.Round(Timer, 2);

        return roundedTime.ToString();
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

                // Show Time completed in
                timerText.GetComponent<Text>().text = GetTimerText();

                // Stop morgue music
                morgueMusic.GetComponent<AudioSource>().Stop();

                // Play win music
                audioSource.PlayOneShot(winMusic);

                // Stop time
                Time.timeScale = 0;


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
