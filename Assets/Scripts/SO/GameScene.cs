using UnityEngine;


/// <summary>
/// Stores data relating to a scene within a level
/// </summary>
/// <see cref="https://blogs.unity3d.com/2020/07/01/achieve-better-scene-workflow-with-scriptableobjects/"/>
/// 

public class GameScene : ScriptableObject
{
    [Header("Description")]
    [SerializeField] private string sceneName;
    [SerializeField] private string shortDescription;

    [Header("Audio")]
    [SerializeField] protected AudioClip music;

    [Range(0.0f, 1.0f)]
    [SerializeField] protected float musicVolume;

    public string SceneName { get => sceneName; set => sceneName = value; }

    //[Header("Visuals")]
    //public PostProcessProfile postprocess;
}
