using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace towerdefense
{
    public class TrashUI : MonoBehaviour
    {
        private int paperAmount;

        [SerializeField]
        private TMP_Text paperText;
        private int cardboardAmount;

        [SerializeField]
        private TMP_Text cardboardText;
        private int plasticAmount;

        [SerializeField]
        private TMP_Text plasticText;
        private int bioAmount;

        [SerializeField]
        private TMP_Text bioText;

        public void AddAmount(int amount, string type)
        {
            if(type == "Cardboard")
            {
                cardboardAmount++;
                cardboardText.text = cardboardAmount.ToString();
            }
            else if(type == "Bio")
            {
                bioAmount++;
                bioText.text = bioAmount.ToString();
            }
            else if(type == "Plastic")
            {
                plasticAmount++;
                plasticText.text = plasticAmount.ToString();
            }
            else if(type == "Paper")
            {
                paperAmount++;
                paperText.text = paperAmount.ToString();
            }
            else
            {
                Debug.Log("Enemy does not have type, or type has not been added to counter");
            }
        }

        public void Reset()
        {
            paperAmount = 0;
            cardboardAmount = 0;
            plasticAmount = 0;
            bioAmount = 0;
        }
    }
}
