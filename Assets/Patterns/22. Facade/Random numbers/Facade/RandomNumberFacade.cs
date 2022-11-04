using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Facade.RandomNumbers
{
    public class RandomNumberFacade
    {
        private static IRandomNumberGenerator rng;


        static RandomNumberFacade()
        {
            //The only line of code you need to change if you want to test different random number generators
            //rng = new RandomNumbersNative();
            rng = new RandomNumbersUnity();
        }


        public static void InitSeed(int seed)
        {
            rng.InitSeed(seed);
        }


        public static float GetRandom01()
        {
            return rng.GetRandom01();
        }


        public static float GetRandom(float min, float max)
        {
            return rng.GetRandom(min, max);
        }


        public static int GetRandomInt(int min, int max)
        {
            return rng.GetRandomInt(min, max);
        }
    }
}