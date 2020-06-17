using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator.AudioService
{
    //Service provider child class
    public class ConsoleAudio : Audio
    {
        public override void PlaySound(int soundID)
        {
            Debug.Log($"Sound {soundID} has started");
        }

        public override void StopSound(int soundID)
        {
            Debug.Log($"Sound {soundID} has stopped");
        }

        public override void StopAllSounds()
        {
            Debug.Log($"All sounds have stopped");
        }
    }
}
