using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject loadingInterface;
    [SerializeField] private Slider loadingProgressBar;
    [SerializeField] private Text loadingProgressPercentage;

    //List of the scenes to load from Main Menu
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();


    private void Awake()
    {
        loadingInterface.SetActive(false);
    }


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


    private IEnumerator LoadingScreen()
    {
        float totalProgress = 0;

        for (int i = 0; i < scenesToLoad.Count; i++)
        {
            while (!scenesToLoad[i].isDone)
            {
                // The fillAmount needs a value between 0 and 1, so we devide the progress by the number of scenes to load
                loadingProgressBar.value = (totalProgress + scenesToLoad[i].progress) / scenesToLoad.Count;

                // Update the percentage text
                loadingProgressPercentage.text = (loadingProgressBar.value * 100.0f).ToString("F0") + "%";

                // When the slider value is above 89% then change value to whole numbers so the bar loads the full way.
                if (loadingProgressBar.wholeNumbers == false && loadingProgressBar.value >= 0.9f)
                {
                    loadingProgressBar.wholeNumbers = true;
                }

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
