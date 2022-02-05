using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteractionHandler : MonoBehaviour
{
    private IRayProvider rayProvider;
    private ISelector selector;
    private RaycastHit hitInfo;

    private float alertTime = 2.0f;
    private int reachDistance = 5;
    private bool isAlertShowing = false;

    [SerializeField] private GameObject alertPanel;
    [SerializeField] private GameEventSO OnChangeToDeadBodyCam;


    // Start is called before the first frame update
    void Awake()
    {
        rayProvider = GetComponent<IRayProvider>();
        selector = GetComponent<ISelector>();
    }


    /// <summary>
    /// Checks if the hitInfo.distance is greater than the players reach distance
    /// If left clicking too far from object, set display text alert message 
    /// </summary>
    /// <param name="hitInfoDistance"></param>
    /// <returns>bool</returns>
    private bool IsCloseEnough(float hitInfoDistance)
    {
        print("In here !");

        if (hitInfoDistance > reachDistance)
        {
            print("In here !");

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
    public void OnSelectObject(InputAction.CallbackContext context)
    {
        if (context.performed) // If left click was performed 
        {
            selector.Check(rayProvider.CreateRay()); // Check if a ray was created

            if (selector.GetSelection() != null) // If selector is not null
            {
                hitInfo = selector.GetHitInfo(); // Get the hit info

                // Check the left click distance to the body and change camera's if close enough, else display alert text and return
                if (hitInfo.collider.transform.parent.gameObject.CompareTag("OperationMan"))
                {
                    if (IsCloseEnough(hitInfo.distance))
                    {
                        // Raise event to change to dead body camera
                        OnChangeToDeadBodyCam.Raise();
                    }
                    else
                    {
                        return;
                    }
                }

                switch (hitInfo.collider.gameObject.name)
                {
                    case "LeftEyeNew": // If the hitInfo's object's name is 'DeadMan'

                        

                        print("In here !");
                        print(hitInfo.collider.gameObject.name);
                        print(hitInfo.distance);

                        
                        break;

                    case "RightEyeNew": // If the hitInfo's object's name is 'RightEyeNew'

                        print("In here !");
                        print(hitInfo.collider.gameObject.name);
                        print(hitInfo.distance);
                        

                        break;
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
