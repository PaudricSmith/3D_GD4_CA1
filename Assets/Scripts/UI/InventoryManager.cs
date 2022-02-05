using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private Pocket emptyPocket;

    [SerializeField] private ListPickupDataVariableSO playerInventorySO;
    [SerializeField] private List<Pocket> pockets = new List<Pocket>();


    private void Awake()
    {
        PopulateInventoryUI();

        //PickupData emptyPickupData = new PickupData();
        //emptyPocket.PickupData = emptyPickupData;
        //emptyPocket.Icon.sprite = emptyPickupData.icon;
        //emptyPocket.QuantityText.text = emptyPickupData.quantity.ToString();
    }


    /// <summary>
    /// // Populate UI player inventory with player inventory data 
    /// </summary>
    /// 
    public void PopulateInventoryUI()
    {
        //// Player Inventory SO count is 
        //if ()
        //{

        //}

        // Iterate through all the player inventory data
        for (int i = 0; i < playerInventorySO.Count(); i++)
        {
            // Copy the playerInventory data to the pocket pickupdata at same index position
            pockets[i].PickupData = playerInventorySO.List[i];
            
            // If the item is stackable and you have more than 1
            if (playerInventorySO.List[i].isStackable && playerInventorySO.List[i].quantity > 1)
            {
                // Enable text and show the quantity 
                pockets[i].QuantityText.enabled = true;
                pockets[i].QuantityText.text = pockets[i].PickupData.quantity.ToString();
            }

            // Set the items icon
            pockets[i].Icon.sprite = pockets[i].PickupData.icon;
        }
    }


    /// <summary>
    /// Do something when a player picks up a collectable as a Unity Response in the Inventory Manager object
    /// </summary>
    /// <param name="pickupData"></param>
    /// 
    public void HandlePickup(PickupData pickupData)
    {
        AddItemToInventoryList(pickupData);
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

            // Populate the pocket at the first index position
            pockets[0].PickupData = pickupData;
            pockets[0].Icon.sprite = pickupData.icon;
            pockets[0].QuantityText.text = pickupData.quantity.ToString();

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
                    // If the pocket has max items in it and there are still more items to search then 'continue' to next pocket.
                    if (playerInventorySO.List[i].quantity == pickupData.maxStack && i < playerInventorySO.Count() - 1)
                    {
                        continue;
                    }
                    else if (playerInventorySO.List[i].quantity < pickupData.maxStack)
                    {
                        // Increment the items quantity
                        pickupData.quantity += playerInventorySO.List[i].quantity;

                        //// Remove the deprecated item
                        //playerInventorySO.Remove(playerInventorySO.List[i]);

                        // Then add the new updated item 
                        playerInventorySO.List[i] = pickupData;
                        pockets[i].PickupData = pickupData;

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

                        // Populate the pocket 
                        pockets[i].PickupData = pickupData;
                        pockets[i].Icon.sprite = pickupData.icon;
                        pockets[i].QuantityText.text = pickupData.quantity.ToString();
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
                pockets[playerInventorySO.Count() - 1].PickupData = pickupData;
                pockets[playerInventorySO.Count() - 1].Icon.sprite = pickupData.icon;
                pockets[playerInventorySO.Count() - 1].QuantityText.text = pickupData.quantity.ToString();
            }
        }
    }


    public void ReplacePocketByIndex(int index)
    {
        int i;

        // Iterate through all the player inventory data
        for (i = index; i < playerInventorySO.Count(); i++)
        {
            // Copy the playerInventory data to the pocket pickupdata at same index position
            pockets[i].PickupData = playerInventorySO.List[i];

            // If the item is stackable and you have more than 1 quantity of this item
            if (playerInventorySO.List[i].isStackable && playerInventorySO.List[i].quantity > 1)
            {
                // Enable text and show the quantity 
                pockets[i].QuantityText.enabled = true;
                pockets[i].QuantityText.text = pockets[i].PickupData.quantity.ToString();
            }

            // Set the items icon
            pockets[i].Icon.sprite = pockets[i].PickupData.icon;

        }


        if (i == playerInventorySO.Count() && i != pockets.Count - 1)
        {
            // Copy the playerInventory data to the pocket pickupdata at same index position
            pockets[playerInventorySO.Count()].PickupData = pockets[playerInventorySO.Count() + 1].PickupData;

            // Copy the quantity 
            pockets[playerInventorySO.Count()].QuantityText.text = pockets[playerInventorySO.Count() + 1].PickupData.quantity.ToString();

            // Copy the items icon
            pockets[playerInventorySO.Count()].Icon.sprite = pockets[playerInventorySO.Count() + 1].Icon.sprite;

        }
        else if (i == pockets.Count - 1)
        {
            PickupData tempPickupData = new PickupData();
            tempPickupData.icon = pockets[i].GetComponent<Image>().sprite;

            // Copy the playerInventory data to the pocket pickupdata at same index position
            pockets[i].PickupData = tempPickupData;

            // Copy the items icon
            pockets[i].Icon.sprite = pockets[i].PickupData.icon;
        }
    }
}
