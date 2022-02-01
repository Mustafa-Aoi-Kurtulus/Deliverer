using Deliverer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Deliverer.Resource
{
    public class Fuel : MonoBehaviour
    {
        [Header("Variables")]
        public static float fuel = 100;
        [SerializeField] int fuelPrice;
        [Header("Booleans")]
        public bool fuelBought;
        public bool canBuyFuel;
        [Header("References")]
        [SerializeField] UIManager ui;
        [SerializeField] MoneyManager money;
        [SerializeField] Audio sound;
        [SerializeField] AudioSource source;
        [SerializeField] TextMeshProUGUI fuelText;
        [SerializeField] GameObject fuelShopWindow;
        [SerializeField] AudioClip moneySpendClip;

        void Update()
        {
            //Update the fuel text every frame
            UpdateFuelText();
        }
        IEnumerator PlaySpendSound()
        {
            sound.PlaySound(source);
            yield return new WaitForSeconds(moneySpendClip.length);
        }
        private void UpdateFuelText()
        {
            //This changes the fuel text to show the fuel variable after rounding it
            ui.ChangeText(fuelText, "Fuel " + Mathf.RoundToInt(fuel) + "%");
        }
        public void DecreaseFuel(float fuelUsage)
        {
            //Decrease fuel every second by fuelUsage amount
            fuel -= fuelUsage * Time.deltaTime;
        }
        public void BuyFuel()
        {
            fuelBought = true;
            money.SpendMoney(fuelPrice);
            fuel = 100;
            fuelShopWindow.SetActive(false);
        }
        public IEnumerator BuyFuelAction(float time)
        {
            //Spend fuelPrice amount of money and set fuel to 100 after time amount of seconds
            yield return new WaitForSeconds(time);
            if (!fuelBought)
            {
                fuelShopWindow.SetActive(true);
            }
        }
    }
}

