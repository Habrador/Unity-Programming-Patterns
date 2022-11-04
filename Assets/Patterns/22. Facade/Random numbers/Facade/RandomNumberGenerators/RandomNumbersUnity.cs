using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Facade.RandomNumbers
{
    //Geerate random numbers by using Unity's Random.Range
    public class RandomNumbersUnity : IRandomNumberGenerator
    {
        public float GetRandom(float min, float max)
        {
            return Random.Range(min, max);
        }

        public float GetRandom01()
        {
            return Random.Range(0f, 1f);
        }

        public int GetRandomInt(int min, int max)
        {
            return Random.Range(min, max);
        }

        public void InitSeed(int seed)
        {
            Random.InitState(seed);
        }
    }
}