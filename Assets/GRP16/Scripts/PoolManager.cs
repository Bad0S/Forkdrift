using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP16.JandB
{
    public class PoolManager : MonoBehaviour
    {
        [Header("Variables Debug")]
        public bool spawn;
        public float tailleChunk;

        [Header("Liens à faire")]
        public Transform t1;
        public Transform t2;
        public Transform transpalette;
        public GameObject[] chunks;
        public FourchesUIScript fourchesUI;

        [Space(20)]
        public List<GameObject> chunksList;
        public List<GameObject> pooledItems;
        GameObject n2;

        void Start()
        {
            chunksList = new List<GameObject>();
            pooledItems = new List<GameObject>();

            for (int i = 0; i < chunks.Length - 1; i++)
            {
                chunksList.Add(chunks[i]);
            }

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

                if (transpalette.position.z > t2.position.z)
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
            if (n2.GetComponent<Chunk>().hasTranportable == true)
            {
                if(fourchesUI.pickup)
                {
                    PoolObjects(pos);
                    return;
                }

                else
                {
                    n2.transform.position = pos;
                    n2.GetComponent<Chunk>().myItem.PoolPickup();
                    chunksList.Remove(chunksList[randomChunk]);
                    return;
                }
            }
            n2.transform.position = pos;
            pooledItems.Add(chunksList[randomChunk]);
            chunksList.Remove(chunksList[randomChunk]);
        }


        public void UnPoolAll()
        {
            foreach(GameObject chunkObject in pooledItems)
            {
                chunkObject.transform.position += new Vector3(156, 324, 23);
            }
        }

    }
}