using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool.Gun
{
    public class MoveBullet : BulletBase
    {
        void Update()
        {
            MoveBullet();
            
            //Deactivate the bullet when it's far away
            if (IsBulletDead())
            {
                gameObject.SetActive(false);
            }
        }
    }
}
