using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class MuteUnmute : MonoBehaviour
    {
        private bool muted;

        void Awake()
        {
            if(AudioListener.volume == 1)
            {
                muted = false;
            }
            else if(AudioListener.volume == 0)
            {
                muted = true;
            }
        }
        public void ChangeState()
        {
            if(muted)
            {
                AudioListener.volume = 1;
                muted = false;
            }
            else if(!muted)
            {
                AudioListener.volume = 0;
                muted = true;
            }
            Debug.Log(AudioListener.volume);
        }
    }
}
