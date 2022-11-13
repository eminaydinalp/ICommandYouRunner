using System;
using UnityEngine;

namespace _Game.Scripts.Concretes.Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        
        [SerializeField] private AudioSource[] audioSources;
        
        
        private void Awake()
        {
            Instance = this;
        }

        private void OnValidate()
        {
            audioSources = GetComponentsInChildren<AudioSource>();
        }


        public void PlaySound(int index)
        {
            if (!audioSources[index].isPlaying)
            {
                audioSources[index].Play();
            }
        }
        
        public void StopSound(int index)
        {
            if (audioSources[index].isPlaying)
            {
                audioSources[index].Stop();
            }
        }
    }
}