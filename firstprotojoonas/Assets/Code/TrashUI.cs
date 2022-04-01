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
        public static int bioAmount;

        [SerializeField]
        private TMP_Text bioText;

        public void AddAmount(int amount, string type)
        {
            if(type == "Cardboard")
            {
                cardboardAmount++;
            }
            else if(type == "Bio")
            {
                bioAmount++;
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
            bioAmount = 0;
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
                    bioAmount--;
                    break;
                case "plastic":
                    plasticAmount--;
                    break;
            }

            this.updateText();
        }

        private void updateText()
        {
            bioText.text = bioAmount.ToString();
            plasticText.text = plasticAmount.ToString();
            cardboardText.text = cardboardAmount.ToString();
            paperText.text = paperAmount.ToString();
        }
    }
}
