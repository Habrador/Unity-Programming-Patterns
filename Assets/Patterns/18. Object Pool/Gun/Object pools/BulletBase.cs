using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool.Gun
{
    //Parent bullet class to avoid code duplication
    public class BulletBase : MonoBehaviour
    {
        private readonly float bulletSpeed = 10f;

        private readonly float deactivationDistance = 30f;



        protected void MoveBullet()
        {
            transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward);
        }



        protected bool IsBulletDead()
        {
            bool isDead = false;
        
            //The gun is at 0
            if (Vector3.SqrMagnitude(Vector3.zero - transform.position) > deactivationDistance * deactivationDistance)
            {
                isDead = true;
            }

            return isDead;
        }
    }
}