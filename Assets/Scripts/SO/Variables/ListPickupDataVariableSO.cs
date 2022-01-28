using UnityEngine;


/// <summary>
/// Stores pickup data collected during the game
/// </summary>
/// 
[CreateAssetMenu(fileName = "ListPickupDataVariableSO", menuName = "Scriptable Objects/Collections/List/PickupData")]
public class ListPickupDataVariableSO : ListVariableSO<PickupData>
{
    public int maxPickupDataSlots = 4;
}