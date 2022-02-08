using UnityEngine;


public class StartHallLightFlicker : MonoBehaviour
{
    [SerializeField] private GameObject pointLight;
    

    public void StartFlickering()
    {
        pointLight.GetComponent<Light>().enabled = true;
        GetComponent<LightFlicker>().enabled = true;
    }
}
