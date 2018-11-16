using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP16.JandB
{
    public class FourchesUIScript : MonoBehaviour
    {
        public GameObject fourches;
        public Image fourchesUI;
        public Image verticalBarUI;

        #region privateVariables
        Vector3 posFourchesUIStart;
        float maxFourchesPosUI;
        float minFourchesPosUI;
        float FourchesPosUI;
        float minFourchesPosGo;
        float maxFourchesPosGo;
        #endregion

        void Start()
        {
            posFourchesUIStart = fourchesUI.rectTransform.localPosition;
            FourchesPosUI = posFourchesUIStart.y;
            minFourchesPosUI = verticalBarUI.rectTransform.localPosition.y - verticalBarUI.rectTransform.rect.height / 2 + fourchesUI.rectTransform.rect.height / 2;
            maxFourchesPosUI = verticalBarUI.rectTransform.localPosition.y + verticalBarUI.rectTransform.rect.height / 2 - fourchesUI.rectTransform.rect.height / 2;
            minFourchesPosGo = fourches.GetComponentInParent<Transpalette>().palettesMinimumPosition;
            maxFourchesPosGo = fourches.GetComponentInParent<Transpalette>().palettesMaximumPosition;
        }

        void Update()
        {
            FourchesPosUI = Mathf.InverseLerp(minFourchesPosGo, maxFourchesPosGo, fourches.transform.localPosition.y);
            

            fourchesUI.rectTransform.localPosition = new Vector3(posFourchesUIStart.x, Mathf.Lerp(minFourchesPosUI, maxFourchesPosUI, FourchesPosUI), posFourchesUIStart.z);
        }
    }
}