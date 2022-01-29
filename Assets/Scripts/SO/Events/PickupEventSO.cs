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
    TypeCount
}


[Serializable]
public enum PickupType : sbyte
{
    None,
    KeyItem, 
    Note,
    TypeCount
}


[Serializable]
public struct PickupData
{
    public GameObject pickup;
    public PickupName name;
    public PickupType type;
    public Sprite icon;

    public int value;
    public int quantity;
    public int maxStack;
    public bool isStackable;


    public override string ToString()
    {
        if (pickup != null)
        {
            return $"{name}, {type}, {value}, {pickup.name + " Object"}, {icon.name}, {isStackable}, {quantity}";
        }
        else
        {
            return $"{name}, {type}, {value}, {icon.name}, {isStackable}, {quantity}";
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