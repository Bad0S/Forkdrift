using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP16.JandB
{
    public class PickUpItem : MonoBehaviour
    {
        public Transform pickupHeight;
        public FourchesUIScript ui;

        Vector3 pickupPos;

        public void Start()
        {

        }

        public void UnpoolPickup()
        {
            Destroy(gameObject);
        }

        public void PoolPickup()
        {
            pickupPos = new Vector3(pickupHeight.position.x, (pickupHeight.localPosition.y * transform.localScale.y + transform.position.y) , pickupHeight.position.z);
            ui.DrawPickUpUI(pickupPos, this);
        }
    }
}