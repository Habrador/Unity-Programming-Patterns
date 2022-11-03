using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory.SoundFactory
{
    public class SoundSystemFactory
    {
        public enum SoundSystemType
        {
            SoundSoftware,
            SoundHardware,
            SoundSomethingElse
        };



        public static ISoundSystem CreateSoundSystem(SoundSystemType type)
        {
            ISoundSystem soundSystem;

            switch (type)
            {
                case SoundSystemType.SoundSoftware:
                    soundSystem = new SoundSystemSoftware();
                    break;
                case SoundSystemType.SoundHardware:
                    soundSystem = new SoundSystemHardware();
                    break;
                case SoundSystemType.SoundSomethingElse:
                    soundSystem = new SoundSystemOther();
                    break;
                default:
                    soundSystem = null;
                    break;
            }

            return soundSystem;
        }
    }
}