using UnityEngine;


public class KeyPadDoor : MonoBehaviour
{
    private bool isDoorOpen;

    private string correctPassword = "3612";
    private string inputPassword = "";

    [SerializeField] private GameObject keypadPanel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip normalButtonPressSFX;
    [SerializeField] private AudioClip acceptbuttonSFX;
    [SerializeField] private AudioClip cancelbuttonSFX;
    [SerializeField] private AudioClip wrongPasswordSFX;
    [SerializeField] private AudioClip doorsOpeningSFX;

    [SerializeField] private Animator leftDoorOpen;
    [SerializeField] private Animator rightDoorOpen;



    public void OnKeypadDoorClicked()
    {
        if (isDoorOpen == false)
        {
            keypadPanel.SetActive(true);
        }
    }


    public void Number1ButtonPressed()
    {
        audioSource.PlayOneShot(normalButtonPressSFX);
        inputPassword += "1";   
    }
    public void Number2ButtonPressed()
    {
        audioSource.PlayOneShot(normalButtonPressSFX);
        inputPassword += "2";   
    }
    public void Number3ButtonPressed()
    {
        audioSource.PlayOneShot(normalButtonPressSFX);
        inputPassword += "3";   
    }
    public void Number4ButtonPressed()
    {
        audioSource.PlayOneShot(normalButtonPressSFX);
        inputPassword += "4";   
    }
    public void Number5ButtonPressed()
    {
        audioSource.PlayOneShot(normalButtonPressSFX);
        inputPassword += "5";   
    }
    public void Number6ButtonPressed()
    {
        audioSource.PlayOneShot(normalButtonPressSFX);
        inputPassword += "6";   
    }
    public void Number7ButtonPressed()
    {
        audioSource.PlayOneShot(normalButtonPressSFX);
        inputPassword += "7";   
    }
    public void Number8ButtonPressed()
    {
        audioSource.PlayOneShot(normalButtonPressSFX);
        inputPassword += "8";   
    }
    public void Number9ButtonPressed()
    {
        audioSource.PlayOneShot(normalButtonPressSFX);
        inputPassword += "9";   
    }
    public void Number0ButtonPressed()
    {
        audioSource.PlayOneShot(normalButtonPressSFX);
        inputPassword += "0";   
    }


    public void CancelButtonPressed()
    {
        audioSource.PlayOneShot(cancelbuttonSFX);

        inputPassword = "";

        keypadPanel.SetActive(false);
    }


    public void acceptButtonPressed()
    {
        if (inputPassword.Equals(correctPassword))
        {
            isDoorOpen = true;
            audioSource.PlayOneShot(acceptbuttonSFX);
            keypadPanel.SetActive(false);

            // Turn off the double door collider so the player can pass through
            GetComponent<BoxCollider>().enabled = false;

            // Open Keypad Door 
            leftDoorOpen.Play("KPDoorL_Open", 0, 0.0f);
            rightDoorOpen.Play("KPDoorR_Open", 0, 0.0f);

            // Play doors opening SFX
            audioSource.PlayOneShot(doorsOpeningSFX);
        }
        else
        {
            audioSource.PlayOneShot(wrongPasswordSFX);

            inputPassword = "";
        }
    }

}
