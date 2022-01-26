using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerPickupBehaviour : MonoBehaviour
{
    private AudioSource playerAudioSource;
    private IRayProvider rayProvider;
    private ISelector selector;
    private RaycastHit hitInfo;

    private float alertTime = 3.0f;
    private int leftClickDistance = 7;
    private bool isAlertShowing = false;

    [SerializeField] private AudioClip pickupSFX;
    [SerializeField] private PickupEventSO pickupEvent;
    [SerializeField] private GameObject alertPanel;


    private void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        rayProvider = GetComponent<IRayProvider>();
        selector = GetComponent<ISelector>();

        alertPanel.SetActive(false);
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

                Debug.Log(hitInfo.distance);

                // If the hitInfo's transform parent object's tag is 'Pickups'
                if (hitInfo.collider.transform.root.CompareTag("Pickups"))
                {
                    if (hitInfo.distance < leftClickDistance) // If Player is left clicking on pickup within a certain distance
                    {
                        var pickup = hitInfo.collider.gameObject.GetComponent<PickupBehaviour>();

                        if (pickup != null)
                        {
                            playerAudioSource.PlayOneShot(pickupSFX);                           

                            Destroy(hitInfo.collider.gameObject);
                            pickupEvent.Raise(pickup.PickupData);
                        }
                    }
                    else // If left clicking too far from pickup, display alert message
                    {
                        if (isAlertShowing == false)
                        {                          
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

//if (pickup.PickupData.type.Equals(PickupType.Note))
//{
//    Destroy(hitInfo.collider.gameObject);
//    Debug.Log(hitInfo.collider.gameObject);
//}