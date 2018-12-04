using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP16.JandB
{
    public class PickUpItem : MonoBehaviour, IWall
    {
        public bool pickedUp;
        public Transform palettesTrans;

        public void Update()
        {
            if (pickedUp)
            {
                transform.position = new Vector3(transform.position.x, palettesTrans.position.y + (palettesTrans.localScale.y * 0.53f), transform.position.z);
            }
        }

        public void Touched(Transpalette transpalette)
        {
            transform.SetParent(transpalette.gameObject.transform);
            palettesTrans = transpalette.palettes.transform;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            pickedUp = true;
        }
    }
}
