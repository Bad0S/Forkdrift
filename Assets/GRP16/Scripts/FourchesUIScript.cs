using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP16.JandB
{
    public class FourchesUIScript : MonoBehaviour
    {
        [Header("Liens à faire")]
        public GameObject fourches;
        public Image fourchesUI;
        public Image verticalBarUI;
        public Image pickupUI;
        public Color pickable;
        public Color notPickable;
        public Image warningSign;
        public PickUpItem tutoPickupItem;

        #region privateVariables
        Vector3 posFourchesUIStart;
        PickUpItem itemPicked;
        float maxFourchesPosUI;
        float minFourchesPosUI;
        float FourchesPosUI;
        float pickupPosUI;
        float minFourchesPosGo;
        float maxFourchesPosGo;
        public bool pickup;
        Vector3 pickupPos;
        #endregion

        void Start()
        {
            posFourchesUIStart = fourchesUI.rectTransform.localPosition;
            FourchesPosUI = posFourchesUIStart.y;
            minFourchesPosUI = verticalBarUI.rectTransform.localPosition.y - verticalBarUI.rectTransform.rect.height / 2 + fourchesUI.rectTransform.rect.height / 2;
            maxFourchesPosUI = verticalBarUI.rectTransform.localPosition.y + verticalBarUI.rectTransform.rect.height / 2 - fourchesUI.rectTransform.rect.height / 2;
            minFourchesPosGo = fourches.GetComponentInParent<Transpalette>().palettesMinimumPosition;
            maxFourchesPosGo = fourches.GetComponentInParent<Transpalette>().palettesMaximumPosition;
            tutoPickupItem.PoolPickup();
        }

        void Update()
        {
            FourchesPosUI = Mathf.InverseLerp(minFourchesPosGo, maxFourchesPosGo, fourches.transform.localPosition.y);

            fourchesUI.rectTransform.localPosition = new Vector3(posFourchesUIStart.x, Mathf.Lerp(minFourchesPosUI, maxFourchesPosUI, FourchesPosUI), posFourchesUIStart.z);

            if (pickup)
            {
                if (fourchesUI.rectTransform.localPosition.y > pickupUI.rectTransform.localPosition.y)
                {
                    pickupUI.color = new Color(notPickable.r, notPickable.g, notPickable.b, fourches.transform.position.z / pickupPos.z);
                    warningSign.enabled = true;
                }
                else
                {
                    pickupUI.color = new Color(pickable.r, pickable.g, pickable.b, fourches.transform.position.z / pickupPos.z);
                    warningSign.enabled = false;
                }

                if (pickupPos.z <= fourches.transform.position.z && fourchesUI.rectTransform.localPosition.y > pickupUI.rectTransform.localPosition.y)
                {
                    fourches.GetComponentInParent<Transpalette>().Crash();
                    pickup = false;
                }
                else if (pickupPos.z <= fourches.transform.position.z && fourchesUI.rectTransform.localPosition.y <= pickupUI.rectTransform.localPosition.y)
                {
                    if (Vector3.Distance(pickupPos, fourches.transform.position) <= 1)
                    {
                        StopPickUpUI();
                    }

                    else
                    {
                        fourches.GetComponentInParent<Transpalette>().Crash();
                    pickup = false;
                    }
                }
            }
        }

        public void DrawPickUpUI(Vector3 pickupHeight, PickUpItem itemToPick)
        {
            itemPicked = itemToPick;
            pickupUI.enabled = true;
            pickupPos = pickupHeight;
            pickupPosUI = Mathf.InverseLerp(minFourchesPosGo, maxFourchesPosGo, pickupHeight.y);
            pickupUI.rectTransform.localPosition = new Vector3(posFourchesUIStart.x, Mathf.Lerp(minFourchesPosUI, maxFourchesPosUI, pickupPosUI), posFourchesUIStart.z);
            pickup = true;
        }

        public void StopPickUpUI()
        {
            pickupUI.enabled = false;
            pickup = false;
            itemPicked.UnpoolPickup();
            itemPicked = null;
        }
    }
}