using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerPickupBehaviour : MonoBehaviour
{
    private IRayProvider rayProvider;
    private ISelector selector;
    private RaycastHit hitInfo;

    private float alertTime = 3.0f;
    private int leftClickDistance = 7;
    private bool isAlertShowing = false;

    [SerializeField] private PickupEventSO pickupEvent;
    [SerializeField] private GameObject alertPanel;


    private void Start()
    {
        rayProvider = GetComponent<IRayProvider>();
        selector = GetComponent<ISelector>();

        alertPanel.SetActive(false);
    }


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
//else if (pickup.PickupData.type.Equals(PickupType.HotDog))
//{
//    Destroy(hitInfo.collider.gameObject);
//    Debug.Log(hitInfo.collider.gameObject);
//}