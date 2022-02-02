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
    private bool isClueShowing = false;

    [SerializeField] private ListPickupDataVariableSO playerInventorySO;
    
    [SerializeField] private GameObject napKinPrefab;
    [SerializeField] private GameObject itemInfoPanel;
    [SerializeField] private GameObject inspectPanel;
    
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

        itemInfoPanel.SetActive(false);
        infoTexts = itemInfoPanel.GetComponentsInChildren<Text>();
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


    private void SetItemInfoPanelPosition()
    {
        // Set Item Info Panel position depending on if it's above or below the InteractionPanel's origin which is in center of screen
        if (transform.localPosition.y < 0)
            itemInfoPanel.transform.localPosition = new Vector2(itemInfoPanel.transform.localPosition.x, rectTransform.rect.height);
        else
            itemInfoPanel.transform.localPosition = new Vector2(itemInfoPanel.transform.localPosition.x, -rectTransform.rect.height);
    }


    private void SetItemInfoPanelTexts()
    {
        // Set new Info Panel texts
        infoTexts = itemInfoPanel.GetComponentsInChildren<Text>();
        infoTexts[0].text = pocket.PickupData.name.ToString();
        infoTexts[1].text = pocket.PickupData.info;
    }


    private void SetPanels()
    {
        SetInteractionPanelPosition();
        SetItemInfoPanelPosition();
        SetItemInfoPanelTexts();

        if (pocket.PickupData.type == PickupType.None)
        {
            HideInteractionPanel();
        }
        else if (pocket.PickupData.name == PickupName.HotDog)
        {
            ShowHotdogPanel();
        }
        else if (pocket.PickupData.type == PickupType.Clue)
        {
            ShowCluePanel();
        }

    }


    public void ShowHotdogPanel()
    {
        CancelButton.gameObject.SetActive(true);
        InfoButton.gameObject.SetActive(true);
        InspectButton.gameObject.SetActive(false);
        UseButton.gameObject.SetActive(true);
        CombineButton.gameObject.SetActive(false);
    }


    public void ShowCluePanel()
    {
        CancelButton.gameObject.SetActive(true);
        InfoButton.gameObject.SetActive(true);
        InspectButton.gameObject.SetActive(true);
        UseButton.gameObject.SetActive(false);
        CombineButton.gameObject.SetActive(false);
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
            SetItemInfoPanelTexts();

            // Play eating SFX
            audioSource.PlayOneShot(eatHotdogSFX);
        }
    }


    /// <summary>
    /// Called by the 'Inspect' button when clicked on a pocket interaction panel
    /// </summary>
    /// 
    public void OnInspectButtonClicked()
    {
        if (pocket.PickupData.type == PickupType.Clue)
        {
            Image[] image = inspectPanel.GetComponentsInChildren<Image>();

            // Toggle the Inspect Panel on and off when it's button is clicked
            if (isClueShowing == false)
            {
                // Set pocket inspect image to UI gameObject image          
                image[1].sprite = pocket.PickupData.inspectImage;

                // Set the position of the inspect Panel to the right of the Interactive Panel by half its width
                image[1].transform.localPosition = new Vector3(image[1].transform.localPosition.x + rectTransform.rect.width / 2, image[1].transform.localPosition.y);

                isClueShowing = true;
                inspectPanel.SetActive(true);
            }
            else
            {
                // Set the position of the inspect Panel back to its starting x position
                image[1].transform.localPosition = new Vector3(image[1].transform.localPosition.x - rectTransform.rect.width / 2, image[1].transform.localPosition.y);

                isClueShowing = false;
                inspectPanel.SetActive(false);
            }
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
            itemInfoPanel.SetActive(true);
        }
        else
        {
            isInfoShowing = false;
            itemInfoPanel.SetActive(false);
        }
    }
    
    
    /// <summary>
    /// Sets the last hovered Pocket to this instance of Pocket
    /// and sets all the panels according to the item in the pocket
    /// </summary>
    /// 
    public void OnPocketPointerEnter(Pocket currentPocket)
    {
        pocket = currentPocket;
        SetPanels(); 
    }


    public void HideInteractionPanel()
    {
        // Hide this Panel off screen to left
        transform.localPosition = new Vector3(-1000, 0, 0);

        // Set all inactive(Invisible)
        itemInfoPanel.SetActive(false);
        inspectPanel.SetActive(false);
        isInfoShowing = false;
        isClueShowing = false;
    }
}
