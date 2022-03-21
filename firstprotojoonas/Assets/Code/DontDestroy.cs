using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class DontDestroy : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
