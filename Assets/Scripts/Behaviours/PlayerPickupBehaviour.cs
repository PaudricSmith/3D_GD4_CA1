using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerPickupBehaviour : MonoBehaviour
{
    private AudioSource playerAudioSource;
    private PickupBehaviour currentPickupBehaviour;
    private IRayProvider rayProvider;
    private ISelector selector;
    private RaycastHit hitInfo;

    private float alertTime = 2.0f;
    private int reachDistance = 5;
    private bool isAlertShowing = false;

    [SerializeField] private AudioClip pickupSFX;
    [SerializeField] private PickupEventSO pickupEvent;
    [SerializeField] private PickupEventSO OnShowPickupPanel;
    [SerializeField] private GameObject alertPanel;
    [SerializeField] private ListPickupDataVariableSO playerInventorySO;
    [SerializeField] private Level morgueLevelSO;


    private void Awake()
    {
        playerAudioSource = GetComponent<AudioSource>();
        rayProvider = GetComponent<IRayProvider>();
        selector = GetComponent<ISelector>();

        alertPanel.SetActive(false);
    }


    /// <summary>
    /// This method is called when the 'Pickup Button' is clicked on the interaction Panel
    /// </summary>
    /// 
    public void HandlePickupEvent()
    {
        // If inventory is full but the last item is stackable then keep incrementing it
        if (playerInventorySO.Count() == playerInventorySO.maxPickupDataSlots && currentPickupBehaviour.PickupData.isStackable)
        {
            if (playerInventorySO.List[playerInventorySO.Count() - 1].quantity < currentPickupBehaviour.PickupData.maxStack)
            {
                // Play pick up SFX
                playerAudioSource.PlayOneShot(pickupSFX);

                // Destroy the game object
                Destroy(currentPickupBehaviour.gameObject);

                // Raise a pickup event that will be listened for in the InventoryManager gameObject
                pickupEvent.Raise(currentPickupBehaviour.PickupData);
            }
            else // If inventory is full, display alert message
            {
                if (isAlertShowing == false)
                {
                    alertPanel.GetComponentInChildren<Text>().text = "Inventory full!";
                    StartCoroutine(AlertTimer(alertTime));
                }
            }

        }
        // If player inventory is not yet full
        else if (playerInventorySO.Count() < playerInventorySO.maxPickupDataSlots)
        {

            // Play pick up SFX
            playerAudioSource.PlayOneShot(pickupSFX);

            // Destroy the game object
            Destroy(currentPickupBehaviour.gameObject);

            // Raise a pickup event that will be listened for in the InventoryManager gameObject
            pickupEvent.Raise(currentPickupBehaviour.PickupData);
        }
        else // If inventory is full, display alert message
        {
            if (isAlertShowing == false)
            {
                alertPanel.GetComponentInChildren<Text>().text = "Inventory full!";
                StartCoroutine(AlertTimer(alertTime));
            }
        }
    }


    /// <summary>
    /// Checks if the hitInfo.distance is greater than the players reach distance
    /// If left clicking too far from object, set display text alert message 
    /// </summary>
    /// <param name="hitInfoDistance"></param>
    /// <returns>bool</returns>
    private bool IsCloseEnough(float hitInfoDistance)
    {
        if (hitInfoDistance > reachDistance)
        {
            alertPanel.GetComponentInChildren<Text>().text = "Too far away!";
            StartCoroutine(AlertTimer(alertTime));

            return false;
        }
        return true;
    }


    /// <summary>
    /// A method that is called when Left Mouse button is performed with the new Input System.
    /// This method gets the hit info from a pickup object, plays a SFX and raises a pickup event with the pickup data.
    /// </summary>
    /// <param name="context"></param>
    public void OnSelectPickup(InputAction.CallbackContext context)
    {
        if (context.performed) // If left click was performed 
        {
            selector.Check(rayProvider.CreateRay()); // Check if a ray was created

            if (selector.GetSelection() != null) // If selector is not null
            {
                hitInfo = selector.GetHitInfo(); // Get the hit info

                // If the hitInfo's transform parent object's tag is 'Pickups'
                if (hitInfo.collider.transform.root.CompareTag("Pickups"))
                {
                    // If left clicking too far from 'Pickups' object , display alert message, else return
                    if (IsCloseEnough(hitInfo.distance))
                    {
                        currentPickupBehaviour = hitInfo.collider.gameObject.GetComponent<PickupBehaviour>(); // Cache the PickupBehaviour

                        if (currentPickupBehaviour == null) // If it's null
                        {
                            return;
                        }

                        // If pickup is the Escape Key, set the bool value to true on the levels scriptable object Class
                        if (currentPickupBehaviour.PickupData.name == PickupName.EscapeKey)
                        {
                            morgueLevelSO.HasEscapeKey = true;
                        }

                        // Send Event to Show Pickup Interaction Panel
                        OnShowPickupPanel.Raise(currentPickupBehaviour.PickupData);
                    }
                    else
                    {
                        return;
                    }
                }         
            }
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