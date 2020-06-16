using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer.StaticEvents
{
    public class Enemy : MonoBehaviour
    {
        //Because this is static we only need to subscribe to this event once
        public static event Action<Enemy> onAnyEnemyDie;
        //What the enemy is worth
        public int enemyValue { get; private set; }


        void Start()
        {

        }


        void Update()
        {

        }


        private void OnDisable()
        {
            enemyValue = UnityEngine.Random.Range(0, 5);

            //Debug.Log(enemyValue);

            //Invoke the event and to each method that subscribes to the event we will send a reference to this object
            onAnyEnemyDie?.Invoke(this);

            //This is also working, but is less clear
            //onAnyEnemyDie(this);
        }
    }
}
