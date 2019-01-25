using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP16.JandB
{ 
    public class TriggerPickup : MonoBehaviour {

        public TutoImagesHandler handler;

	    // Use this for initialization
	    void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Transpalette>() != null)
            {
                handler.gameObject.SetActive(true);
                handler.SecondTutoStart();
            }
        }
    }
}
