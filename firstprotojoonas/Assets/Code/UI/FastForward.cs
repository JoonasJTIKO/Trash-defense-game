using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class FastForward : MonoBehaviour
    {
        private bool speedIsNormal = true;
        public void ChangeSpeed()
        {
            if(speedIsNormal == true)
            {
                Time.timeScale = 2;
                speedIsNormal = false;
            }
            else if(speedIsNormal == false)
            {
                Time.timeScale = 1;
                speedIsNormal = true;
            }
        }

        public void Reset()
        {
            Time.timeScale = 1;
            speedIsNormal = true;
        }
    }
}

