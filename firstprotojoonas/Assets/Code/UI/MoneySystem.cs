using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class MoneySystem : MonoBehaviour
    {
        private static MoneySystem current;
        public static MoneySystem Current
        {
            get {return current; }
        }

        private MoneyUI ui;

        public void SetMoney(float amount)
        {
            ui.SetMoney(amount);
        }

        void Start()
        {
            ui = FindObjectOfType<MoneyUI>();
        }


        void Awake()
        {
            current = this;
        }
    }
}
