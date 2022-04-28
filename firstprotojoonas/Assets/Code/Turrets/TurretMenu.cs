using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class TurretMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject menu;
        private bool menuActive = false;
        private GameObject openedMenu;
        
        // will open and close the turret upgrade / sell menu
        public void OpenMenu()
        {
            if(!menuActive)
            {
                openedMenu = Instantiate(menu, new Vector3(transform.position.x, transform.position.y + 1, 1), Quaternion.Euler(0, 0, 0), transform);
                menuActive = true;
            }
            else if(menuActive)
            {
                Destroy(openedMenu);
                menuActive = false;
            }
        }
    }
}
