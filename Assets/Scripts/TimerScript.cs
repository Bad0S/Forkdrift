using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timer;
    public Text timerText;

	void Start ()
    {
		
	}
	
	void Update ()
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
