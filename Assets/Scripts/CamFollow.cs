﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP16.JandB
{
    public class CamFollow : MonoBehaviour
    {
        public Transform target;

        Vector3 offset;
        // Use this for initialization
        void Start()
        {
            offset = target.position + transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = target.position + offset;
        }
    }
}