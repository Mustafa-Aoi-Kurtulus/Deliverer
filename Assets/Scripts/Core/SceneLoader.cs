using Deliverer.Control;
using Deliverer.Resource;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Deliverer.Core
{
    public class SceneLoader : MonoBehaviour
    {
        public void StartNewGame()
        {
            MoneyManager.money = 100;
            TimeManager.dayCount = 1;
            TimeManager.hours = 8;
            TimeManager.minutes = 0;
            Fuel.fuel = 100;
            LoadGameScene("MainGame");
        }
        //Load the scene sceneName
        public void LoadGameScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

