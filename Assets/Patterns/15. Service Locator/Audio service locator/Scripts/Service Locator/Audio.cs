using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator.AudioService
{
    //Service provider parent class
    //This is the abstract class that determines which methods the service will be exposing
    public abstract class Audio 
    {
        public abstract void PlaySound(int soundID);

        public abstract void StopSound(int soundID);

        public abstract void StopAllSounds();
    }
}
