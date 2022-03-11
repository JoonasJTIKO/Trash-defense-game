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
            gameObject.GetComponent<turretPlace>().placeTurret();
        }
    }
}
