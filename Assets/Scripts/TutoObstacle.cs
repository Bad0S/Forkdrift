using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP16.JandB
{
    public class TutoObstacle : MonoBehaviour
    {
        Rigidbody rb;
        BoxCollider col;

        public float explosionForce;
        void Start()
        {
            col = GetComponent<BoxCollider>();
            rb = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Transpalette>() != null)
            {
                col.enabled = false;
                rb.AddForce(Vector3.one * Random.Range(20f, 100f));
            }
        }
    }
}