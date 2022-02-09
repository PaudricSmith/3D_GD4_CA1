using UnityEngine;


[CreateAssetMenu(fileName = "NewLevel", menuName = "Scene Data/Level")]
public class Level : GameScene
{    
    [Header("Level specific")]
    public int enemiesCount;

    [SerializeField] private bool hasEscapeKey;
    [SerializeField] private bool hasDefeatedGhoul;

    public bool HasEscapeKey { get => hasEscapeKey; set => hasEscapeKey = value; }
    public bool HasDefeatedGhoul { get => hasDefeatedGhoul; set => hasDefeatedGhoul = value; }
}
