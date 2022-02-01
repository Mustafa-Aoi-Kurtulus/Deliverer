using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Deliverer.Core
{
    public class TimeManager : MonoBehaviour
    {
        public static float minutes = 0;
        public static float hours = 8;
        [SerializeField] float timeSpeed;
        string minuteValue;
        string hourValue;
        [SerializeField] SceneLoader sl;
        [SerializeField] UIManager ui;
        public static int dayCount = 1;

        [SerializeField] TextMeshProUGUI timeText;
        void Update()
        {
            CalculateTime();
            UpdateHourText();
        }
        void UpdateHourText()
        {
            //Add a zero to if hour or minute is less than 10, 07,08,09 etc.
            if (hours < 10)
            {
                hourValue = "0" + hours;
            }
            else
            {
                hourValue = "" + hours;
            }
            if (minutes < 10)
            {
                minuteValue = "0" + Mathf.RoundToInt(minutes);
            }
            else
            {
                minuteValue = "" + Mathf.RoundToInt(minutes);
            }
            ui.ChangeText(timeText,"Day " + TimeManager.dayCount + "\n" + hourValue + ":" + minuteValue);
        }
        private void CalculateTime()
        {
            //Increase minute every second, if it's 60 or more increase hour by one and set minutes to 0
            minutes += timeSpeed * Time.deltaTime;
            if (minutes >= 60)
            {
                hours++;
                minutes = 0;
            }
            //If hour is 20 call EndDay
            if (hours == 20)
            {
                EndDay();
            }
        }
        public void EndDay()
        {
            sl.LoadGameScene("DayResult");
        }
    }
}

