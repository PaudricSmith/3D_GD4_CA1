using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An Event that takes a Pocket as a parameter
/// </summary>
/// <see cref="https://www.youtube.com/watch?v=iXNwWpG7EhM"/>
/// 

[CreateAssetMenu(fileName = "PocketEventSO", menuName = "Scriptable Objects/Events/Pocket")]
public class PocketEventSO : BaseGameEventSO<Pocket>
{
}


[Serializable]
public class UnityPocketEvent : UnityEvent<Pocket>
{
}