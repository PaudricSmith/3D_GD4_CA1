using UnityEngine;


public class PickupBehaviour : MonoBehaviour
{
    [SerializeField]
    private PickupData pickupData;

    public PickupData PickupData { get => pickupData; }
}