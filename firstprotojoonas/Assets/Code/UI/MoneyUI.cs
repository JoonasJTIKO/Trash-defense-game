using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace towerdefense
{
    public class MoneyUI : MonoBehaviour
    {
        [SerializeField]
		private TMP_Text nameText;

        [SerializeField]
        private float currentMoney = 500;

        public float CurrentMoney
        {
            get { return currentMoney; }
        }
        
        // reduces players money by amount
        public void SetMoney(float amount)
        {
            nameText.text = (currentMoney - amount).ToString();
            currentMoney = currentMoney - amount;
        }

        
        // adds amount to players money
        public void AddMoney(float amount)
        {
            nameText.text = (currentMoney + amount).ToString();
            currentMoney = currentMoney + amount;
        }
    }
}
