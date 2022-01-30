using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractionPanel : MonoBehaviour
{
    private RectTransform rectTransform;
    private RectTransform inventoryPanelRectTransform;
    private bool isInfoShowing = false;
    private Text[] infoTexts;

    [SerializeField] private Button infoButton;
    [SerializeField] private Button inspectButton;
    [SerializeField] private Button useButton;
    [SerializeField] private Button combineButton;
    [SerializeField] private Button cancelButton;

    [SerializeField] private GameObject itemInfo;


    public Button InfoButton { get => infoButton; set => infoButton = value; }
    public Button InspectButton { get => inspectButton; set => inspectButton = value; }
    public Button UseButton { get => useButton; set => useButton = value; }
    public Button CombineButton { get => combineButton; set => combineButton = value; }
    public Button CancelButton { get => cancelButton; set => cancelButton = value; }


    private void Awake()
    {
        inventoryPanelRectTransform = GameObject.FindGameObjectWithTag("InventoryPanel").GetComponent<RectTransform>();
        rectTransform = transform.GetComponent<RectTransform>();

        itemInfo.SetActive(false);
        infoTexts = itemInfo.GetComponentsInChildren<Text>();
    }


    private void Start()
    {
        if (gameObject.activeSelf == false)
            ActivateInteractionPanel();

        // Move this Panel off screen to left at start
        transform.localPosition = new Vector3(-1000, 0, 0);

        // Move Info Panel off screen to left at start
        //itemInfo.transform.localPosition = new Vector3(-1000, 0, 0);
    }


    private void SetItemInfoPosition()
    {
        // Set Item Info Panel position depending on if it's above or below the InteractionPanel's origin which is in center of screen
        if (transform.localPosition.y < 0)
            itemInfo.transform.localPosition = new Vector2(itemInfo.transform.localPosition.x, rectTransform.rect.height);
        else
            itemInfo.transform.localPosition = new Vector2(itemInfo.transform.localPosition.x, -rectTransform.rect.height);
    }


    public void ShowKeyItemPanel()
    {
        CancelButton.gameObject.SetActive(true);
        InfoButton.gameObject.SetActive(true);
        InspectButton.gameObject.SetActive(true);
        UseButton.gameObject.SetActive(true);
        CombineButton.gameObject.SetActive(true);
    }


    public void ShowNotePanel()
    {
        CancelButton.gameObject.SetActive(true);
        InfoButton.gameObject.SetActive(true);
        InspectButton.gameObject.SetActive(true);
        UseButton.gameObject.SetActive(false);
        CombineButton.gameObject.SetActive(false);
    }

    public void ShowInteractionPanel(float y, float z)
    {
        // Hide this Panel off screen to left
        transform.localPosition = new Vector3(inventoryPanelRectTransform.rect.xMax, y, z);

        SetItemInfoPosition();
    }


    public void HideInteractionPanel()
    {
        // Hide this Panel off screen to left
        transform.localPosition = new Vector3(-1000, 0, 0);

        itemInfo.SetActive(false);
        isInfoShowing = false;
    }


    public void ActivateInteractionPanel()
    {
        gameObject.SetActive(true);
    }
    

    public void GetPocketData(PickupName name, string info)
    {
        infoTexts = itemInfo.GetComponentsInChildren<Text>();
        infoTexts[0].text = name.ToString();
        infoTexts[1].text = info;
    }


    /// <summary>
    /// Toggle the item info panel on and off when it's button is clicked
    /// </summary>
    /// 
    public void OnInfoButtonClicked()
    {
        if (isInfoShowing == false)
        {
            isInfoShowing = true;
            itemInfo.SetActive(true);
        }
        else
        {
            isInfoShowing = false;
            itemInfo.SetActive(false);
        }
    }
}
