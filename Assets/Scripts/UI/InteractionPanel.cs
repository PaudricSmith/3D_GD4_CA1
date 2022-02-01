using System;
using UnityEngine;
using UnityEngine.UI;


public class InteractionPanel : MonoBehaviour
{
    private RectTransform rectTransform;
    private RectTransform inventoryPanelRectTransform;
    private Pocket pocket;
    private Text[] infoTexts;
    
    private bool isInfoShowing = false;

    [SerializeField] private ListPickupDataVariableSO playerInventorySO;
    
    [SerializeField] private GameObject napKinPrefab;
    [SerializeField] private GameObject itemInfo;
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip eatHotdogSFX;

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
        rectTransform = transform.GetComponent<RectTransform>();

        itemInfo.SetActive(false);
        infoTexts = itemInfo.GetComponentsInChildren<Text>();
    }


    private void Start()
    {
        // If this interaction panel is not active, activate it at the start of game
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }

        // Move this Panel off screen to left at start
        transform.localPosition = new Vector3(-1000, 0, 0);
    }


    private void SetInteractionPanelPosition()
    {
        // Set the position of the Interaction Panel to the right of the Inventory Panel and 'y' of the hovered Pocket
        transform.localPosition = new Vector3(inventoryPanelRectTransform.rect.xMax, pocket.transform.localPosition.y);
    }


    private void SetItemInfoPosition()
    {
        // Set Item Info Panel position depending on if it's above or below the InteractionPanel's origin which is in center of screen
        if (transform.localPosition.y < 0)
            itemInfo.transform.localPosition = new Vector2(itemInfo.transform.localPosition.x, rectTransform.rect.height);
        else
            itemInfo.transform.localPosition = new Vector2(itemInfo.transform.localPosition.x, -rectTransform.rect.height);
    }


    private void SetInfoPanelTexts()
    {
        // Set new Info Panel texts
        infoTexts = itemInfo.GetComponentsInChildren<Text>();
        infoTexts[0].text = pocket.PickupData.name.ToString();
        infoTexts[1].text = pocket.PickupData.info;
    }


    private void SetPanels()
    {
        SetInteractionPanelPosition();
        SetItemInfoPosition();
        SetInfoPanelTexts();
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

    
    public void HideInteractionPanel()
    {
        // Hide this Panel off screen to left
        transform.localPosition = new Vector3(-1000, 0, 0);

        itemInfo.SetActive(false);
        isInfoShowing = false;
    }


    /// <summary>
    /// Called by the 'Use' button when clicked on a pocket interaction panel
    /// </summary>
    /// 
    public void OnUseButtonClicked()
    {
        if (pocket.PickupData.name == PickupName.HotDog)
        {
            // Change the hotdog pickupData to a Napkin as it has been eaten
            var napkinPickupData = napKinPrefab.GetComponent<PickupBehaviour>().PickupData;

            // Using the 'Pocket' name as an index as it spans from '0 to 7' corresponding to its List index
            // Change the pickupdata using the pocket index as they will always be in same index as each other
            playerInventorySO.List[Int16.Parse(pocket.name)] = napkinPickupData;

            // Populate the same pocket with napkin data
            pocket.PickupData = napkinPickupData;
            pocket.Icon.sprite = napkinPickupData.icon;
            pocket.QuantityText.text = napkinPickupData.quantity.ToString();

            // Set new Info Panel texts
            SetInfoPanelTexts();

            // Play eating SFX
            audioSource.PlayOneShot(eatHotdogSFX);
        }
    }


    /// <summary>
    /// Called by the 'Use' button when clicked on a pocket interaction panel
    /// </summary>
    /// 
    public void OnInspectButtonClicked()
    {
        if (pocket.PickupData.type == PickupType.Clue)
        {
            // Change the hotdog pickupData to a Napkin as it has been eaten
            var napkinPickupData = napKinPrefab.GetComponent<PickupBehaviour>().PickupData;

            // Using the 'Pocket' name as an index as it spans from '0 to 7' corresponding to its List index
            // Change the pickupdata using the pocket index as they will always be in same index as each other
            playerInventorySO.List[Int16.Parse(pocket.name)] = napkinPickupData;

            // Populate the same pocket with napkin data
            pocket.PickupData = napkinPickupData;
            pocket.Icon.sprite = napkinPickupData.icon;
            pocket.QuantityText.text = napkinPickupData.quantity.ToString();

            // Set new Info Panel texts
            SetInfoPanelTexts();

            // Play eating SFX
            audioSource.PlayOneShot(eatHotdogSFX);
        }
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


    /// <summary>
    /// Sets the last hovered Pocket to this instance of Pocket
    /// and hides an interactive panel if the pocket is empty
    /// </summary>
    /// 
    public void OnPocketPointerEnter(Pocket currentPocket)
    {
        if (currentPocket.PickupData.type != PickupType.None)
        {
            pocket = currentPocket;
            SetPanels();
        }
        else
        {
            HideInteractionPanel();
        }
    }
}
