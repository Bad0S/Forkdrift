using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourchesUIScript : MonoBehaviour
{
    public GameObject fourches;
    public Image fourchesUI;
    private Vector3 posFourchesUIStart;

	void Start ()
    {
        posFourchesUIStart = fourchesUI.transform.position;
	}
	
	void Update ()
    {
        fourchesUI.transform.position = new Vector3(posFourchesUIStart.x, posFourchesUIStart.y + fourches.transform.position.y * 150, posFourchesUIStart.z);
	}
}
