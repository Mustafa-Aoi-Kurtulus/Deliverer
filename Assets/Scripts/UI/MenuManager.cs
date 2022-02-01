using Deliverer.Core;
using Deliverer.Resource;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Deliverer.Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] Button continueButton;
        void Update()
        {
            if (TimeManager.dayCount == 1 && TimeManager.hours == 8 && TimeManager.minutes == 0)
            {
                continueButton.interactable = false;
            }
            if (MoneyManager.money <= 20 && TimeManager.hours >= 20)
            {
                continueButton.interactable = false;
            }
        }
    }
}

