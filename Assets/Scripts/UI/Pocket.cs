using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Pocket : MonoBehaviour, IPointerEnterHandler
{
    private PickupType type = PickupType.None;
    private PickupName itemName = PickupName.None;
    private InteractionPanel interactionPanel;
    private string info = "";

    [SerializeField] private Image icon;
    [SerializeField] private Text quantityText;

    public Image Icon { get => icon; set => icon = value; }
    public Text QuantityText { get => quantityText; set => quantityText = value; }
    public PickupType Type { get => type; set => type = value; }
    public PickupName Name { get => itemName; set => itemName = value; }
    public string Info { get => info; set => info = value; }


    private void Awake()
    {
        interactionPanel = GameObject.FindGameObjectWithTag("InteractionPanel").GetComponent<InteractionPanel>();
    }


    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        // Set the position of the Interaction Panel to the right of the Inventory Panel and 'y' of the hovered Pocket
        interactionPanel.ShowInteractionPanel(this.transform.localPosition.y, this.transform.localPosition.z);

        // If the item in this pocket is a Key(Special Item)Item
        switch (type)
        {
            case PickupType.KeyItem:
                interactionPanel.ShowKeyItemPanel();
                interactionPanel.GetPocketData(Name, Info);
                break;
            case PickupType.Note:
                interactionPanel.ShowNotePanel();
                interactionPanel.GetPocketData(Name, Info);
                break;
            case PickupType.None:
                interactionPanel.HideInteractionPanel();
                break;
        }
    }


    public void OnInfoButtonClicked()
    {
        print(Name);
        //interactionPanel.ShowItemInfo(Name);
    }
}
