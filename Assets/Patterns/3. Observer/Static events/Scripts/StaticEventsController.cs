using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer.StaticEvents
{
    //Will illustrate static events
    //Basic idea is that when an enemy dies, we add to the score
    public class StaticEventsController : MonoBehaviour
    {
        public Enemy enemyPrefab;

        private int score;

        private int enemiesKilled = 0;


        void Awake()
        {
            //Subscribe to the event that's happening each time an enemy dies
            //Multiple things may happen when an enemy dies, so better to have the event in the enemy class!
            //Because this is a static event we only need to subscribe once and not to each enemy instance
            Enemy.onAnyEnemyDie += AddToScore;
        }


        void Update()
        {
            //Spawn new enemies that will die after some time
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject newEnemy = Instantiate(enemyPrefab.gameObject, Random.insideUnitSphere, Quaternion.identity) as GameObject;

                //Kill the enemy automatically after 3 seconds which will trigger the event
                Destroy(newEnemy, 3f);
            }
        }


        //This method subscribes to the event
        void AddToScore(Enemy enemyScript)
        {
            score += enemyScript.enemyValue;

            enemiesKilled += 1;

            Debug.Log($"You've killed {enemiesKilled} enemies and the score is: {score}");
        }
    }
}
