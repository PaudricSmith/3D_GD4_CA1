using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Pocket : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{

    private PickupType type = PickupType.None;
    private PickupName itemName = PickupName.None;
    private InteractionPanel interactionPanel;
    private GameObject inventoryPanel;

    private Vector3 currentInteractionPanelPosition;

    [SerializeField] private Image icon;
    [SerializeField] private Text text;
    [SerializeField] private GameObject interactionPanelObject;


    public Image Icon { get => icon; set => icon = value; }
    public Text Text { get => text; set => text = value; }
    public PickupType Type { get => type; set => type = value; }
    public PickupName Name { get => itemName; set => itemName = value; }


    private void Awake()
    {
        inventoryPanel = GameObject.FindGameObjectWithTag("InventoryPanel");
    }

    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        
        Vector3 currentPosition = pointerEventData.position;


        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(Name + " Game Object Clicked!");
        Debug.Log(currentPosition + " Current position Clicked!");

    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        // Make Interaction Panel visible
        interactionPanelObject.SetActive(true);

        // Store the InteractionPanel script 
        interactionPanel = interactionPanelObject.GetComponent<InteractionPanel>();

        // Set the position of the Interaction Panel to the right of the Inventory Panel
        currentInteractionPanelPosition.x = inventoryPanel.GetComponent<RectTransform>().rect.xMax;
        currentInteractionPanelPosition.y = this.transform.localPosition.y;
        currentInteractionPanelPosition.z = this.transform.localPosition.z;
        interactionPanel.transform.localPosition = currentInteractionPanelPosition;


        // If the item in this pocket is a Key(Special Item)Item
        switch (type)
        {
            case PickupType.KeyItem:
                interactionPanel.ShowKeyItemPanel();
                break;
            case PickupType.Note:
                interactionPanel.ShowNotePanel();
                break;
            case PickupType.None:
                interactionPanelObject.SetActive(false);
                break;
        }
    }
}
