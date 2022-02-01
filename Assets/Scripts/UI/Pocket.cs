using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Pocket : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private PocketEventSO OnPocketPointerEnter;

    [SerializeField] private PickupData pickupData;
    [SerializeField] private Image icon;
    [SerializeField] private Text quantityText;
    

    public PickupData PickupData { get => pickupData; set => pickupData = value; }
    public Text QuantityText { get => quantityText; set => quantityText = value; }
    public Image Icon { get => icon; set => icon = value; }
    

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        OnPocketPointerEnter.Raise(this);
    }
}
