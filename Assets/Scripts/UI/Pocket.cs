using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Pocket : MonoBehaviour, IPointerEnterHandler
{
    private InteractionPanel interactionPanel;

    [SerializeField] private PickupData pickupData;
    [SerializeField] private Image icon;
    [SerializeField] private Text quantityText;
    

    public PickupData PickupData { get => pickupData; set => pickupData = value; }
    public Text QuantityText { get => quantityText; set => quantityText = value; }
    public Image Icon { get => icon; set => icon = value; }
    

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        interactionPanel = GameObject.FindGameObjectWithTag("InteractionPanel").GetComponent<InteractionPanel>();

        switch (pickupData.type)
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
