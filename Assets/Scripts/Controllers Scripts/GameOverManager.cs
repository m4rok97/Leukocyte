using System;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers_Scripts
{
    public class GameOverManager : MonoBehaviour
    {
        public Text survivedTimeText;
        public Text bestTimeText;
        public GameObject counterUI;

        void OnEnable()
        {
            int currentTime = Mathf.RoundToInt(Time.timeSinceLevelLoad);
            int bestTime = PlayerPrefs.GetInt("Best Time", 0);
            if (currentTime > bestTime)
            {
                bestTime = currentTime;
                PlayerPrefs.SetInt("Best Time", bestTime);
            }

            // Represent times
            survivedTimeText.text = currentTime.ToString();
            bestTimeText.text = bestTime.ToString();
            
            counterUI.SetActive(false);
        }
    }
}