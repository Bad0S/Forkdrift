using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP16.JandB
{
    public class TimerScript : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI timerText;
        public float timer;

        void Start()
        {

        }

        void Update()
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                Debug.Log("C'est fini");
            }
            timerText.text = Mathf.CeilToInt(timer).ToString();
        }
    }
}