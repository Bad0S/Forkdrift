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
            palette.speed = 0f;
            Debug.Log("hg");
        }
    }

}