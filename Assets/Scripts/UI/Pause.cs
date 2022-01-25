using UnityEngine;
using UnityEngine.InputSystem;


public class Pause : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private GameObject pausePanel;


    private void Awake()
    {
        playerInput = new PlayerInput();

        if (pausePanel.activeSelf)
        {
            pausePanel.SetActive(false);
        }
    }


    private void OnEnable()
    {
        playerInput.StandardControls.Enable();
        playerInput.StandardControls.Pause.performed += OnPausePerformed;
    }


    private void OnDisable()
    {
        playerInput.StandardControls.Disable();
        playerInput.StandardControls.Pause.performed -= OnPausePerformed;
    }


    private void OnPausePerformed(InputAction.CallbackContext context)
    {
        PauseGame();
    }


    private void PauseGame()
    {
        if (pausePanel.activeSelf == false)
        {
            pausePanel.SetActive(true);

            Time.timeScale = 0.01f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
