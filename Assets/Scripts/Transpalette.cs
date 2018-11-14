using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP16.JandB
{
    public class Transpalette : MonoBehaviour
    {
        public float speed;
        public float turningSpeed;
        public float paletteSpeed;

        public GameObject palettes;

        [Range(0f, .1f)]
        public float inputDetectionThreshold;

        public float palettesMaximumPosition;
        public float palettesMinimumPosition;
        public float transpaletteMinimumRotation;
        public float transpaletteMaximumRotation;


        float zAngle;
        float paletteVelocity;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }

        private void Update()
        {
            zAngle = transform.localEulerAngles.z;
            zAngle = (zAngle > 180) ? zAngle - 360 : zAngle;
            //Debug.Log(zAngle);
        }

        void FixedUpdate()
        {
            if (Mathf.Abs(Input.GetAxis("Mouse X")) > inputDetectionThreshold)
            {
                Turn();
            }

            if (Mathf.Abs(Input.GetAxis("Mouse Y")) > inputDetectionThreshold)
            {
                UpdatePalette();
            }
            Debug.Log(Mathf.Sign(Input.GetAxis("Mouse X")));

            Move();
            
        }

        public void Turn()
        {
            if (Input.GetAxis("Mouse X") < 0 && zAngle < transpaletteMaximumRotation)
                transform.Rotate(new Vector3(0, 0, turningSpeed * -Input.GetAxis("Mouse X")));

            else if (Input.GetAxis("Mouse X") > 0 && zAngle > transpaletteMinimumRotation)
                transform.Rotate(new Vector3(0, 0, turningSpeed * -Input.GetAxis("Mouse X")));


        }

        public void UpdatePalette()
        {
            palettes.transform.localPosition += new Vector3(0, Input.GetAxis("Mouse Y") * paletteSpeed, 0);
            //palettes.transform.localPosition = new Vector3(0, Mathf.SmoothDamp(palettes.transform.position.y, paletteSpeed * Input.GetAxis("Mouse Y"), ref paletteVelocity, .2f));
            palettes.transform.localPosition = new Vector3(0, Mathf.Clamp(palettes.transform.localPosition.y, palettesMinimumPosition, palettesMaximumPosition), 0);
        }

        public void Move()
        {
            transform.position += new Vector3(0, 0, speed);
        }
    }
}
