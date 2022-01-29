using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Pocket : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    private PickupType type = PickupType.None;
    private PickupName itemName = PickupName.None;
    [SerializeField] private Image icon;
    [SerializeField] private Text text;


    public Image Icon { get => icon; set => icon = value; }
    public Text Text { get => text; set => text = value; }
    public PickupType Type { get => type; set => type = value; }
    public PickupName Name { get => itemName; set => itemName = value; }


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

        Vector3 currentPosition = pointerEventData.position;


        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(Name + " Game Object Entered!");
        Debug.Log(currentPosition + " Current position Entered!");

    }
}
