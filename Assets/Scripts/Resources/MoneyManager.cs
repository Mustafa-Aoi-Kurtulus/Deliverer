using Deliverer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Deliverer.Resource
{
    public class MoneyManager : MonoBehaviour
    {
        public static int money;
        [SerializeField] UIManager ui;
        void Update()
        {
            ui.ChangeMoneyText(money + " $");
        }
        public void EarnMoney(int amount)
        {
            money += amount;
        }

        public void SpendMoney(int amount)
        {
            money -= amount;
        }
    }
}

