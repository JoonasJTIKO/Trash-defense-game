using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class ResetScene : MonoBehaviour
    {
        private MoneyUI ui;
        public void resetScene()
        {
            ui = FindObjectOfType<MoneyUI>();
            //Dumb but should work
            ui.AddMoney(1000 - ui.CurrentMoney);
        }
    }
}
