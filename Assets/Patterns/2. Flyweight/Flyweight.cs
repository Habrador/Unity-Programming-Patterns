using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flyweight
{
    public class Flyweight
    {
        //Data for each individual object
        private float health;

        //This is the data that's being shared among all objects so you have to inject it in the constructor
        private Data data;


        public Flyweight(Data data)
        {
            health = Random.Range(10f, 100f);

            this.data = data;
        }
    }
}
