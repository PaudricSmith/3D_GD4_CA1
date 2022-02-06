using UnityEngine;


[CreateAssetMenu(fileName = "NewLevel", menuName = "Scene Data/Level")]
public class Level : GameScene
{    
    [Header("Level specific")]
    public int enemiesCount;

    [SerializeField] private bool hasEscapeKey;

    public bool HasEscapeKey { get => hasEscapeKey; set => hasEscapeKey = value; }
}
