using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class FastForward : MonoBehaviour
    {
        private bool speedIsNormal = true;
        
        // sets game speed to double if normal and back to normal if double
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

        
        // sets game speed to normal
        public void Reset()
        {
            Time.timeScale = 1;
            speedIsNormal = true;
        }
    }
}

