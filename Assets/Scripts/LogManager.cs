using System;
using System.Linq;
using ARLogger;
using TMPro;
using UnityEngine;

namespace ARLogger {
    public class LogManager : Singleton<LogManager>
    {   
        public GameObject debugCanvas;
        public TextMeshProUGUI debugTitleText;
        public TextMeshProUGUI debugAreaText;
        public bool enableDebug = false;
        public int maxLines = 15;

        bool isLogging = false;
        int presses = 0;

        void OnEnable() 
        {
            debugCanvas.SetActive(enableDebug);
            debugAreaText.text = "";
            debugTitleText.text = "Logger";
            enabled = enableDebug;
        }

        public void LogInfo(string message)
        {
            if (!isLogging)
                return;

            ClearLines();
            debugAreaText.text += $"{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")} <color=\"white\">{message}</color>\n";
            Debug.Log(message);
        }

        public void LogError(string message)
        {
            if (!isLogging)
                return;

            ClearLines();
            debugAreaText.text += $"{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")} <color=\"red\">{message}</color>\n";
            Debug.LogError(message);
        }

        public void LogWarning(string message)
        {
            if (!isLogging)
                return;

            ClearLines();
            debugAreaText.text += $"{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")} <color=\"yellow\">{message}</color>\n";
            Debug.LogWarning(message);
        }

        private void ClearLines()
        {
            if(debugAreaText.text.Split('\n').Count() >= maxLines)
            {
                debugAreaText.text = string.Empty;
            }
        }

        public void ButtonPress () 
        {
            Debug.Log($"Button pressed {presses} times!");


            // Pause
            if (isLogging)
            {
                debugTitleText.text = "Paused";
                isLogging = false;
                return;
            }

            // Close
            if (presses < 3)
            {
                debugCanvas.SetActive(false);
                presses++;
            } 

            // Open
            else
            {
                debugTitleText.text = "Logger";
                debugCanvas.SetActive(true);
                isLogging = true;
                presses = -1;
            }
        }

    
    }
}