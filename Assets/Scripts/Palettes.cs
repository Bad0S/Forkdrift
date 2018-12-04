using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP16.JandB
{
    public class Palettes : MonoBehaviour {

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<IWall>() != null)
            {
                GetComponentInParent<Transpalette>().speed = 0f;
                Debug.Log("AlloLose");
                collision.gameObject.GetComponent<IWall>().Touched(GetComponentInParent<Transpalette>());
            }
        }
    }
}