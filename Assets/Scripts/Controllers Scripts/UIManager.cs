using System;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers_Scripts
{
    public class UIManager : MonoBehaviour
    {
        public Text timer;
        
        void Update()
        {
            timer.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        }
        
    }
}