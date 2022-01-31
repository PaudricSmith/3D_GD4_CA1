using System;
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

    public PickupName Name { get => itemName; set => itemName = value; }
    public PickupType Type { get => type; set => type = value; }
    public string Info { get => info; set => info = value; }
    public Text QuantityText { get => quantityText; set => quantityText = value; }
    public Image Icon { get => icon; set => icon = value; }


    private void Awake()
    {
        interactionPanel = GameObject.FindGameObjectWithTag("InteractionPanel").GetComponent<InteractionPanel>();
    }


    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        switch (Type)
        {
            case PickupType.KeyItem:
                interactionPanel.SetPocketData(this);
                interactionPanel.ShowKeyItemPanel();
                break;
            case PickupType.Note:
                interactionPanel.SetPocketData(this);
                interactionPanel.ShowNotePanel();
                break;
            case PickupType.None:
                interactionPanel.HideInteractionPanel();
                break;
        }
    }
}
