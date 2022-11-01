using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool.Gun
{
    public class MoveBulletOptimized : BulletBase
    {
        //Needed to optimize object pooling
        [System.NonSerialized] public MoveBulletOptimized next;
        //Instead of using this dependency you could use the Observer pattern because other things may happen when the bullet dies
        [System.NonSerialized] public BulletObjectPoolOptimized objectPool;


        void Update()
        {
            MoveBullet();

            //Deactivate the bullet when it's far away
            if (IsBulletDead())
            {
                //In the optimized version, we have to tell the object pool that this bullet has been deactivated
                objectPool.ConfigureDeactivatedBullet(this);

                gameObject.SetActive(false);
            }
        }
    }
}
