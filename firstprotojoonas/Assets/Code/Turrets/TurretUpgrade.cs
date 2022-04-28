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

        [SerializeField]
        private GameObject particle;

        private Color tmp;

        void Awake()
        {
            tmp = GetComponent<SpriteRenderer>().color;
            turret = GetComponentInParent<turretShoot>();
            moneyUI = FindObjectOfType<MoneyUI>();
            destroy = GetComponentInParent<TurretDestroy>();
        }

        // changes appearance of button based on if player has enough money to upgrade
        void Update()
        {
            if(maxUpgrades > 0 && moneyUI.CurrentMoney >= price)
            {
                tmp.a = 1F;
                GetComponent<SpriteRenderer>().color = tmp;
            }
            if (maxUpgrades <= 0 || moneyUI.CurrentMoney < price)
            {
                tmp.a = 0.7f;
                GetComponent<SpriteRenderer>().color = tmp;
            }
        }

        // if player can afford upgrade, upgrades the correct stat, takes money, adds money to amount refunded if tower is destroyed and plays particle effect with sound
        public void Upgrade()
        {
            if (maxUpgrades > 0 && moneyUI.CurrentMoney >= price)
            {
                turret.UpgradeStat(stat);
                moneyUI.SetMoney(price);
                destroy.refundAmount += price;
                maxUpgrades--;
                Instantiate(particle, transform.position, transform.rotation);
            }
        }
    }
}
