using System;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class ServiceSound : MonoBehaviour
    {
        private static ServiceSound instance;
        private AudioSource audioSource;
        public static ServiceSound Instance
        {
            get
            {
                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
            else
                Destroy(this.gameObject);

            audioSource = GetComponent<AudioSource>();
        }

        public void PlayClip(AudioClip audioClip)
        {
            audioSource.Stop();
            audioSource.clip = audioClip;
            audioSource.PlayDelayed(1);
        }
        public void StopCurrentClip()
        {
            audioSource.Stop();
        }
    }
}