using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deliverer.Core
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] float minutes;
        [SerializeField] float hours;
        [SerializeField] float timeSpeed;
        string minuteValue;
        string hourValue;
        [SerializeField] SceneLoader sl;
        [SerializeField] UIManager ui;
        public bool isDayOver;
        public static int dayCount = 0;
        void Update()
        {
            CalculateTime();
            EndDay();
            UpdateHour();
        }
        void UpdateHour()
        {
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
            ui.ChangeTimeText(hourValue + ":" + minuteValue);
        }
        private void CalculateTime()
        {
            minutes += timeSpeed * Time.deltaTime;
            if (minutes >= 60)
            {
                hours++;
                minutes = 0;
            }
            if (hours == 20)
            {
                isDayOver = true;
            }
        }

        private void EndDay()
        {
            if (isDayOver)
            {
                dayCount++;
                sl.LoadGameScene("DayResult");
            }
        }
    }
}

