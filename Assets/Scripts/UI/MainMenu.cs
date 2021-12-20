using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject loadingInterface;
    public Image loadingProgressBar;

    //List of the scenes to load from Main Menu
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();



    public void StartGame()
    {
        HideMenu();
        ShowLoadingScreen();

        //Load the Scene asynchronously in the background
        scenesToLoad.Add(SceneManager.LoadSceneAsync("City"));
        
        StartCoroutine(LoadingScreen());
    }


    public void HideMenu()
    {
        menu.SetActive(false);
    }


    public void ShowLoadingScreen()
    {
        loadingInterface.SetActive(true);
    }


    IEnumerator LoadingScreen()
    {
        float totalProgress = 0;

        for (int i = 0; i < scenesToLoad.Count; i++)
        {
            while (!scenesToLoad[i].isDone)
            {
                //the fillAmount needs a value between 0 and 1, so we devide the progress by the number of scenes to load
                loadingProgressBar.fillAmount = (totalProgress + scenesToLoad[i].progress) / scenesToLoad.Count;

                yield return null;
            }

            //Adding the scene progress to the total progress
            totalProgress += scenesToLoad[i].progress;
        }
    }

    
    public void ExitGame()
    {

#if UNITY_EDITOR
        
        UnityEditor.EditorApplication.isPlaying = false;

#endif

        Application.Quit();
    }
}
