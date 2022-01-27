using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Customer multi-parameter event passing
/// </summary>
/// <see cref="https://www.youtube.com/watch?v=iXNwWpG7EhM"/>
/// 
[Serializable]
public enum PickupType : sbyte
{
    HotDog, Note
}


[Serializable]
public struct PickupData
{
    public int value;
    public PickupType type;
    public GameObject pickup;
    public Sprite icon;
    public bool isStackable;

    public override string ToString()
    {
        if (pickup != null)
        {
            return $"{type}, {value}, {pickup.name + " Object"}, {icon}, {isStackable}";
        }
        else
        {
            return $"{type}, {value}, {icon}, {isStackable}";
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