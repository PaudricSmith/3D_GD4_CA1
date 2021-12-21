using GD.Managers;
using System.Collections;
using UnityEngine;

namespace MyGame
{
    /// <summary>
    /// Example GameManager class that performs the operations (save/load, toasts, and logic checks) that your game needs
    /// </summary>
    public class MyGameManager : GameManager
    {
        private void Start()
        {
            //instanciate the waits used by start, play, or end functions
            InitializeWaits();

            //STUDENTCODE - 1
            //SpawnNPC();
            //SpawnPickups();
            //SpawnPlayers();

            //start the main loop that will perform start/end actions and check win/lose logic
            StartCoroutine(GameLoop());
        }

        protected override IEnumerator StartLevel()
        {
            ShowStartToast();   //e.g. "Get Ready!...5..4..3..2..1"
            yield return startWait;  //Timer
        }

        protected override void ShowStartToast()
        {
            Debug.Log($"ShowStartToast at {Time.realtimeSinceStartup}");
        }

        protected override void CheckWinLose()
        {
            Debug.Log($"CheckWinLose at {Time.realtimeSinceStartup}");
        }

        protected override void ShowWinLoseToast()
        {
            Debug.Log($"ShowWinLoseToast at {Time.realtimeSinceStartup}");
        }

        protected override IEnumerator EndLevel()
        {
            ShowWinLoseToast();   //e.g. "You won!"
            //SaveGameData();       //e.g. asynchronously store using AssetDatabase, simple read/write XML to file, or network save

            //wait for N seconds to show the toast
            yield return endWait; //Timer

            //raise an event to show the main menu e.g. Event: MainMenu - Show
            Debug.Log($"Goodbye at {Time.realtimeSinceStartup}");
        }
    }
}