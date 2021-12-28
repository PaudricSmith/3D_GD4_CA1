using UnityEngine;


public class Zoom : MonoBehaviour
{
    private PlayerInput playerInput;
    private float fieldOfView = 60f;
    private float maxFOV = 70f;
    private float minFOV = 30f;
    private float incrementFOV = 2f;


    private void Awake()
    {
        playerInput = new PlayerInput();
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
        GetComponent<Camera>().fieldOfView = fieldOfView;
    }


    private void MouseWheelZoom()
    {
        if (playerInput.StandardControls.Zoom.ReadValue<float>() > 0) // If you scroll up
        {
            if (fieldOfView > minFOV)
            {
                fieldOfView -= incrementFOV;

                if (fieldOfView < minFOV)
                    fieldOfView = minFOV;
            }
        }
        else if (playerInput.StandardControls.Zoom.ReadValue<float>() < 0) // If you scroll down
        {
            if (fieldOfView < maxFOV)
            {
                fieldOfView += incrementFOV;

                if (fieldOfView > maxFOV)
                    fieldOfView = maxFOV;
            }
        }
    }
}