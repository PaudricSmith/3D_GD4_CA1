using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    [SerializeField] private ListPickupDataVariableSO playerInventorySO;
    [SerializeField] private List<Pocket> pockets = new List<Pocket>();


    private void Awake()
    {
        //foreach (var pocket in pockets)
        //{

        //    for (int i = 0; i < playerInventorySO.List.Count; i++)
        //    {
        //        PickupData item = playerInventorySO.List[i];

        //        pocket.Text.text = item.type.ToString();

        //    }
        //}



        //pockets[0].Text.text = playerInventorySO.List[0].type.ToString();

        //Sprite sprite = pockets[0].Icon.sprite;
        pockets[0].Icon.sprite = playerInventorySO.List[0].icon;

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
            case PickupType.HotDog:

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
    /// Adds items to a Scriptable Object list
    /// </summary>
    /// <param name="pickupData"></param>
    private void AddItemToInventoryList(PickupData pickupData)
    {
        playerInventorySO.Add(pickupData); // Store to a Scriptable Object list that is serialized on game exit
    }
}
