using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class RoundStart : MonoBehaviour
    {
        public bool roundStarted = false;

        public void StartRound()
        {
            roundStarted = true;
        }

        void OnDisable()
        {
            roundStarted = false;
        }
    }
}
