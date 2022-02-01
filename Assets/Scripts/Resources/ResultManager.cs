using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Deliverer.Core;

namespace Deliverer.Resource
{
    public class ResultManager : MonoBehaviour
    {
        [Header("Variables")]   
        [SerializeField] int rentAmount;
        [SerializeField] int billAmount;
        [SerializeField] int foodAmount;
        [SerializeField] float timerAmount;
        [SerializeField] bool moneyUpdated;
        int initialMoneyAmount;
        [Header("References")]
        [SerializeField] TextMeshProUGUI resultText;
        [SerializeField] Button continueButton;
        
        void Awake()
        {
            //Save the money, at the end of the day
            initialMoneyAmount = MoneyManager.money;
            moneyUpdated = false;
        }
        void Start()
        {
            if (MoneyManager.money <= 20)
            {
                GameOver();
            }
            else
            {
                UpdateMoney();
                UpdateResultText();
            }
        }
        void GameOver()
        {
            //If the GameOver is called, disable the continue button and change the text
            continueButton.enabled = false;
            resultText.text = "Game Over!";
        }
        private void UpdateMoney()
        {
            if (!moneyUpdated)
            {
                //If money isn't already updated, decrease money by rent, bill and food amount.
                moneyUpdated = true;
                MoneyManager.money -= (rentAmount + billAmount + foodAmount);
            }
        }
        private void UpdateResultText()
        {
            resultText.text = "Day " + TimeManager.dayCount + " is over." +
                "\nYou have " + initialMoneyAmount + "$." +
                "\nYou spent " + rentAmount + "$ for rent." + 
                "\nYou spent " + billAmount + "$ for bills." +
                "\nYou spent " + foodAmount + "$ for food.";
        }
        public void ResetTimeIncreaseDayCount()
        {
            TimeManager.hours = 8;
            TimeManager.minutes = 0;
            TimeManager.dayCount += 1;
        }
    }
}

