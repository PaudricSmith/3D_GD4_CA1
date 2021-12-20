using UnityEngine;


[CreateAssetMenu(fileName = "NewLevel", menuName = "Scene Data/Level")]
public class Level : GameScene
{
    //[Header("Scenes")]
    //[SerializeField] private List<GameScene> gameSceneList;

    //add more level specific variables here like enemy count, spawn points for players
    //Settings specific to level only
    [Header("Level specific")]
    public int enemiesCount;
}
