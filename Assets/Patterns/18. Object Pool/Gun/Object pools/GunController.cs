using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ObjectPool.Gun
{
    public class GunController : MonoBehaviour
    {
        //Pick which object pool you want to use by activating it in the hierarchy and drag it to its uncommented slot 
        
        //Simplest possible object pool
        //public BulletObjectPoolSimple bulletPool;

        //Optimized object pool
        //public BulletObjectPoolOptimized bulletPool;

        //Unity's native object pool
        public BulletObjectPoolUnity bulletPool; 


        //Private
        private readonly float rotationSpeed = 60f;

        private float fireTimer;

        private readonly float fireInterval = 0.1f;



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
            //Rotate gun with A and D keys
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }


            //Fire gun with spacebar
            if (Input.GetKey(KeyCode.Space) && fireTimer > fireInterval)
            {
                fireTimer = 0f;

                GameObject newBullet = bulletPool.GetBullet();

                if (newBullet != null)
                {
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
    }
}
