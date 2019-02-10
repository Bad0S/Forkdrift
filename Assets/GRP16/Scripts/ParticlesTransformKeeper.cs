using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP16.JandB
{
    public class ParticlesTransformKeeper : MonoBehaviour {
        
	    void Update () {
            transform.rotation = Quaternion.identity;
	    }
    }
}
