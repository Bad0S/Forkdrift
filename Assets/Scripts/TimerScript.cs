﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP16.JandB
{
    public class TimerScript : MonoBehaviour
    {
        [Header("Liens à faire")]
        public TMPro.TextMeshProUGUI timerText;
        public float timer;

        public bool timerStart;
        void Start()
        {
            timerStart = false;
            timerText.enabled = false;
        }

        void Update()
        {
            if (timerStart)
            {
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                if (timer <= 0)
                {

                }
                timerText.text = Mathf.CeilToInt(timer).ToString();
            }
        }

        public void StartTimer()
        {
            timerText.enabled = true;
            timerStart = true;
        }
    }
}