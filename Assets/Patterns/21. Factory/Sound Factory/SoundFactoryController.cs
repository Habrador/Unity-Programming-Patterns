using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory.SoundFactory;


//Example of Factory programming pattern from "Game Programming Gems 2:" 1.3 Programming with abstract interfaces
public class SoundFactoryController : MonoBehaviour
{
    private void Start()
    {
        ISoundSystem soundSystemSoftware = SoundSystemFactory.CreateSoundSystem(SoundSystemFactory.SoundSystemType.SoundSoftware);

        soundSystemSoftware.PlaySound(1);

        ISoundSystem soundSystemHardware = SoundSystemFactory.CreateSoundSystem(SoundSystemFactory.SoundSystemType.SoundHardware);

        soundSystemHardware.PlaySound(2);

        ISoundSystem soundSystemOther = SoundSystemFactory.CreateSoundSystem(SoundSystemFactory.SoundSystemType.SoundSomethingElse);

        soundSystemOther.PlaySound(3);

        soundSystemSoftware.StopSound(1);
        soundSystemHardware.StopSound(2);
        soundSystemOther.StopSound(3);
    }
}
