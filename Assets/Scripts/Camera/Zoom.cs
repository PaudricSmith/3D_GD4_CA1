using UnityEngine;


public class Zoom : MonoBehaviour
{
    private PlayerInput playerInput;
    private int fieldOfView = 60;


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
            if (fieldOfView > 30)
            {
                fieldOfView -= 3;
            }
        }
        else if (playerInput.StandardControls.Zoom.ReadValue<float>() < 0) // If you scroll down
        {
            if (fieldOfView < 70)
            {
                fieldOfView += 3;
            }
        }
    }
}