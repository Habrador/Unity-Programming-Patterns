using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool.Gun
{
    //Has to inherit from MonoBehaviour so we can use Instantiate()
    public class BulletObjectPoolOptimized : MonoBehaviour
    {
        //The bullet prefab we instantiate
        public MoveBulletOptimized bulletPrefab;

        //Store the pooled bullets here
        //Instead of GameObject, use MoveBulletOptimized so we dont need a million GetComponent because we need access to that script
        private List<MoveBulletOptimized> bullets = new List<MoveBulletOptimized>();

        //How many bullets do we start with when the game starts
        private const int INITIAL_POOL_SIZE = 10;

        //Sometimes it can be good to put a limit to how many bullets we can isntantiate or we might get millions of them
        private const int MAX_POOL_SIZE = 20;

        //First available bullet, so we don't have to search a list to find it
        //Instead we create a linked-list where all unused bullets are linked together
        private MoveBulletOptimized firstAvailable;


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


            //Create the linked-list
            firstAvailable = bullets[0];

            //Each bullet points to the next
            for (int i = 0; i < bullets.Count - 1; i++)
            {
                bullets[i].next = bullets[i + 1];
            }

            //The last one terminates the linked-list
            bullets[bullets.Count - 1].next = null;
        }


        //Generate a single new bullet and put it in the list
        private void GenerateBullet()
        {
            MoveBulletOptimized newBullet = Instantiate(bulletPrefab, transform);

            newBullet.gameObject.SetActive(false);

            bullets.Add(newBullet);

            //The bullet needs a reference to this object pool so we can fix the linked list when its deactivated
            newBullet.objectPool = this;
        }


        //A bullet has been deactivated so we need to add it to the linked list
        public void ConfigureDeactivatedBullet(MoveBulletOptimized deactivatedObj)
        {
            //Add it as the first in the linked list so we don't have to check if the first is null
            deactivatedObj.next = firstAvailable;

            firstAvailable = deactivatedObj;
        }


        //Try to get a bullet
        public GameObject GetBullet()
        {
            //Instead of searching a list to find an inactive object, we simply get the firstAvilable object
            if (firstAvailable == null)
            {
                //We are out of bullets so we have to instantiate another bullet (if we can)
                if (bullets.Count < MAX_POOL_SIZE)
                {
                    GenerateBullet();

                    //The new bullet is last in the list so get it
                    MoveBulletOptimized lastBullet = bullets[bullets.Count - 1];

                    //Add it to the linked list by reusing the method we use for deactivated bullets, so it will now be the first bullet in the linked-list
                    ConfigureDeactivatedBullet(lastBullet);
                }
                else
                {
                    return null;
                }
            }

            //Remove it from the linked-list
            MoveBulletOptimized newBullet = firstAvailable;

            firstAvailable = newBullet.next;

            return newBullet.gameObject;
        }
    }
}
