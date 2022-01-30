using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    private Text[] infoTexts;

    [SerializeField] private ListPickupDataVariableSO playerInventorySO;
    [SerializeField] private List<Pocket> pockets = new List<Pocket>();
    [SerializeField] private GameObject napKinPrefab;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip eatHotdogSFX;
    [SerializeField] private GameObject itemInfo;


    private void Awake()
    {
        PopulateInventoryUI();
    }


    /// <summary>
    /// Do something when a player picks up a collectable as a Unity Response in the Inventory Manager object
    /// </summary>
    /// <param name="pickupData"></param>
    /// 
    public void HandlePickup(PickupData pickupData)
    {
        // Use Switch to seperate actions for each pickup type
        switch (pickupData.type)
        {
            case PickupType.KeyItem:
                AddItemToInventoryList(pickupData);
                break;
            case PickupType.Note:
                AddItemToInventoryList(pickupData);
                break;
            default:
                break;
        }
    }


    /// <summary>
    /// // Populate UI player inventory with player inventory data 
    /// </summary>
    /// 
    private void PopulateInventoryUI()
    {
        // Iterate through all the player inventory data
        for (int i = 0; i < playerInventorySO.Count(); i++)
        {
            // If the item is stackable and you have more than 1
            if (playerInventorySO.List[i].isStackable && playerInventorySO.List[i].quantity > 1)
            {
                // Enable text and show the quantity 
                pockets[i].QuantityText.enabled = true;
                pockets[i].QuantityText.text = playerInventorySO.List[i].quantity.ToString();
            }
            pockets[i].Type = playerInventorySO.List[i].type;
            pockets[i].Name = playerInventorySO.List[i].name;
            pockets[i].Info = playerInventorySO.List[i].info;

            // Show the items icon
            pockets[i].Icon.sprite = playerInventorySO.List[i].icon;
        }
    }


    /// <summary>
    /// Adds items to a Scriptable Object and local list
    /// </summary>
    /// <param name="pickupData"></param>
    private void AddItemToInventoryList(PickupData pickupData)
    {
        if (playerInventorySO.Count() == 0)
        {
            // Store to a Scriptable Object list that is serialized on game exit
            playerInventorySO.Add(pickupData);

            // Populate the pocket at the same position as player inventory's last index
            pockets[playerInventorySO.Count() - 1].Name = pickupData.name;
            pockets[playerInventorySO.Count() - 1].Type = pickupData.type;
            pockets[playerInventorySO.Count() - 1].Icon.sprite = pickupData.icon;
            pockets[playerInventorySO.Count() - 1].QuantityText.text = pickupData.quantity.ToString();
            pockets[playerInventorySO.Count() - 1].Info = pickupData.info;

            return;
        }

        // If the item is stackable
        if (pickupData.isStackable)
        {                
            // Iterate through player inventory to find same type and update item quantity
            for (int i = 0; i < playerInventorySO.Count(); i++)
            {
                if (playerInventorySO.List[i].type == pickupData.type)
                {
                    print("In Contains Pickup method in if isStackable");

                    // If the pocket has max items in it and there are still more items to search then 'continue' to next pocket.
                    if (playerInventorySO.List[i].quantity == pickupData.maxStack && i < playerInventorySO.Count() - 1)
                    {
                        continue;
                    }
                    else if (playerInventorySO.List[i].quantity < pickupData.maxStack)
                    {
                        // Increment the items quantity
                        pickupData.quantity += playerInventorySO.List[i].quantity;

                        // Remove the deprecated item
                        playerInventorySO.Remove(playerInventorySO.List[i]);

                        // Then add the new updated item 
                        playerInventorySO.Add(pickupData);

                        // Enable text
                        pockets[i].QuantityText.enabled = true;

                        // Update text quantity
                        int tempQuantity = Int16.Parse(pockets[i].QuantityText.text);
                        tempQuantity++;
                        pockets[i].QuantityText.text = tempQuantity.ToString();

                    }
                    else
                    {
                        
                        // Store to a Scriptable Object list that is serialized on game exit
                        playerInventorySO.Add(pickupData);

                        // Populate the pocket at the same position as player inventory's last index
                        pockets[i].Name = pickupData.name;
                        pockets[i].Type = pickupData.type;
                        pockets[i].Icon.sprite = pickupData.icon;
                        pockets[i].QuantityText.text = pickupData.quantity.ToString();
                        pockets[i].Info = pickupData.info;

                    }

                    return;
                }
            }
        }
        else // If not stackable
        {
            if (playerInventorySO.Count() < playerInventorySO.maxPickupDataSlots)
            {
                // Store to a Scriptable Object list that is serialized on game exit
                playerInventorySO.Add(pickupData);

                // Populate the pocket at the same position as player inventory's last index
                pockets[playerInventorySO.Count() - 1].Name = pickupData.name;
                pockets[playerInventorySO.Count() - 1].Type = pickupData.type;
                pockets[playerInventorySO.Count() - 1].Icon.sprite = pickupData.icon;
                pockets[playerInventorySO.Count() - 1].QuantityText.text = pickupData.quantity.ToString();
                pockets[playerInventorySO.Count() - 1].Info = pickupData.info;
            }
        }
    }


    public void OnReplaceHotdog()
    {
        for (int i = 0; i < playerInventorySO.Count(); i++)
        {
            if (playerInventorySO.List[i].name == PickupName.HotDog)
            {
                var pickupData = napKinPrefab.GetComponent<PickupBehaviour>().PickupData;

                // Remove Hotdog
                playerInventorySO.Remove(playerInventorySO.List[i]);
                
                // Add Napkin in the same index as was removed
                playerInventorySO.List.Insert(i, pickupData);

                // Populate the pocket at the same position as player inventory
                pockets[i].Name = pickupData.name;
                pockets[i].Type = pickupData.type;
                pockets[i].Icon.sprite = pickupData.icon;
                pockets[i].QuantityText.text = pickupData.quantity.ToString();
                pockets[i].Info = pickupData.info;

                // Update Info Panel texts
                infoTexts = itemInfo.GetComponentsInChildren<Text>();
                infoTexts[0].text = pickupData.name.ToString();
                infoTexts[1].text = pickupData.info;

                // Play eating SFX
                audioSource.PlayOneShot(eatHotdogSFX);

                return;
            }
        }
    }

}
