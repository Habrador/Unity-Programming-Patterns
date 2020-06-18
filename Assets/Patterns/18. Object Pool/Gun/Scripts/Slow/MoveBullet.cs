using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool.Gun
{
    public class MoveBullet : MonoBehaviour
    {
        private float bulletSpeed = 10f;

        private float deactivationDistance = 30f;


        void Update()
        {        
            transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

            //Deactivate the bullet when it's far away
            if (Vector3.SqrMagnitude(transform.position) > deactivationDistance * deactivationDistance)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
