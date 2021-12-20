using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "sceneDB", menuName = "Scene Data/Database")]
public class SceneData : ScriptableObject
{
    [SerializeField] private List<Level> levels = new List<Level>();
    [SerializeField] private List<Menu> menus = new List<Menu>();
    [SerializeField] private int CurrentLevelIndex = 1;

    #region LEVELS

    //Load a scene with a given index
    public void LoadLevelWithIndex(int index)
    {
        if (index <= levels.Count)
        {
            //Load Gameplay scene for the level
            //SceneManager.LoadSceneAsync("Level" + index.ToString());
            //Load first part of the level in additive mode
            //SceneManager.LoadSceneAsync("Level" + index.ToString() + "Part1", LoadSceneMode.Additive);
        }
        //reset the index if we have no more levels
        else CurrentLevelIndex = 1;
    }

    //Start next level
    public void NextLevel()
    {
        CurrentLevelIndex++;
        LoadLevelWithIndex(CurrentLevelIndex);
    }

    //Restart current level
    public void RestartLevel()
    {
        LoadLevelWithIndex(CurrentLevelIndex);
    }

    //New game, load level 1
    public void NewGame()
    {
        LoadLevelWithIndex(1);
    }

    #endregion LEVELS

    #region MENUS

    //Load main Menu
    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(menus[(int)Type.Main_Menu].SceneName);
    }

    //Load Pause Menu
    public void LoadPauseMenu()
    {
        SceneManager.LoadSceneAsync(menus[(int)Type.Pause_Menu].SceneName);
    }

    #endregion MENUS

}
