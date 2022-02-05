using UnityEngine;


public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
{
    [SerializeField]
    [Tooltip("Specify the camera to use to create the ray from camera to mouse")]
    private Camera currentCamera = null;

    [SerializeField]
    [Tooltip("Specify which camera eye (i.e. left, right, mono (non-VR)) to use when creating the ray from camera to mouse")]
    private Camera.MonoOrStereoscopicEye monoOrStereoscopicEye = Camera.MonoOrStereoscopicEye.Mono;

    public Camera CurrentCamera { get => currentCamera; set => currentCamera = value; }

    private void Awake()
    {
        if (CurrentCamera == null && Camera.main != null)
            CurrentCamera = Camera.main;
    }

    public Ray CreateRay()
    {
        return CurrentCamera.ScreenPointToRay(Input.mousePosition, monoOrStereoscopicEye); //Stereoscopic?
    }
}
