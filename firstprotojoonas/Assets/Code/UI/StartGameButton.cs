using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class StartGameButton : MonoBehaviour
    {
        private bool firstRound = true;

        [SerializeField]
        private GameObject startButton;

        void OnDisable()
        {
            firstRound = false;
        }

        void OnEnable()
        {
            if(!firstRound)
            {
                startButton.SetActive(true);
            }
        }
    }
}
