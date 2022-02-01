using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Deliverer.Resource;

namespace Deliverer.Core
{
    public class UIManager : MonoBehaviour
    {
        Button continueButton;
        void Start()
        {
            Time.timeScale = 1;
        }
        public void ChangeText(TextMeshProUGUI targetText, string message)
        {
            targetText.text = message;
        }
        public void PauseGame()
        {
            //If time is not stopped, stop the time, else call "ResumeGame"
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
            }
            else
            {
                ResumeGame();
            }
        }
        public void ResumeGame()
        {
            //Unpause the game
            Time.timeScale = 1;
        }
        public void CloseWindow(GameObject window)
        {
            window.SetActive(false);
        }
        public void OpenWindow(GameObject window)
        {
            window.SetActive(true);
        }
    }
}

