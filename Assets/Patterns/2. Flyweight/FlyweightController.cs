using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flyweight
{
    //Illustrates the flyweight pattern
    //Open the profiler and click on Memory to see how much memory is being used
    //Switch between Heavy and Flyweight to compare and you should see that the difference is several hundred megabytes even though the data in this case is just 20 doubles
    public class FlyweightController : MonoBehaviour
    {
        private List<Heavy> heavyObjects = new List<Heavy>();

        private List<Flyweight> flyweightObjects = new List<Flyweight>();


        void Start()
        {
            int numberOfObjects = 1000000;


            //Generate Heavy objects that doesn't share any data
            for (int i = 0; i < numberOfObjects; i++)
            {
                Heavy newHeavy = new Heavy();

                heavyObjects.Add(newHeavy);
            }


            //Generate Flyweight objects

            //Generate the data that's being shared among all objects
            //Data data = new Data();

            //for (int i = 0; i < numberOfObjects; i++)
            //{
            //    Flyweight newFlyweight = new Flyweight(data);

            //    flyweightObjects.Add(newFlyweight);
            //}
        }
    }
}
