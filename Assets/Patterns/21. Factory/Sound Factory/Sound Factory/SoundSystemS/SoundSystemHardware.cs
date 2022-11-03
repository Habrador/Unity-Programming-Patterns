using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory.SoundFactory
{
    public class SoundSystemHardware : ISoundSystem
    {
        public bool PlaySound(int soundId)
        {
            Debug.Log($"Played the sound with id {soundId} on the hardware");

            return true;
        }

        public bool StopSound(int soundId)
        {
            Debug.Log($"Stopped the sound with id {soundId} on the hardware");

            return true;
        }
    }
}