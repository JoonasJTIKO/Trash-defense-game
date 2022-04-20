using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class Delete : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(this.gameObject);
        }
    }
}
