using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class AudioSortingScene : MonoBehaviour
    {
        public AudioClip correctTrash;
        public AudioClip wrongTrash;
        public AudioClip pickupTrash;
        private AudioSource audioSrc;
        void Start()
        {
            audioSrc = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        public void playCorrectTrash()
        {
            audioSrc.PlayOneShot(correctTrash);
        }

        public void playWrongTrash()
        {
            audioSrc.PlayOneShot(wrongTrash);
        }

        public void playPickupTrash()
        {
            audioSrc.PlayOneShot(pickupTrash);
        }
    }
}
