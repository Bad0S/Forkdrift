using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP16.JandB
{
    public class Transpalette : MonoBehaviour
    {
        #region variables
        [Header("Valeurs à tweak GD/Gfeel")]
        [Header("Vitesses")]
        [Tooltip("Vitesse d'avancée du transpalette")]
        public float speed;
        [Tooltip("Vitesse à laquelle le transpalette rotate")]
        public float turningSpeed;
        [Tooltip("Vitesse à laquelle les palettes se déplacent")]
        public float paletteSpeed;
        [Header("Gamefeel variables")]
        [Tooltip("La fonction selon laquelle les particules vont spawn")]
        public AnimationCurve particlesAC;
        [Tooltip("Le nombre de particules qui spawnent quand on drifte")]
        public float particlesMultiplier;
        [Tooltip("Le gradient utilisé par les particules")]
        public Gradient particlesGradient;
        [Space(20)]


        [Header("Valeurs pour que la prog fonctionne bien")]
        [Range(0f, .1f)]
        [Tooltip("Valeur en dessous de laquelle les inputs ne sont pas comptabilisés")]
        public float inputDetectionThreshold;
        [Range(0f, 3f)]
        [Tooltip("Temps avant que le transpalette ne déraille")]
        public float timeBeforeDriftingOut;
        [Range(0f, 1f)]
        [Tooltip("Marge avant le max dans laquelle le véhicule est considéré en drift")]
        public float driftMargin;

        [Header("Valeurs max et min")]
        [Tooltip("Y minimum des palettes")]
        public float palettesMinimumPosition;
        [Tooltip("Y maximum des palettes")]
        public float palettesMaximumPosition;
        [Tooltip("Rotation maximale du transpalette")]
        public float transpaletteMaximumRotation;
        [Tooltip("Tilt maximal du transpalette")]
        public float transpaletteMaximumTilt;


        [Space(10)]
        [Header("Links à faire")]
        public GameObject palettes;
        public ParticleSystem leftWheelParticles;
        public ParticleSystem rightWheelParticles;

        float transpaletteMinimumRotation;
        float transpaletteMinimumTilt;

        float timeDrifting;
        float paletteVelocity;
        float maximumX;
        float xOffset;
        float xFactor;
        float zAngle;

        ParticleSystem.EmissionModule leftWheelEmission;
        ParticleSystem.TrailModule leftWheelTrails;
        ParticleSystem.EmissionModule rightWheelEmission;
        ParticleSystem.TrailModule rightWheelTrails;
        #endregion

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            xFactor = transpaletteMaximumRotation / transpaletteMaximumTilt;
            maximumX = transpaletteMaximumTilt - driftMargin;
            transpaletteMinimumRotation = -transpaletteMaximumRotation;
            transpaletteMinimumTilt = -transpaletteMaximumTilt;
            leftWheelEmission = leftWheelParticles.emission;
            leftWheelTrails = leftWheelParticles.trails;
            rightWheelEmission = rightWheelParticles.emission;
            rightWheelTrails = rightWheelParticles.trails;
        }

        private void Update()
        {
            zAngle = transform.localEulerAngles.z;
            zAngle = (zAngle > 180) ? zAngle - 360 : zAngle;
            xOffset = -zAngle/xFactor;
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

            Move();
            
        }

        public void Turn()
        {
            if (Input.GetAxis("Mouse X") < 0 && zAngle < transpaletteMaximumRotation)
            {
                transform.Rotate(new Vector3(0, 0, turningSpeed * -Input.GetAxis("Mouse X")));
            }

            else if (Input.GetAxis("Mouse X") > 0 && zAngle > transpaletteMinimumRotation)
            {
                transform.Rotate(new Vector3(0, 0, turningSpeed * -Input.GetAxis("Mouse X")));
            }
        }

        public void UpdatePalette()
        {
            palettes.transform.localPosition += new Vector3(0, Input.GetAxis("Mouse Y") * paletteSpeed, 0);
            palettes.transform.localPosition = new Vector3(0, Mathf.Clamp(palettes.transform.localPosition.y, palettesMinimumPosition, palettesMaximumPosition), 0);
        }

        public void Move()
        {
            transform.position = new Vector3(Mathf.Clamp(xOffset, transpaletteMinimumTilt, transpaletteMaximumTilt), 0,transform.position.z + speed);

            if (transform.position.x >= maximumX || transform.position.x <= -maximumX)
            {
                Drift();
            }

            else
            {
                timeDrifting = 0;
                rightWheelEmission.rateOverTime = 0;
                leftWheelEmission.rateOverTime = 0;
                if (rightWheelParticles.particleCount == 0)
                {
                    rightWheelTrails.colorOverTrail = particlesGradient.Evaluate(0);
                }

                if (leftWheelParticles.particleCount == 0)
                {
                    leftWheelTrails.colorOverTrail = particlesGradient.Evaluate(0);
                }
            }
        } 

        public void Drift()
        {
            timeDrifting += Time.deltaTime;
            if (timeDrifting >= timeBeforeDriftingOut)
            {
                Debug.Log("Et c'est un out");
            }

            if (xOffset > 0)
            {
                rightWheelEmission.rateOverTime = particlesAC.Evaluate((Mathf.InverseLerp(0, timeBeforeDriftingOut, timeDrifting))) * particlesMultiplier * xOffset;
                rightWheelTrails.colorOverTrail = particlesGradient.Evaluate((Mathf.InverseLerp(0, timeBeforeDriftingOut, timeDrifting)));
            }

            else if (xOffset < 0)
            {
                leftWheelEmission.rateOverTime = particlesAC.Evaluate((Mathf.InverseLerp(0, timeBeforeDriftingOut, timeDrifting)))* particlesMultiplier * -xOffset;
                leftWheelTrails.colorOverTrail = particlesGradient.Evaluate((Mathf.InverseLerp(0, timeBeforeDriftingOut, timeDrifting)));
            }
            
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name.Contains("Wall"))
            {
                speed = 0f;
                Debug.Log("Loose !");
            }
        }
    }
}
