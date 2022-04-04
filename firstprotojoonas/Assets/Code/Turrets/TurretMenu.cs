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
        public void OpenMenu()
        {
            if(!menuActive)
            {
                openedMenu = Instantiate(menu, new Vector3(transform.position.x, transform.position.y + 1.5F, 1), Quaternion.Euler(0, 0, 0), transform);
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
