using System.Collections;
using UnityEngine;


public class LightFlicker : MonoBehaviour
{
    [SerializeField] private float timeDelay;
    [SerializeField] private Material lightOnMaterial;
    [SerializeField] private Material lightOffMaterial;

    private Light attachedLight;
    private MeshRenderer meshRenderer;
    public bool isFlickering = false;


    private void Awake()
    {
        attachedLight = gameObject.GetComponentInChildren<Light>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }


    private void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickerLight());
        }
    }


    private IEnumerator FlickerLight()
    {
        isFlickering = true;
        
        attachedLight.intensity = 0.05f;
        meshRenderer.material = lightOffMaterial;

        timeDelay = Random.Range(0.3f, 0.7f);
        yield return new WaitForSeconds(timeDelay);

        attachedLight.intensity = 0.82f;
        meshRenderer.material = lightOnMaterial;

        timeDelay = Random.Range(0.7f, 1.5f);
        yield return new WaitForSeconds(timeDelay);

        isFlickering = false;
    }

}
