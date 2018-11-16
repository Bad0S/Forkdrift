using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP16.JandB
{
    public class PoolManager : MonoBehaviour
    {
        [Header("Variables Debug")]
        public bool spawn;

        [Header("Liens à faire")]
        public Transform t1;
        public Transform t2;
        public Transform transpalette;
        public GameObject[] chunks;

        [Space(20)]
        public List<GameObject> chunksList;
        float tailleChunk;

        GameObject n2;

        void Start()
        {
            chunksList = new List<GameObject>();

            for (int i = 0; i < chunks.Length - 1; i++)
            {
                chunksList.Add(chunks[i]);
            }

            tailleChunk = t2.transform.position.z - t1.transform.position.z;
        }

        void Update()
        {
            if (spawn)
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


        }

        public void PoolObjects(Vector3 pos)
        {
            var randomChunk = Random.Range(0, chunksList.Count - 1);
            n2 = chunksList[randomChunk];
            n2.transform.position = pos;
            chunksList.Remove(chunksList[randomChunk]);
        }

    }
}