using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Customer multi-parameter event passing
/// </summary>
/// <see cref="https://www.youtube.com/watch?v=iXNwWpG7EhM"/>
/// 

[Serializable]
public enum PickupName : sbyte
{
    None,
    HotDog,
    Napkin,
    DogPic,
    YellowGem,
    Eye,
    Brain,
    Pencil,
    EscapeKey,
    TypeCount
}


[Serializable]
public enum PickupType : sbyte
{
    None,
    KeyItem, 
    Clue,
    TypeCount
}


[Serializable]
public struct PickupData
{
    public GameObject pickup;
    public PickupName name;
    public PickupType type;
    public Sprite icon;
    public Sprite inspectImage;

    [TextArea(1,3)]
    public string info;
    public int value;
    public int quantity;
    public int maxStack;
    public bool isStackable;


    public override string ToString()
    {
        if (pickup != null)
        {
            return $"{name}, {type}, {value}, {pickup.name + " Object"}, {icon.name}, {inspectImage.name}, {isStackable}, {quantity}, \n{info}";
        }
        else
        {
            return $"{name}, {type}, {value}, {icon.name}, {inspectImage.name}, {isStackable}, {quantity}, \n{info}";
        }

    }
}


[CreateAssetMenu(fileName = "PickupEventSO", menuName = "Scriptable Objects/Events/Pickup")]
public class PickupEventSO : BaseGameEventSO<PickupData>
{
}


[Serializable]
public class UnityPickupEvent : UnityEvent<PickupData>
{
}