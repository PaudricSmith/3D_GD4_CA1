using UnityEngine;
using UnityEngine.UI;


public class InteractionPanel : MonoBehaviour
{
    private RectTransform inventoryPanelRectTransform;

    [SerializeField] private Button infoButton;
    [SerializeField] private Button inspectButton;
    [SerializeField] private Button useButton;
    [SerializeField] private Button combineButton;
    [SerializeField] private Button cancelButton;


    public Button InfoButton { get => infoButton; set => infoButton = value; }
    public Button InspectButton { get => inspectButton; set => inspectButton = value; }
    public Button UseButton { get => useButton; set => useButton = value; }
    public Button CombineButton { get => combineButton; set => combineButton = value; }
    public Button CancelButton { get => cancelButton; set => cancelButton = value; }


    private void Awake()
    {
        inventoryPanelRectTransform = GameObject.FindGameObjectWithTag("InventoryPanel").GetComponent<RectTransform>();
    }


    private void Start()
    {
        if (gameObject.activeSelf == false)
            ActivateInteractionPanel();

        // Move this Panel off screen to left at start
        transform.localPosition = new Vector3(-1000, 0, 0);
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


    public void ActivateInteractionPanel()
    {
        gameObject.SetActive(true);
    }


    public void ShowInteractionPanel(float y, float z)
    {
        // Hide this Panel off screen to left
        transform.localPosition = new Vector3(inventoryPanelRectTransform.rect.xMax, y, z);
    }


    public void HideInteractionPanel()
    {
        // Hide this Panel off screen to left
        transform.localPosition = new Vector3(-1000, 0, 0);
    }
}
