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

        private Image image;

        void Start()
        {
            ui = FindObjectOfType<MoneyUI>();
            image = GetComponent<Image>();
        }
        void Update()
        {
            priceText.text = price.ToString();
            if(price > ui.CurrentMoney && gameObject.GetComponent<Button>().enabled == true)
            {
                gameObject.GetComponent<Button>().enabled = false;
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0.7F);
            }
            if(price <= ui.CurrentMoney && gameObject.GetComponent<Button>().enabled == false)
            {
                gameObject.GetComponent<Button>().enabled = true;
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1F);
            }
        }
    }
}
