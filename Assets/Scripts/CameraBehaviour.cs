using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject forkdrift;

    private float decalageZ; 

	void Start ()
    {
        decalageZ = forkdrift.transform.position.z - transform.position.z;
	}
	
	void Update ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, forkdrift.transform.position.z - decalageZ);
	}
}
