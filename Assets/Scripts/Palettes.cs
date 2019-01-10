using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP16.JandB
{
    public class Palettes : MonoBehaviour {
        public AnimationCurve palettesSoundCurve;
        public AnimationCurve smoothDelta;
        public AnimationCurve rawDelta;
        public float smoothTime;
        float timeElapsed;
        public AudioSource palettesSource;
        float positionDeltaSinceLastFrame;
        float smoothPositionDelta;
        Vector3 positionLastFrame;
        Vector3 actualPosition;
        private void Update()
        {
            timeElapsed += Time.deltaTime;
            actualPosition = transform.localPosition;
            positionDeltaSinceLastFrame = actualPosition.y - positionLastFrame.y;
            smoothPositionDelta += positionDeltaSinceLastFrame;
            smoothDelta.AddKey(Time.time, smoothPositionDelta*2);
            rawDelta.AddKey(Time.time, positionDeltaSinceLastFrame);
            positionLastFrame = transform.localPosition;
            palettesSource.volume = palettesSoundCurve.Evaluate(Mathf.Clamp(smoothPositionDelta*10, -1, 1));
            palettesSource.pitch = 1 * Mathf.Sign(smoothPositionDelta);
            if (timeElapsed > smoothTime)
            {
                timeElapsed = 0;
                smoothPositionDelta = 0;
            }
        }

    }
}