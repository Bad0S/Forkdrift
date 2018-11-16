using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GRP16.JandB
{
    public interface IWall{

        void Touched();
    }

    public class Wall : MonoBehaviour, IWall
    {
        public void Touched()
        {
            Debug.Log("Oreuh");
        }
    }

}