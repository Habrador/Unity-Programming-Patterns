using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator.AudioService
{
    //This is the service locator
    public class Locator
    {
        private static NullAudio nullService;
    
        private static Audio service;


        static Locator()
        {
            nullService = new NullAudio();

            //Init with null in case we forget to inject a reference to Audio
            service = nullService;
        }
        

        //Does the locating
        public static Audio GetAudio()
        {        
            return service;
        }
        

        //Use dependency injection to get a reference to the audio service we need
        //Call this method before you do anything else with the audio
        public static void Provide(Audio _service)
        {
            //Sometimes we want to set it to null if we want to disable audio in the game
            if (_service == null)
            {
                service = nullService;
            }
            else
            {
                service = _service;
            }
        }
    }
}
