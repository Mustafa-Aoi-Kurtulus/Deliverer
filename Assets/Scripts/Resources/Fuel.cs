using Deliverer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deliverer.Resource
{
    public class Fuel : MonoBehaviour
    {
        public float fuel;
        [SerializeField] UIManager ui;
        [SerializeField] MoneyManager money;
        [SerializeField] int fuelPrice;

        public bool fuelBought;
        public bool canBuyFuel;

        void Update()
        {
            ui.ChangeFuelText("Fuel " + Mathf.RoundToInt(fuel) + "%");
            if (canBuyFuel && !fuelBought)
            {
                BuyFuel();
            }
        }
        public void DecreaseFuel(float fuelUsage)
        {
            fuel -= fuelUsage * Time.deltaTime;
        }
        public void BuyFuel()
        {
            if (MoneyManager.money >= fuelPrice)
            {
                fuelBought = true;
                money.SpendMoney(fuelPrice);
                fuel = 100;
            }
        }

        
    }
}

