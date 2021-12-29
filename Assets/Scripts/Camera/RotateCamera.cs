using UnityEngine;


public class RotateCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    private PlayerInput playerInput;
    private Vector3 targetPosition;


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
        //Follow();

        targetPosition = target.position;
        //RotateCameraLeft();
        //RotateCameraRight();
    }


    //private void RotateCameraLeft()
    //{
    //    if (playerInput.StandardControls.RotateCamLeft.triggered) // If you press the rotate left key
    //    {
    //        print("RotateCamLeft.triggered ***************************************************************");

    //        if (target != null)
    //        {

    //            //targetPosition.z += -3;

    //            transform.RotateAround(targetPosition, Vector3.up, 45);

    //            //transform.position += new Vector3(-2, 0, -2);

    //            //transform.RotateAround(targetPosition, Vector3.up, 10f * Time.deltaTime);
    //            //offset = transform.position;
    //        }
    //    }
    //}


    //private void RotateCameraRight()
    //{
    //    if (playerInput.StandardControls.RotateCamRight.triggered) // If you press the rotate left key
    //    {
    //        print("RotateCamRight.triggered ***************************************************************");

    //        if (target != null)
    //        {

    //            //targetPosition.z += -3;

    //            transform.RotateAround(targetPosition, Vector3.up, -45);

    //            //transform.RotateAround(targetPosition, Vector3.up, 10f * Time.deltaTime);
    //            //offset = transform.position;
    //        }
    //    }
    //}



    //public void RotateCameraRight(InputAction.CallbackContext context)
    //{
    //    if (context.performed) // If you press the rotate right key
    //    {

    //    }
    //}

}
