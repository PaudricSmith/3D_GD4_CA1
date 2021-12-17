using UnityEngine;


public class LightFlicker : MonoBehaviour
{

    [SerializeField] private GameObject pointLight;
    [SerializeField] private Material lightOnMaterial;
    [SerializeField] private Material lightOffMaterial;

    private MeshRenderer meshRenderer;

    private bool isLightOn = true;



    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        InvokeRepeating("TurnOffLight", 0.5f, 2);
        InvokeRepeating("TurnOnLight", 0.5f, 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (isLightOn == false)
        //{
        //    pointLight.SetActive(true);
        //    isLightOn = true;
        //}
    }


    private void TurnOffLight()
    {
        pointLight.SetActive(false);

        meshRenderer.material = lightOffMaterial;

        //isLightOn = false;

        //print("invoke repeating");
    }

    private void TurnOnLight()
    {
        pointLight.SetActive(true);

        meshRenderer.material = lightOnMaterial;

        //isLightOn = false;

        //print("invoke repeating");
    }
}
