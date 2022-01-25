using UnityEngine;


public class MorgueDoor : MonoBehaviour
{
    [SerializeField] GameObject doorPanel;


    private void Awake()
    {
        if (doorPanel.activeSelf)
        {
            doorPanel.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Selectable")) // The Player has this tag 'Selectable'
        {
            if (doorPanel != null)
            {
                doorPanel.SetActive(true);
            }
        }
    }


    public void HideDoorPanel()
    {
        if (doorPanel != null)
        {
            doorPanel.SetActive(false);
        }
    }
}
