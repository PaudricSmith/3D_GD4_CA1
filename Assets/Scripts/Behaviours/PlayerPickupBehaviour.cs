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

    private float alertTime = 3.0f;
    private int reachDistance = 7;
    private bool isAlertShowing = false;

    [SerializeField] private AudioClip pickupSFX;
    [SerializeField] private PickupEventSO pickupEvent;
    [SerializeField] private PickupEventSO OnShowPickupPanel;
    [SerializeField] private GameObject alertPanel;
    [SerializeField] private ListPickupDataVariableSO playerInventorySO;


    private void Start()
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
    /// A method that is called when Left Mouse button is performed with the new Input System.
    /// This method gets the hit info from a pickup object, plays a SFX and raises a pickup event with the pickup data.
    /// </summary>
    /// <param name="context"></param>
    public void OnSelectObject(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            selector.Check(rayProvider.CreateRay());

            if (selector.GetSelection() != null)
            {
                hitInfo = selector.GetHitInfo();

                print(hitInfo.collider.name);

                // If the hitInfo's transform parent object's tag is 'Pickups'
                if (hitInfo.collider.transform.root.CompareTag("Pickups"))
                {
                    if (hitInfo.distance < reachDistance) // If Player is left clicking on pickup within a certain distance
                    {
                        currentPickupBehaviour = hitInfo.collider.gameObject.GetComponent<PickupBehaviour>();

                        if (currentPickupBehaviour != null)
                        {
                            // Send Event to Show Pickup Interaction Panel
                            OnShowPickupPanel.Raise(currentPickupBehaviour.PickupData);
                        }
                    }
                    else // If left clicking too far from pickup, display alert message
                    {
                        if (isAlertShowing == false)
                        {
                            alertPanel.GetComponentInChildren<Text>().text = "Too far away!";
                            StartCoroutine(AlertTimer(alertTime));
                        }
                    }
                }
            }
        }
    }


    private IEnumerator AlertTimer(float alertTime)
    {
        isAlertShowing = true;
        alertPanel.SetActive(true);

        yield return new WaitForSeconds(alertTime);
        
        isAlertShowing = false;
        alertPanel.SetActive(false);
    }
}