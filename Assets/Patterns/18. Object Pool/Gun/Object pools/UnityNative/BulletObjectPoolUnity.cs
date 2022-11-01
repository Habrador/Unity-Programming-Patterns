using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


namespace ObjectPool.Gun
{
    //Unity has a native object pooling system
    //https://docs.unity3d.com/ScriptReference/Pool.IObjectPool_1.html
    //Think its still under development so has bugs
    public class BulletObjectPoolUnity : ObjectPoolBase
    {
        //The bullet prefab we instantiate
        public MoveBulletUnity bulletPrefab;

        //Unity's native object pool
        private ObjectPool<MoveBulletUnity> allBullets;



        private void Start()
        {
            if (bulletPrefab == null)
            {
                Debug.LogError("Need a reference to the bullet prefab");
            }

            //Create a new object pool
            //You can also create a LinkedPool
            allBullets = new ObjectPool<MoveBulletUnity>(
                CreatePooledItem, 
                OnTakeFromPool, 
                OnReturnedToPool, 
                OnDestroyPoolObject, 
                true, //Collection checks will throw errors if we try to release an item that is already in the pool
                INITIAL_POOL_SIZE, 
                MAX_POOL_SIZE);
        }



        private void Update()
        {
            //For some unkown reason if we can create more bullets than MAX_POOL_SIZE. When released they are counted as active but not visible, which might be a bug in Unity because Inactive is the same as MAX_POOL_SIZE so correct?
            Debug.Log($"In pool: {allBullets.CountAll}, Active: {allBullets.CountActive}, Inactive: {allBullets.CountInactive}");

            if (Input.GetKeyDown(KeyCode.K))
            {
                //These are doing the same thing for some reason...
                //allBullets.Dispose();
                allBullets.Clear();
            }
        }



        //Add a new item to the pool
        private MoveBulletUnity CreatePooledItem()
        {
            GameObject newBullet = Instantiate(bulletPrefab.gameObject, transform);

            //newBullet.SetActive(false);

            MoveBulletUnity moveBulletScript = newBullet.GetComponent<MoveBulletUnity>();

            //The bullet needs a reference to this object pool so we can return it to the pool when it dies
            moveBulletScript.objectPool = allBullets;

            return moveBulletScript;
        }



        //Called when an item is taken from the pool using pool.Get()
        private void OnTakeFromPool(MoveBulletUnity bullet)
        {
            bullet.gameObject.SetActive(true);
        }



        //Called when an item is returned to the pool using pool.Release()
        private void OnReturnedToPool(MoveBulletUnity bullet)
        {
            bullet.gameObject.SetActive(false);
        }



        //If the pool capacity is reached then any items returned will be destroyed
        private void OnDestroyPoolObject(MoveBulletUnity bullet)
        {
            Debug.Log("Destroyed pooled object");
        
            Destroy(bullet.gameObject);
        }



        //Get a bullet from the pool
        public GameObject GetBullet()
        {
            //Get an instance from the pool. If the pool is empty then a new instance will be created
            //https://docs.unity3d.com/ScriptReference/Pool.IObjectPool_1.html
            GameObject newBullet = allBullets.Get().gameObject;

            return newBullet;
        }
    }
}