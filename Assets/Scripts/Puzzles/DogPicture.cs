using System;
using UnityEngine;
using UnityEngine.UI;

public class DogPicture : MonoBehaviour
{
    private bool isPuzzleDone = false;
    private bool hasScalpel = false;

    private Pocket currentPocket;
    private Text[] infoTexts;

    [SerializeField] private GameObject afterImage;
    [SerializeField] private GameObject yellowGemPrefab;
    [SerializeField] private GameObject itemInfoPanel;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pluckSFX;


    [SerializeField] private ListPickupDataVariableSO playerInventorySO;
    [SerializeField] private GameEventSO OnPlayerGotYellowGem;

    //[SerializeField] private GameEventSO OnYellowGemTaken;


    public void ShowBeforeImage(Pocket pocket)
    {
        currentPocket = pocket;
    }


    public void ShowAfterImage()
    {
        if (isPuzzleDone == false)
        {
            for (int i = 0; i < playerInventorySO.Count(); i++)
            {
                if (playerInventorySO.List[i].name == PickupName.Scalpel)
                {
                    hasScalpel = true;
                    break;
                }
            }
        }
        
        if (isPuzzleDone == false && hasScalpel)
        {
            afterImage.GetComponent<Image>().enabled = true;

            // Change the Dog picture to a yellow gem 
            var yellowGemPickupData = yellowGemPrefab.GetComponent<PickupBehaviour>().PickupData;

            // Using the 'Pocket' name as an index as it spans from '0 to 7' corresponding to its List index
            // Change the pickupdata using the pocket index as they will always be in same index as each other
            playerInventorySO.List[Int16.Parse(currentPocket.name)] = yellowGemPickupData;

            // Populate the same pocket with napkin data
            currentPocket.PickupData = yellowGemPickupData;
            currentPocket.Icon.sprite = yellowGemPickupData.icon;
            currentPocket.QuantityText.text = yellowGemPickupData.quantity.ToString();

            // Play pluck SFX
            audioSource.PlayOneShot(pluckSFX);

            // Set new Info Panel texts
            SetItemInfoPanelTexts();

            // Send event to Ghoul to let him know the player has the gem and to set his bool to true;
            OnPlayerGotYellowGem.Raise();
        }
        
    }


    private void SetItemInfoPanelTexts()
    {
        // Set new Info Panel texts
        infoTexts = itemInfoPanel.GetComponentsInChildren<Text>();
        infoTexts[0].text = currentPocket.PickupData.name.ToString();
        infoTexts[1].text = currentPocket.PickupData.info;
    }
}
