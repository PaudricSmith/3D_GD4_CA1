using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [Range(1, 10)] [SerializeField] private float smoothFactor;

    private Camera thisCamera;
    private PlayerInput playerInput;


    private void Awake()
    {
        thisCamera = GetComponent<Camera>();
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


    private void FixedUpdate()
    {
        //Follow();
    }

    private void LateUpdate()
    {
        Follow();
    }


    private void Update()
    {
        RotateCameraLeft();
    }


    //public void RotateCameraRight(InputAction.CallbackContext context)
    //{
    //    if (context.performed) // If you press the rotate right key
    //    {

    //    }
    //}


    private void RotateCameraLeft()
    {
        if (playerInput.StandardControls.RotateCamLeft.triggered) // If you press the rotate left key
        {
            print("RotateCamLeft.triggered ***************************************************************");

            if (target != null)
            {
                Vector3 targetPosition = target.position;
                //targetPosition.z += -3;

                transform.RotateAround(targetPosition, Vector3.up, 10);

                //transform.RotateAround(targetPosition, Vector3.up, 10f * Time.deltaTime);
            }
        }
    }


    private void Follow()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = smoothPosition;
        }
    }
}