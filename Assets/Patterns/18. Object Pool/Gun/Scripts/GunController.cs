using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool.Gun
{
    public class GunController : MonoBehaviour
    {
        //Pick which object pool you want to use
        public BulletObjectPool bulletPool;

        //public BulletObjectPoolOptimized bulletPool;


        //Private
        private float rotationSpeed = 60f;

        private float fireTimer;

        private float fireInterval = 0.1f;



        void Start()
        {
            fireTimer = Mathf.Infinity;

            if (bulletPool == null)
            {
                Debug.LogError("Need a reference to the object pool");
            }
        }



        void Update()
        {
            //Rotate gun
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }


            //Fire gun
            if (Input.GetKey(KeyCode.Space) && fireTimer > fireInterval)
            {
                fireTimer = 0f;

                GameObject newBullet = GetABullet();

                if (newBullet != null)
                {
                    newBullet.SetActive(true);

                    newBullet.transform.forward = transform.forward;

                    //Move the bullet to the tip of the gun or it will look strange if we rotate while firing
                    newBullet.transform.position = transform.position + transform.forward * 2f;
                }
                else
                {
                    Debug.Log("Couldn't find a new bullet");
                }
            }


            //Update the time since we last fired a bullet
            fireTimer += Time.deltaTime;
        }



        private GameObject GetABullet()
        {
            GameObject bullet = bulletPool.GetBullet();

            return bullet;
        }
    }
}
