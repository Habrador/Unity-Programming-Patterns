using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator.AudioService
{
    //Implementation of the Service Locator example from the book Game Programming Patters
    //This class used to test that the implementation is working
    public class GameController : MonoBehaviour
    {

        void Start()
        {
            //Register the service provider in the Locator
            ConsoleAudio audio = new ConsoleAudio();

            Locator.Provide(audio);
            //Locator.Provide(null);
        }


        void Update()
        {
            Audio audio = Locator.GetAudio();

            if (Input.GetKeyDown(KeyCode.P))
            {
                audio.PlaySound(23);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                audio.StopSound(23);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                audio.StopAllSounds();
            }
        }
    }
}
