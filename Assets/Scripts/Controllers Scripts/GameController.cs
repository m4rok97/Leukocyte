using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game_Logic_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Controllers_Scripts
{
    // Todo: I can save the virus flocks in a list
    public class GameController : MonoBehaviour
    {
        private static GameController _instance;
        private bool _isGameOver;
        private Flock _greenVirusFlock;
        private Flock _yellowVirusFlock;
        private Flock _magentaVirusFlock;
        private List<BloodCell> _bloodCells;
        private List<Flock> _virusFlocks;
        public int currentSceneIndex;
        private GameObject _gameLoseUI;
        private GameObject _gameWonUI;
        private GameObject _levelWonUI;
        
        public bool onSurvivalMode;

        public GameObject survivalGameOverUI;
        // public static GameController Instance
        // {
        //     get => _instance == null ? new GameController() : _instance;
        // }

        // public GameController()
        // {
        //     if (_instance != null)
        //     {
        //         return;
        //     }
        //
        //     _instance = this;
        // }

        void OnEnable()
        {
            Debug.Log("OnEnable called");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void Start()
        {
            _bloodCells = FindObjectsOfType<BloodCell>().ToList();
            _virusFlocks = FindObjectsOfType<Flock>().ToList().Where(x => x.name.Contains("Virus")).ToList();
            _isGameOver = false;
            _gameLoseUI = transform.GetChild(0).gameObject;
            _levelWonUI = transform.GetChild(1).gameObject;
            _gameWonUI = transform.GetChild(2).gameObject;
            _gameLoseUI.SetActive(false);
            _gameWonUI.SetActive(false);
            _levelWonUI.SetActive(false);
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);
           
        }

        void Update()
        // Update is called once per frame
        {
            if (onSurvivalMode)
            {
                if (IsGameLose())
                {
                    survivalGameOverUI.SetActive(true);
                    if (Input.GetKeyUp(KeyCode.Return))
                    {
                        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                    }
                }
            }
            else
            {
                if (IsGameWon())
                {
                    if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
                    {
                        _levelWonUI.SetActive(true);
                        if (Input.GetKeyUp(KeyCode.Return))
                        {
                            // StartCoroutine(LoadNextAsyncScene());    
                            SceneManager.LoadScene(currentSceneIndex + 1);
                        }
                    }

                    else
                    {
                        _gameWonUI.SetActive(true);
                        if (Input.GetKeyUp(KeyCode.Return))
                        {
                            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                        }
                    }


                }
            
                if (IsGameLose())
                {
                    print("Looooser");
                    _gameLoseUI.SetActive(true);
                    if (Input.GetKeyUp(KeyCode.Return))
                    {
                        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                    }
                }
            
            
                _isGameOver = IsGameOver();
                if (_isGameOver)
                {
                    print(IsGameWon() ? "You Win" : "You Lose");
                }
            }

           
        }

        private bool IsGameOver()
        {
            return IsGameLose() || IsGameWon();
        }

        private bool IsGameLose()
        {
            return _bloodCells.Count == 0;
        }

        private bool IsGameWon()
        {
            return _virusFlocks.All(x => x.AgentsCount == 0);
        }

        public void RemoveBloodCell(BloodCell bloodCell)
        {
            _bloodCells.Remove(bloodCell);
            _bloodCells = _bloodCells.Where(x => x != null).ToList();
        }

        IEnumerator LoadNextAsyncScene()
        {
            // Set the current Scene to be able to unload it later
            Scene currentScene = SceneManager.GetActiveScene();

            // The Application loads the Scene in the background at the same time as the current Scene.
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(currentSceneIndex + 1, LoadSceneMode.Additive);

            // Wait until the last operation fully loads to return anything
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByBuildIndex(currentSceneIndex + 1));
            // Unload the previous Scene
            SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}