using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Facade.RandomNumbers
{
    //This is the Adapter pattern to easier work with the Facade
    public interface IRandomNumberGenerator
    {
        public void InitSeed(int seed);

        public float GetRandom01();

        public float GetRandom(float min, float max);

        public int GetRandomInt(int min, int max);
    }
}