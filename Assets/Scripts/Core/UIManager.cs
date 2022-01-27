using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Deliverer.Core
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI fuelText;
        [SerializeField] TextMeshProUGUI moneyText;
        [SerializeField] TextMeshProUGUI timeText;

        public void ChangeMoneyText(string textMessage)
        {
            moneyText.text = textMessage;
        }
        public void ChangeFuelText(string textMessage)
        {
            fuelText.text = textMessage;
        }
        public void ChangeTimeText(string textMessage)
        {
            timeText.text = textMessage;
        }
    }
}

