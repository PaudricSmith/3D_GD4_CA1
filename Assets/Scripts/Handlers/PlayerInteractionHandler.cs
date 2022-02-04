using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteractionHandler : MonoBehaviour
{
    private IRayProvider rayProvider;
    private ISelector selector;
    private RaycastHit hitInfo;

    private float alertTime = 3.0f;
    private int reachDistance = 7;
    private bool isAlertShowing = false;

    [SerializeField] private GameObject alertPanel;

    // Start is called before the first frame update
    void Awake()
    {
        rayProvider = GetComponent<IRayProvider>();
        selector = GetComponent<ISelector>();
    }

    /// <summary>
    /// A method that is called when Left Mouse button is performed with the new Input System.
    /// This method gets the hit info from a pickup object, plays a SFX and raises a pickup event with the pickup data.
    /// </summary>
    /// <param name="context"></param>
    public void OnSelectObject(InputAction.CallbackContext context)
    {
        if (context.performed) // If left click was performed 
        {
            selector.Check(rayProvider.CreateRay()); // Check if a ray was created

            if (selector.GetSelection() != null) // If selector is not null
            {
                hitInfo = selector.GetHitInfo(); // Get the hit info

                // If left clicking too far from 'DeadMan' object, display alert message
                if (hitInfo.distance > reachDistance && hitInfo.collider.transform.root.CompareTag("DeadMan")) 
                {
                    if (isAlertShowing == false)
                    {
                        alertPanel.GetComponentInChildren<Text>().text = "Too far away!";
                        StartCoroutine(AlertTimer(alertTime));

                        return;
                    }
                }

                // If the hitInfo's transform parent object's tag is 'DeadMan'
                if (hitInfo.collider.transform.root.CompareTag("DeadMan"))
                {
                    // Send Event to Show Pickup Interaction Panel
                    //OnShowPickupPanel.Raise(currentPickupBehaviour.PickupData);

                    print(hitInfo.collider.name);
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
