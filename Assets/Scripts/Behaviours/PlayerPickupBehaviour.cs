using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerPickupBehaviour : MonoBehaviour
{
    private IRayProvider rayProvider;
    private ISelector selector;
    private RaycastHit hitInfo;

    [SerializeField] private LayerMask pickupTargetLayer;
    [SerializeField] private PickupEventSO pickupEvent;


    private void Start()
    {
        rayProvider = GetComponent<IRayProvider>();
        selector = GetComponent<ISelector>();
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
                    if (hitInfo.distance < 7)
                    {
                        var pickup = hitInfo.collider.gameObject.GetComponent<PickupBehaviour>();

                        if (pickup != null)
                        {

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

                            Destroy(hitInfo.collider.gameObject);
                            pickupEvent.Raise(pickup.PickupData);
                        }
                    }
                    else
                    {
                        Debug.Log("Too Far Away to Select Item");
                    }

                }
            }
        }
    }
}