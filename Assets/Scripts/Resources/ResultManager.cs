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
        [SerializeField] TextMeshProUGUI resultText;
        [SerializeField] Button continueButton;
        [SerializeField] int rentAmount;
        [SerializeField] int billAmount;
        [SerializeField] int foodAmount;
        [SerializeField] float timerAmount;

        int initialMoneyAmount;
        bool moneyUpdated;
        void Awake()
        {
            initialMoneyAmount = MoneyManager.money;
            moneyUpdated = false;
        }
        void Update()
        {
            UpdateResultText();
            UpdateMoney();
            GameOver();
        }

        private void GameOver()
        {
            if (MoneyManager.money <= 0)
            {
                continueButton.enabled = false;
                float timer = timerAmount;
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    resultText.text = "Game Over!";
                    timer = 0;
                }
            }
        }

        private void UpdateMoney()
        {
            if (!moneyUpdated)
            {
                MoneyManager.money -= rentAmount;
                MoneyManager.money -= billAmount;
                MoneyManager.money -= foodAmount;
                moneyUpdated = true;
            }
        }

        private void UpdateResultText()
        {
            resultText.text = "Day " + TimeManager.dayCount + " is over." +
                "\nYou have " + initialMoneyAmount + "$." +
                "\nYou spent " + rentAmount + "$ for rent" + 
                "\nYou spent " + billAmount + "$ for bills." +
                "\nYou spent " + foodAmount + "$ for food.";
        }
    }
}

