using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace ObjectPool.Gun
{
    public class MoveBulletUnity : BulletBase
    {
        //Ref to the object pool so we can deactivate dead bullets 
        public IObjectPool<MoveBulletUnity> objectPool;



        void Update()
        {
            MoveBullet();

            //Deactivate the bullet when it's far away
            if (IsBulletDead())
            {
                //Returns the instance to the pool
                //https://docs.unity3d.com/ScriptReference/Pool.IObjectPool_1.html
                objectPool.Release(this);
            }
        }
    }
}