using System;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    [SerializeField] private ListPickupDataVariableSO playerInventorySO;
    [SerializeField] private List<Pocket> pockets = new List<Pocket>();


    private void Awake()
    {
        // Set the amount of pockets by the player inventory scriptable object data max slots
        //pockets = new List<Pocket>(playerInventorySO.maxPickupDataSlots);

        // Populate on screen player inventory with player inventory data
        // Iterate through all the player inventory data
        for (int i = 0; i < playerInventorySO.Count(); i++)
        {
            // If the item is stackable and you have more than 1
            if (playerInventorySO.List[i].isStackable && playerInventorySO.List[i].quantity > 1)
            {
                // Enable text and show the quantity 
                pockets[i].Text.enabled = true;
                pockets[i].Text.text = playerInventorySO.List[i].quantity.ToString();
            }

            pockets[i].Type = playerInventorySO.List[i].type;
            pockets[i].Name = playerInventorySO.List[i].name;
            
            // Show the items icon
            pockets[i].Icon.sprite = playerInventorySO.List[i].icon;
        
        }

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

        //print a message
        Debug.Log(pickupData);
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
            pockets[playerInventorySO.Count() - 1].Text.text = pickupData.quantity.ToString();

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
                        pockets[i].Text.enabled = true;

                        // Update text quantity
                        int tempQuantity = Int16.Parse(pockets[i].Text.text);
                        tempQuantity++;
                        pockets[i].Text.text = tempQuantity.ToString();

                    }
                    else
                    {
                        
                        // Store to a Scriptable Object list that is serialized on game exit
                        playerInventorySO.Add(pickupData);

                        // Populate the pocket at the same position as player inventory's last index
                        pockets[playerInventorySO.Count() - 1].Name = pickupData.name;
                        pockets[playerInventorySO.Count() - 1].Type = pickupData.type;
                        pockets[playerInventorySO.Count() - 1].Icon.sprite = pickupData.icon;
                        pockets[playerInventorySO.Count() - 1].Text.text = pickupData.quantity.ToString();

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
                pockets[playerInventorySO.Count() - 1].Text.text = pickupData.quantity.ToString();
            }
        }
    }
}
