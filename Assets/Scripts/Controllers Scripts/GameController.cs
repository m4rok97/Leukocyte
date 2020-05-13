using System.Collections;
using System.Collections.Generic;
using Game_Logic_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers_Scripts
{
    // Todo: I can save the virus flocks in a list
    public class GameController : MonoBehaviour
    {
        private static GameController _instance;
        private bool _isGameOver;
        public Flock greenVirusFlock;
        public Flock yellowVirusFlock;
        public Flock magentaVirusFlock;
        public List<BloodCell> bloodCells; 
        
        
        
        public static GameController Instance
        {
            get => _instance == null ? new GameController() : _instance;
        }

        public GameController()
        {
            if (_instance != null)
            {
                Debug.LogError("Cannot be two instances of GameController");
                return;
            }
            _instance = this;
        }
        
        void OnEnable()
        {
            Debug.Log("OnEnable called");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        
        void Start()
        {
            print("Start");
        }
        
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);
        }
        
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.T))
            {
                StartCoroutine(LoadYourAsyncScene());
            }

            _isGameOver = IsGameOver();
            if (_isGameOver)
            {
                print(IsGameWon() ? "You Win" : "You Lose");
            }
        }
    
        private bool IsGameOver()
        {
            return IsGameLose() || IsGameWon();
        }

        private bool IsGameLose()
        {
            return bloodCells.Count == 0;
        }

        private bool IsGameWon()
        {
            return greenVirusFlock.AgentsCount == 0 && yellowVirusFlock.AgentsCount == 0 &&
                   magentaVirusFlock.AgentsCount == 0;
        }

        public void RemoveBloodCell(BloodCell bloodCell)
        {
            bloodCells.Remove(bloodCell);
        }
        
        IEnumerator LoadYourAsyncScene()
        {
            // Set the current Scene to be able to unload it later
            Scene currentScene = SceneManager.GetActiveScene();

            // The Application loads the Scene in the background at the same time as the current Scene.
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Test", LoadSceneMode.Additive);

            // Wait until the last operation fully loads to return anything
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName("Test"));
            // Unload the previous Scene
            SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}
