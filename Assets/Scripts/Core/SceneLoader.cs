using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Deliverer.Core
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadGameScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

