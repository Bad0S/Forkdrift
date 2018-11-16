using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP16.JandB
{
    public class PoolManager : MonoBehaviour
    {


        public Transform t1;
        public Transform t2;
        public Transform transpalette;

        public GameObject[] chunks;

        public float tailleChunk;

        GameObject n1;
        GameObject n2;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (transpalette.position.z > t1.position.z)
            {
                t1.position += new Vector3(0, 0, tailleChunk*2);
                PoolObjects(t1.position);
            }

            else if (transpalette.position.z > t2.position.z)
            {
                t2.position += new Vector3(0, 0, tailleChunk*2);
                PoolObjects(t2.position);
            }


        }

        public void PoolObjects(Vector3 pos)
        {
            var randomChunk = Random.Range(0, chunks.Length - 1);

            if (chunks[randomChunk] != n1)
            {
                n1 = n2;
                n2 = chunks[randomChunk];
                n2.transform.position = pos;
                Debug.Log(n1.transform.position + " et " + n2.transform.position);
            }

            else
            {
                PoolObjects(pos);
            }


        }

    }
}