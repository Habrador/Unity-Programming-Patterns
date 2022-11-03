using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory.SoundFactory
{
    public interface ISoundSystem
    {
        public bool PlaySound(int soundId);

        public bool StopSound(int soundId);

    }
}