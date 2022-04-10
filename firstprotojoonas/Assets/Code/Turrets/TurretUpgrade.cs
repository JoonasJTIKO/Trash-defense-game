using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class TurretUpgrade : MonoBehaviour
    {
        private turretShoot turret;

        [SerializeField]
        private string stat;

        private MoneyUI moneyUI;
        private TurretDestroy destroy;

        [SerializeField]
        private int maxUpgrades = 1;

        [SerializeField]
        private float price;

        void Awake()
        {
            turret = GetComponentInParent<turretShoot>();
            moneyUI = FindObjectOfType<MoneyUI>();
            destroy = GetComponentInParent<TurretDestroy>();
        }

        public void Upgrade()
        {
            if(maxUpgrades > 0 && moneyUI.CurrentMoney >= price)
            {
                turret.UpgradeStat(stat);
                moneyUI.SetMoney(price);
                destroy.refundAmount += price;
                maxUpgrades--;
            }
        }
    }
}
