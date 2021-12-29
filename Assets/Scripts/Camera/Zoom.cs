using UnityEngine;


public class Zoom : MonoBehaviour
{
    private Camera thisCamera;
    private PlayerInput playerInput;
    private float fieldOfViewValue = 60f;
    private float maxFOV = 70f;
    private float minFOV = 30f;
    private float incrementFOV = 2f;


    private void Awake()
    {
        playerInput = new PlayerInput();
        thisCamera = GetComponent<Camera>();
    }


    private void OnEnable()
    {
        playerInput.Enable();
    }


    private void OnDisable()
    {
        playerInput.Disable();
    }


    private void Update()
    {
        MouseWheelZoom();
        thisCamera.fieldOfView = fieldOfViewValue;
    }


    private void MouseWheelZoom()
    {
        if (playerInput.StandardControls.Zoom.ReadValue<float>() > 0) // If you scroll up
        {
            if (fieldOfViewValue > minFOV)
            {
                fieldOfViewValue -= incrementFOV;

                if (fieldOfViewValue < minFOV)
                    fieldOfViewValue = minFOV;
            }
        }
        else if (playerInput.StandardControls.Zoom.ReadValue<float>() < 0) // If you scroll down
        {
            if (fieldOfViewValue < maxFOV)
            {
                fieldOfViewValue += incrementFOV;

                if (fieldOfViewValue > maxFOV)
                    fieldOfViewValue = maxFOV;
            }
        }
    }
}