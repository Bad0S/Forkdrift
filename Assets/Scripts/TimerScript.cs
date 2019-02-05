using System.Collections;
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
        public GameObject tuto;
        public AudioSource alarmeSource;
        public AudioSource sonnerieDeclenchementSource;
        public AudioClip sonnerieDeclenchementClip;
        public bool timerStart;
        public PoolManager poolManager;
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
                    timerText.text = Mathf.CeilToInt(timer).ToString();
                }

                if (timer <= 0)
                {
                    Debug.Log("You won !");
                    timerText.text = "WIN !";
                    poolManager.spawn = false;
                }
            }
        }

        public void StartTimer()
        {
            tuto.SetActive(true);
            timerText.enabled = true;
            timerStart = true;
            sonnerieDeclenchementSource.Play();
            alarmeSource.PlayDelayed(sonnerieDeclenchementClip.length);
            Time.timeScale = 0f;
        }
    }
}