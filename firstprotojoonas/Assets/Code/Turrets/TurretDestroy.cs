using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class TurretDestroy : MonoBehaviour
    {
        private GameObject usedTurretPoints;

        private GameObject turretPoints;

        private MoneyUI moneyUI;

        private Transform parent;

        [SerializeField]
        public float refundAmount;

        void Awake()
        {
            usedTurretPoints = GameObject.Find("UsedTurretPoints");
            turretPoints = GameObject.Find("TurretPoints");
            parent = this.transform.parent;
            moneyUI = FindObjectOfType<MoneyUI>();
        }
        public void Destroy()
        {
            foreach(Transform item in usedTurretPoints.transform)
            {
                if(item.transform.position == new Vector3(parent.transform.position.x, parent.transform.position.y, -0.1F))
                {
                    item.SetParent(turretPoints.transform);
                }
            }
            moneyUI.AddMoney(refundAmount);
            Destroy(this.transform.parent.gameObject);
        }
    }
}
