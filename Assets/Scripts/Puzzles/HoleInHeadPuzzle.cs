using UnityEngine;


public class HoleInHeadPuzzle : MonoBehaviour
{
    private bool isPuzzleSolved = false;
    private PickupData pencilPickupData;

    [SerializeField] ListPickupDataVariableSO playerInventorySO;
    [SerializeField] GameObject pencilPrefab;
    [SerializeField] IntEventSO OnReplacePockets;


    private void Awake()
    {
        pencilPickupData = pencilPrefab.GetComponent<PickupBehaviour>().PickupData;
    }

    public void AddPencil()
    {
        print("In Add Pencil");

        if (isPuzzleSolved == false)
        {
            for (int i = 0; i < playerInventorySO.Count(); i++)
            {

                if (playerInventorySO.List.Contains(pencilPickupData))
                {
                    int index = playerInventorySO.List.IndexOf(pencilPickupData);
                    
                    playerInventorySO.List.Remove(pencilPickupData);


                    GetComponentInChildren<MeshRenderer>().enabled = true;

                    isPuzzleSolved = true;

                    OnReplacePockets.Raise(index);

                    return;
                    
                }
            }
        } 
    }
}
