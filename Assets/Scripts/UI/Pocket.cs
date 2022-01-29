using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Pocket : MonoBehaviour, IPointerClickHandler
{
    private PickupType type = PickupType.None;
    private PickupName name = PickupName.None;
    [SerializeField] private Image icon;
    [SerializeField] private Text text;


    public Image Icon { get => icon; set => icon = value; }
    public Text Text { get => text; set => text = value; }
    public PickupType Type { get => type; set => type = value; }
    public PickupName Name { get => name; set => name = value; }


    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(Name + " Game Object Clicked!");
    }
}
