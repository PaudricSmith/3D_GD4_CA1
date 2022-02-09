using System;
using UnityEngine;
using UnityEngine.UI;

public class NapkinPicture : MonoBehaviour
{
    private bool isPuzzleDone = false;
    private bool hasSprayCan = false;

    [SerializeField] private ListPickupDataVariableSO playerInventorySO;
    [SerializeField] private GameObject afterImage;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sprayCanSFX;


    public void ShowAfterImage()
    {
        if (isPuzzleDone == false)
        {
            for (int i = 0; i < playerInventorySO.Count(); i++)
            {
                if (playerInventorySO.List[i].name == PickupName.Deodorant)
                {
                    hasSprayCan = true;
                    break;
                }
            }
        }
            
        if (isPuzzleDone == false && hasSprayCan)
        {
            isPuzzleDone = true;

            afterImage.GetComponent<Image>().enabled = true;

            // Play spray can SFX
            audioSource.PlayOneShot(sprayCanSFX);
        }
    }
}
