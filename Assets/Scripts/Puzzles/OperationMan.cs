using UnityEngine;


public class OperationMan : MonoBehaviour
{
    private AudioSource audioSource;
    private PickupData eyePickupData;
    private PickupData pencilPickupData;

    private bool isPencilVisible = false;
    private bool isRightEyeVisible = false;
    private bool isLeftEyeVisible = false;
    private bool isAliveEyesVisible = false;

    [SerializeField] private ListPickupDataVariableSO playerInventorySO;
    [SerializeField] private IntEventSO OnReplacePockets;
    [SerializeField] private GameEventSO OnStartHallLightFlicker;

    [SerializeField] private GameObject pencilPrefab;
    [SerializeField] private GameObject holeInHead;
    [SerializeField] private GameObject eyePrefab;
    [SerializeField] private GameObject rightEye;
    [SerializeField] private GameObject leftEye;
    [SerializeField] private GameObject aliveEyes;
    [SerializeField] private GameObject escapeKey;

    [SerializeField] private AudioClip insertionSFX;
    [SerializeField] private AudioClip zombieSFX;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        pencilPickupData = pencilPrefab.GetComponent<PickupBehaviour>().PickupData;
        eyePickupData = eyePrefab.GetComponent<PickupBehaviour>().PickupData;
    }


    public void OnRightEyeClicked()
    {
        if (isRightEyeVisible == false)
        {
            if (playerInventorySO.List.Contains(eyePickupData))
            {
                int index = playerInventorySO.List.IndexOf(eyePickupData);

                playerInventorySO.List.Remove(eyePickupData);

                rightEye.GetComponent<MeshRenderer>().enabled = true;

                isRightEyeVisible = true;

                OnReplacePockets.Raise(index);

                // Play scary SFX
                audioSource.PlayOneShot(insertionSFX);

            }

            if (isRightEyeVisible && isLeftEyeVisible && isPencilVisible && isAliveEyesVisible == false)
            {
                aliveEyes.GetComponent<MeshRenderer>().enabled = true;

                isAliveEyesVisible = true;

                // Play Jump scare SFX
                audioSource.clip = zombieSFX;
                audioSource.PlayDelayed(0.5f);

                // Show escape key
                escapeKey.SetActive(true);

                // Start the hall light flickering where the Ghoul is
                OnStartHallLightFlicker.Raise();
            }
        }
    }


    public void OnLeftEyeClicked()
    {
        if (isLeftEyeVisible == false)
        {
            if (playerInventorySO.List.Contains(eyePickupData))
            {
                int index = playerInventorySO.List.IndexOf(eyePickupData);

                playerInventorySO.List.Remove(eyePickupData);

                leftEye.GetComponent<MeshRenderer>().enabled = true;

                isLeftEyeVisible = true;

                OnReplacePockets.Raise(index);

                // Play scary SFX
                audioSource.PlayOneShot(insertionSFX);

            }

            if (isRightEyeVisible && isLeftEyeVisible && isPencilVisible && isAliveEyesVisible == false)
            {
                aliveEyes.GetComponent<MeshRenderer>().enabled = true;

                isAliveEyesVisible = true;

                // Play Jump scare SFX
                audioSource.clip = zombieSFX;
                audioSource.PlayDelayed(0.5f);

                // Show escape key
                escapeKey.SetActive(true);

                // Start the hall light flickering where the Ghoul is
                OnStartHallLightFlicker.Raise();
            }
        }
    }


    public void AddPencil()
    {
        if (isPencilVisible == false)
        {
            if (playerInventorySO.List.Contains(pencilPickupData))
            {
                int index = playerInventorySO.List.IndexOf(pencilPickupData);

                playerInventorySO.List.Remove(pencilPickupData);

                holeInHead.GetComponentInChildren<MeshRenderer>().enabled = true;

                isPencilVisible = true;

                OnReplacePockets.Raise(index);

                // Play scary SFX
                audioSource.PlayOneShot(insertionSFX);
            }

            if (isRightEyeVisible && isLeftEyeVisible && isPencilVisible && isAliveEyesVisible == false)
            {
                aliveEyes.GetComponent<MeshRenderer>().enabled = true;

                isAliveEyesVisible = true;

                // Play Jump scare SFX
                audioSource.clip = zombieSFX;
                audioSource.PlayDelayed(0.5f);

                // Show escape key
                escapeKey.SetActive(true);

                // Start the hall light flickering where the Ghoul is
                OnStartHallLightFlicker.Raise();
            }
        }
    }
}
