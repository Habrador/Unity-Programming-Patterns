using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool.Gun
{
    public class MoveBulletOptimized : MonoBehaviour
    {
        private float bulletSpeed = 10f;

        private float deactivationDistance = 30f;

        //Needed to optimize object pooling
        [System.NonSerialized] public MoveBulletOptimized next;
        //Instead of using this dependency you could use the Observer pattern because other things may happen when the bullet dies
        [System.NonSerialized] public BulletObjectPoolOptimized objectPool;


        void Update()
        {        
            transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

            //Deactivate the bullet when it's far away
            if (Vector3.SqrMagnitude(transform.position) > deactivationDistance * deactivationDistance)
            {
                //In the optimized version, we have to tell the object pool that this bullet has been deactivated
                objectPool.ConfigureDeactivatedBullet(this);

                gameObject.SetActive(false);
            }
        }
    }
}
