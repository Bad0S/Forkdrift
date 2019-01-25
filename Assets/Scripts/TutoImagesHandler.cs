using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP16.JandB
{
    public class TutoImagesHandler : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnEnable()
        {

        }

        public void SecondTutoStart()
        {
            Time.timeScale = 0f;
            GetComponent<Animator>().SetBool("part2", true);
        }

        public void StartGame()
        {
            Time.timeScale = 1f;
            Destroy(gameObject);
        }

        public void FirstTutoFinished()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
    }
}