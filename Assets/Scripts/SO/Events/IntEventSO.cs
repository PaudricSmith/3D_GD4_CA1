using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An Event that takes an integer as a parameter
/// </summary>
/// 

[CreateAssetMenu(fileName = "IntEventSO", menuName = "Scriptable Objects/Events/Int")]
public class IntEventSO : BaseGameEventSO<int>
{
}


[Serializable]
public class UnityIntEvent : UnityEvent<int>
{
}