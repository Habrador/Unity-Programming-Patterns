using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator.AudioService
{
    //Service provider child class
    //Used if the service locator hasnt been given a reference to a service provider or if we dont want to play audio
    public class NullAudio : Audio
    {
        public override void PlaySound(int soundID)
        {
            Debug.Log("Do nothing");
        }

        public override void StopSound(int soundID)
        {
            Debug.Log("Do nothing");
        }

        public override void StopAllSounds()
        {
            Debug.Log("Do nothing");
        }
    }
}
