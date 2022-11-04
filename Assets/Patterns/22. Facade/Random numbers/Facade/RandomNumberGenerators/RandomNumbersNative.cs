using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Facade.RandomNumbers
{
    //Generate random numbers by using C#'s System.Random
    public class RandomNumbersNative : IRandomNumberGenerator
    {
        private System.Random rng;

        public RandomNumbersNative()
        {
            rng = new System.Random();
        }

        public float GetRandom(float min, float max)
        {
            return (float)((rng.NextDouble() * (max - min)) + min);
        }

        public float GetRandom01()
        {
            return (float)rng.NextDouble();
        }

        public int GetRandomInt(int min, int max)
        {
            return rng.Next(min, max);
        }

        public void InitSeed(int seed)
        {
            rng = new System.Random(seed);
        }
    }
}