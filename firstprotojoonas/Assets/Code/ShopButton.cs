using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace towerdefense
{
    public class ShopButton : MonoBehaviour
    {
        [SerializeField]
        private float price;

        [SerializeField]
        private MoneyUI ui;

        [SerializeField]
        private TMP_Text priceText;

        void Update()
        {
            priceText.text = price.ToString();
            if(price > ui.CurrentMoney && gameObject.GetComponent<Button>().enabled == true)
            {
                gameObject.GetComponent<Button>().enabled = false;
            }
        }
    }
}
