using UnityEngine;


public class OperationMan : MonoBehaviour
{
    private PickupData eyePickupData;
    private PickupData pencilPickupData;

    private bool isPencilVisible = false;
    private bool isRightEyeVisible = false;
    private bool isLeftEyeVisible = false;
    private bool isAliveEyesVisible = false;

    [SerializeField] private ListPickupDataVariableSO playerInventorySO;
    [SerializeField] private IntEventSO OnReplacePockets;

    [SerializeField] private GameObject pencilPrefab;
    [SerializeField] private GameObject holeInHead;
    [SerializeField] private GameObject eyePrefab;
    [SerializeField] private GameObject rightEye;
    [SerializeField] private GameObject leftEye;
    [SerializeField] private GameObject aliveEyes;


    private void Awake()
    {
        pencilPickupData = pencilPrefab.GetComponent<PickupBehaviour>().PickupData;
        eyePickupData = eyePrefab.GetComponent<PickupBehaviour>().PickupData;
    }


    public void OnRightEyeClicked()
    {
        print("In OnRightEyeClicked() *************************************");
        if (isRightEyeVisible == false)
        {
            if (playerInventorySO.List.Contains(eyePickupData))
            {
                int index = playerInventorySO.List.IndexOf(eyePickupData);

                playerInventorySO.List.Remove(eyePickupData);

                rightEye.GetComponent<MeshRenderer>().enabled = true;

                isRightEyeVisible = true;

                OnReplacePockets.Raise(index);

            }

            if (isRightEyeVisible && isLeftEyeVisible && isPencilVisible && isAliveEyesVisible == false)
            {
                aliveEyes.GetComponent<MeshRenderer>().enabled = true;

                isAliveEyesVisible = true;
            }
        }
    }


    public void OnLeftEyeClicked()
    {

        print("In OnLeftEyeClicked() *************************************");

        if (isLeftEyeVisible == false)
        {
            if (playerInventorySO.List.Contains(eyePickupData))
            {
                int index = playerInventorySO.List.IndexOf(eyePickupData);

                playerInventorySO.List.Remove(eyePickupData);

                leftEye.GetComponent<MeshRenderer>().enabled = true;

                isLeftEyeVisible = true;

                OnReplacePockets.Raise(index);

            }

            if (isRightEyeVisible && isLeftEyeVisible && isPencilVisible && isAliveEyesVisible == false)
            {
                aliveEyes.GetComponent<MeshRenderer>().enabled = true;

                isAliveEyesVisible = true;
            }
        }
    }


    public void AddPencil()
    {
        print("In Add Pencil");

        if (isPencilVisible == false)
        {
            if (playerInventorySO.List.Contains(pencilPickupData))
            {
                int index = playerInventorySO.List.IndexOf(pencilPickupData);

                playerInventorySO.List.Remove(pencilPickupData);

                holeInHead.GetComponentInChildren<MeshRenderer>().enabled = true;

                isPencilVisible = true;

                OnReplacePockets.Raise(index);
            }

            if (isRightEyeVisible && isLeftEyeVisible && isPencilVisible && isAliveEyesVisible == false)
            {
                aliveEyes.GetComponent<MeshRenderer>().enabled = true;

                isAliveEyesVisible = true;
            }
        }
    }
}
