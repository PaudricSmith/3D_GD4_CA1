using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Pocket : MonoBehaviour, IPointerEnterHandler
{
    private PickupType type = PickupType.None;
    private PickupName itemName = PickupName.None;
    private InteractionPanel interactionPanel;

    [SerializeField] private Image icon;
    [SerializeField] private Text text;

    public Image Icon { get => icon; set => icon = value; }
    public Text Text { get => text; set => text = value; }
    public PickupType Type { get => type; set => type = value; }
    public PickupName Name { get => itemName; set => itemName = value; }


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
                break;
            case PickupType.Note:
                interactionPanel.ShowNotePanel();
                break;
            case PickupType.None:
                interactionPanel.HideInteractionPanel();
                break;
        }
    }
}
