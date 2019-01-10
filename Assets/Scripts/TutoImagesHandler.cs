using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoImagesHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}
