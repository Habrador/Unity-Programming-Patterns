using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool.Gun
{
    //Parent object pool class to avoid code duplication
    //You can make a reusable GameObject pool without MonoBehaviour because you can call Object.Instantiate - you just have to pass a prefab GameObject to it on creation. But that could be in a parent class or a pool manager MonoBehaviour.
    public class ObjectPoolBase : MonoBehaviour
    {
        //How many bullets do we start with when the game starts
        protected const int INITIAL_POOL_SIZE = 10;

        //Sometimes it can be good to put a limit to how many bullets we can instantiate or we might get millions of them
        protected const int MAX_POOL_SIZE = 20;
    }
}