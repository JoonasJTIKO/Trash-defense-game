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

        [SerializeField]
        private int maxUpgrades = 1;

        void Awake()
        {
            turret = GetComponentInParent<turretShoot>();
        }

        public void Upgrade()
        {
            if(maxUpgrades > 0)
            {
                turret.UpgradeStat(stat);
                maxUpgrades++;
            }
        }
    }
}
