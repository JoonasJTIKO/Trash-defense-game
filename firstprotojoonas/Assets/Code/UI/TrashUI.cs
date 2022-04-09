using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace towerdefense
{
    public class TrashUI : MonoBehaviour
    {
        public static int paperAmount;

        [SerializeField]
        private TMP_Text paperText;
        public static int cardboardAmount;

        [SerializeField]
        private TMP_Text cardboardText;
        public static int plasticAmount;

        [SerializeField]
        private TMP_Text plasticText;
        public static int metalAmount;

        [SerializeField]
        private TMP_Text metalText;

        public void AddAmount(int amount, string type)
        {
            if(type == "Cardboard")
            {
                cardboardAmount++;
            }
            else if(type == "Metal")
            {
                metalAmount++;
            }
            else if(type == "Plastic")
            {
                plasticAmount++;
            }
            else if(type == "Paper")
            {
                paperAmount++;
            }
            else
            {
                Debug.Log("Enemy does not have type, or type has not been added to counter");
            }
            this.updateText();
        }

        public void Reset()
        {
            paperAmount = 0;
            cardboardAmount = 0;
            plasticAmount = 0;
            metalAmount = 0;
            this.updateText();
        }

        public void reduceByOne(string type)
        {
            switch(type)
            {
                case "paper":
                    paperAmount--;
                    break;
                case "cardboard":
                    cardboardAmount--;
                    break;
                case "bio":
                    metalAmount--;
                    break;
                case "plastic":
                    plasticAmount--;
                    break;
            }

            this.updateText();
        }

        private void updateText()
        {
            metalText.text = metalAmount.ToString();
            plasticText.text = plasticAmount.ToString();
            cardboardText.text = cardboardAmount.ToString();
            paperText.text = paperAmount.ToString();
        }
    }
}
