using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace towerdefense
{
    public class Selectable : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("click");
            if(gameObject.tag == "PlacePoint")
            {
                gameObject.GetComponent<turretPlace>().placeTurret();
            }
            else if(gameObject.tag == "turretMenu")
            {
                gameObject.GetComponent<TurretMenu>().OpenMenu();
            }
            else if(gameObject.tag == "DestroyTurret")
            {
                gameObject.GetComponentInParent<TurretDestroy>().Destroy();
            }
            else if(gameObject.tag == "UpgradeTurret")
            {
                gameObject.GetComponent<TurretUpgrade>().Upgrade();
            }
        }
    }
}
