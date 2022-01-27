using UnityEngine;
using UnityEngine.UI;


public class Pocket : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text text;


    public Image Icon 
    { 
        get => icon; 
        set => icon = value;
    }
    

    public Text Text { get => text; set => text = value; }
}
