using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool.Gun
{
    //Simplest possible object pool
    public class BulletObjectPoolSimple : ObjectPoolBase
    {
        //The bullet prefab we instantiate
        public MoveBullet bulletPrefab;

        //Store the pooled bullets here
        private readonly List<GameObject> bullets = new ();

        

        private void Start()
        {
            if (bulletPrefab == null)
            {
                Debug.LogError("Need a reference to the bullet prefab");
            }

            //Instantiate new bullets and put them in a list for later use
            for (int i = 0; i < INITIAL_POOL_SIZE; i++)
            {
                GenerateBullet();
            }
        }



        //Generate a single new bullet and put it in list
        private void GenerateBullet()
        {
            GameObject newBullet = Instantiate(bulletPrefab.gameObject, transform);

            newBullet.SetActive(false);

            bullets.Add(newBullet);
        }



        //Get a bullet from the pool
        public GameObject GetBullet()
        {
            //Try to find an inactive bullet
            foreach (GameObject bullet in bullets)
            {
                if (!bullet.activeInHierarchy)
                {
                    bullet.SetActive(true);
                
                    return bullet;
                }
            }

            //We are out of bullets so we have to instantiate another bullet (if we can)
            if (bullets.Count < MAX_POOL_SIZE)
            {
                GenerateBullet();

                //The new bullet is last in the list so get it
                GameObject lastBullet = bullets[^1];

                lastBullet.SetActive(true);

                return lastBullet;
            }

            return null;
        }
    }
}
