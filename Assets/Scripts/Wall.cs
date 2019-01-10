using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GRP16.JandB
{
    public interface IWall
    {
        void Touched(Transpalette palette);
    }

    public class Wall : MonoBehaviour, IWall
    {
        public void Touched(Transpalette palette)
        {
            palette.Crash();
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20, 20), Random.Range(-0, 20), Random.Range(-20, 20)));
        }
    }

}