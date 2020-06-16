using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flyweight
{
    //This class doesn't share any data among all objects
    public class Heavy
    {
        private float health;

        private Data data;


        public Heavy()
        {
            health = Random.Range(10f, 100f);

            data = new Data();
        }
    }
}
