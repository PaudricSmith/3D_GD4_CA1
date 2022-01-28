using UnityEngine;
using UnityEngine.UI;


public class Pocket : MonoBehaviour
{
    private PickupType type = PickupType.None;
    [SerializeField] private Image icon;
    [SerializeField] private Text text;


    public Image Icon { get => icon; set => icon = value; }
    public Text Text { get => text; set => text = value; }
    public PickupType Type { get => type; set => type = value; }
}
