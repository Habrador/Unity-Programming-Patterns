using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool.Gun
{
    //Parent object pool class to avoid code duplication
    public class ObjectPoolBase : MonoBehaviour
    {
        //How many bullets do we start with when the game starts
        protected const int INITIAL_POOL_SIZE = 10;

        //Sometimes it can be good to put a limit to how many bullets we can instantiate or we might get millions of them
        protected const int MAX_POOL_SIZE = 20;
    }
}