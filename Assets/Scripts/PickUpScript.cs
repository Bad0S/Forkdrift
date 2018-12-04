using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour, IPickUp
{
    public List<Collider> objectsToPickUp;
    public int nbObjetsPris = 0;
    public Transform CurrentObjectToPickUp;
    public Transform contactPointPalette;
    public Transform palettes;
    public int NbObjetsRamassés = 0;

	void Start ()
    {
    }

    void Update()
    {
        if (objectsToPickUp[NbObjetsRamassés].bounds.Contains(contactPointPalette.position))
            {
                Debug.Log("Il y est");
                CurrentObjectToPickUp = objectsToPickUp[NbObjetsRamassés].GetComponentInParent<Transform>();
                PickUp();
            }
    }

    public void PickUp()
    {
        CurrentObjectToPickUp.transform.SetParent(palettes);
        CurrentObjectToPickUp.transform.localScale = Vector3.one;
        CurrentObjectToPickUp.transform.rotation = Quaternion.identity;
        nbObjetsPris++;
    }
    
}
