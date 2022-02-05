using UnityEngine;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour
{
    private bool isDeadBodyCamOn = false;

    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera deadBodyCam;
    [SerializeField] private GameObject player;
    [SerializeField] private Button mainCamBtn;


    public void ChangeToMainCam()
    {
        print("In ChangeToMainCam method");

        isDeadBodyCamOn = false;

        mainCamBtn.gameObject.SetActive(false);

        player.GetComponent<CapsuleCollider>().enabled = true;
        player.GetComponent<MouseScreenRayProvider>().CurrentCamera = mainCam;

        mainCam.gameObject.SetActive(true);
        deadBodyCam.gameObject.SetActive(false);
    }


    public void ChangeToDeadBodyCam()
    {        

        if (isDeadBodyCamOn == false)
        {
            isDeadBodyCamOn = true;

            print("In ChangeToDeadBodyCam method");

            mainCamBtn.gameObject.SetActive(true);

            player.GetComponent<CapsuleCollider>().enabled = false;
            player.GetComponent<MouseScreenRayProvider>().CurrentCamera = deadBodyCam;

            mainCam.gameObject.SetActive(false);
            deadBodyCam.gameObject.SetActive(true);
        }
    }
}
