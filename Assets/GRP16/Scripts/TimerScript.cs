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
        public GameObject tuto;
        public AudioSource alarmeSource;
        public AudioSource sonnerieDeclenchementSource;
        public AudioClip sonnerieDeclenchementClip;
        public bool timerStart;
        public PoolManager poolManager;
        public Transpalette transpalette;
        public AudioSource musicSource;
        public AudioClip victoryClip;
        bool hasWon;

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

                if (timer <= 0 && !hasWon)
                {
                    hasWon = true;
                    timerText.text = "WIN !";
                    poolManager.spawn = false;
                    poolManager.UnPoolAll();
                    transpalette.StartCoroutine("FinalDrift");
                    StartCoroutine(Win());
                }
            }
        }

        public IEnumerator Win()
        {
            musicSource.Stop();
            musicSource.PlayOneShot(victoryClip);
            yield return new WaitForSecondsRealtime(3f);
            Time.timeScale = 1f;
#if SIGWARE
	LevelManager.Instance.Win();
#endif
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