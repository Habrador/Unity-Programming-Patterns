using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool.Gun
{
    //Has to inherit from MonoBehaviour so we can use Instantiate()
    public class BulletObjectPool : MonoBehaviour
    {
        //The bullet prefab we instantiate
        public GameObject bulletPrefab;
        
        //Store the pooled bullets here
        private List<GameObject> bullets = new List<GameObject>();

        //How many bullets do we start with when the game starts
        private const int INITIAL_POOL_SIZE = 10;

        //Sometimes it can be good to put a limit to how many bullets we can isntantiate or we might get millions of them
        private const int MAX_POOL_SIZE = 20;


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
            GameObject newBullet = Instantiate(bulletPrefab, transform);

            newBullet.SetActive(false);

            bullets.Add(newBullet);
        }


        //Try to get a bullet
        public GameObject GetBullet()
        {
            //Try to find an inactive bullet
            for (int i = 0; i < bullets.Count; i++)
            {
                GameObject thisBullet = bullets[i];

                if (!thisBullet.activeInHierarchy)
                {                
                    return thisBullet;
                }
            }

            //We are out of bullets so we have to instantiate another bullet (if we can)
            if (bullets.Count < MAX_POOL_SIZE)
            {
                GenerateBullet();

                //The new bullet is last in the list so get it
                GameObject lastBullet = bullets[bullets.Count - 1];

                return lastBullet;
            }

            return null;
        }
    }
}
