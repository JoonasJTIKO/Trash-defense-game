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

        private MoneyUI ui;

        [SerializeField]
        private TMP_Text priceText;

        void Start()
        {
            ui = FindObjectOfType<MoneyUI>();
        }
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
