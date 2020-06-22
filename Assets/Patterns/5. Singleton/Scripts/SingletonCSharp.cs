using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Basic Singleton pattern implementation in C#
//

namespace SingletonPattern
{
    //This is the most simplest Singleton pattern. The problem is that it's not thread safe. If you want a thread safe Singleton, then visit the link: https://csharpindepth.com/articles/singleton
    public class SingletonCSharp
    {
        //A static variable which holds a reference to the single created instance
        private static SingletonCSharp instance = null;



        //For testing that we only call the constructor once
        private float randomNumber;



        //A public static means of getting the reference to the single created instance, creating one if necessary
        public static SingletonCSharp Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonCSharp();
                }

                return instance;
            }
        }



        //A single constructor, which is private and parameterless (singletons are not allowed to have parameters)
        //This prevents other classes from instantiating it and it also prevents subclassing (which both are violating the pattern)
        //But some argue that you should be able to inherit from singletons...
        private SingletonCSharp()
        {
            randomNumber = Random.Range(0f, 1f);
        }



        //For testing
        public void TestSingleton()
        {
            Debug.Log($"Hello this is Singleton, my random number is: {randomNumber}");
        }
    }
}
