using Deliverer.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Deliverer.Resource
{
    public class MoneyManager : MonoBehaviour
    {
        public static int money = 100;
        bool moneyUpdated;
        [Header("References")]
        [SerializeField] UIManager ui;
        [SerializeField] TextMeshProUGUI moneyText;
        void Update()
        {
            ui.ChangeText(moneyText, money + " $");
        }
        public void EarnMoney(int amount)
        {
            money += amount;
        }
        public void SpendMoney(int amount)
        {
            //If moneyUpdated is false, set it to true, decrease the money variable by amount and set the moneyUpdated to false
            if (!moneyUpdated)
            {
                moneyUpdated = true;
                money -= amount;
                moneyUpdated = false;
            }
            
        }
    }
}

