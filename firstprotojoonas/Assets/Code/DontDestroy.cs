using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class DontDestroy : MonoBehaviour
    {
        public static DontDestroy instance;
        void Awake()
        {
            if (instance == null) 
            {
                instance = this;
            } else if (instance != this)
            {
                Destroy (gameObject);
            }
 
            DontDestroyOnLoad (gameObject);
        }
    }
}
