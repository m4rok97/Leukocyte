using System.Collections.Generic;
using Game_Logic_Scripts;
using UnityEngine;

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

        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
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
    }
}
