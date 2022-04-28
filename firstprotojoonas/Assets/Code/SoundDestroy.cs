using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class SoundDestroy : MonoBehaviour
    {
        private AudioSource source;
        private float lifetime;

        void Awake()
        {
            source = GetComponent<AudioSource>();
            lifetime = source.clip.length;
        }

        // destroys the object after the audio clip has finished playing
        void Update()
        {
            if(lifetime <= 0)
            {
                Destroy(this.gameObject);
            }
            lifetime -= Time.deltaTime;
            Debug.Log(lifetime);
        }
    }
}
