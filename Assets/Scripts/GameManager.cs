using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private ListPickupDataVariableSO playerInventorySO;


    public void ResetInventorySO()
    {
        for (int i = 0; i < playerInventorySO.Count(); i++)
        {
            playerInventorySO.Remove(playerInventorySO.List[i]);
        }
    }


    public void QuitGame()
    {
        Application.Quit();

        //UnityEditor.EditorApplication.isPlaying = false;
    }
}