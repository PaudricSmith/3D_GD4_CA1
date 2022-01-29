using UnityEngine;
using UnityEngine.UI;


public class InteractionPanel : MonoBehaviour
{
    [SerializeField] private Button infoButton;
    [SerializeField] private Button inspectButton;
    [SerializeField] private Button useButton;
    [SerializeField] private Button combineButton;
    [SerializeField] private Button cancelButton;

    RectTransform rectTransform;

    public Button InfoButton { get => infoButton; set => infoButton = value; }
    public Button InspectButton { get => inspectButton; set => inspectButton = value; }
    public Button UseButton { get => useButton; set => useButton = value; }
    public Button CombineButton { get => combineButton; set => combineButton = value; }
    public Button CancelButton { get => cancelButton; set => cancelButton = value; }


    private void Start()
    {
        if (gameObject.activeSelf)
            HideInteractionPanel();
    }


    public void ShowKeyItemPanel()
    {
        InfoButton.gameObject.SetActive(true);
        InspectButton.gameObject.SetActive(true);
        UseButton.gameObject.SetActive(true);
        CombineButton.gameObject.SetActive(true);
        CancelButton.gameObject.SetActive(true);
    }


    public void ShowNotePanel()
    {
        InfoButton.gameObject.SetActive(true);
        InspectButton.gameObject.SetActive(true);
        UseButton.gameObject.SetActive(false);
        CombineButton.gameObject.SetActive(false);
        CancelButton.gameObject.SetActive(true);
    }


    public void HideInteractionPanel()
    {
        gameObject.SetActive(false);
    }


    public void ShowInteractionPanel()
    {
        gameObject.SetActive(true);
    }

}
