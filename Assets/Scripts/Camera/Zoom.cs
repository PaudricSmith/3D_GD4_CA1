using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;


public class Zoom : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook thisCamera;
    private PlayerInput playerInput;
    private float fieldOfViewValue = 60f;
    private float maxFOV = 80f;
    private float minFOV = 30f;
    private float incrementFOV = 5f;


    private void Awake()
    {
        playerInput = new PlayerInput();

        thisCamera.m_CommonLens = true;
        thisCamera.m_Lens.FieldOfView = fieldOfViewValue;
    }


    private void OnEnable()
    {
        playerInput.StandardControls.Enable();
        playerInput.StandardControls.Zoom.performed += OnZoomMouseWheelPerformed;
    }

    private void OnDisable()
    {
        playerInput.StandardControls.Disable();
        playerInput.StandardControls.Zoom.performed -= OnZoomMouseWheelPerformed;
    }


    private void OnZoomMouseWheelPerformed(InputAction.CallbackContext context)
    {
        MoveMouseWheel();
    }


    private void MoveMouseWheel()
    {
        thisCamera.m_Lens.FieldOfView = fieldOfViewValue;

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