using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Basic Singleton pattern implementation in Unity
//

namespace SingletonPattern
{
    //A translation of the most basic Singleton pattern to Unity script which inherits from MonoBehaviour
    public class SingletonUnity : MonoBehaviour
    {
        //A static variable which holds a reference to the single created instance
        private static SingletonUnity instance = null;



        //For testing that we only call the constructor once
        private float randomNumber;



        //A public static means of getting the reference to the single created instance, creating one if necessary
        public static SingletonUnity Instance
        {
            get
            {
                if (instance == null)
                {
                    //If a script in Unity inherits from MonoBehaviour, we can't use the new keyword to create a new Singleton as we did before
                    //So you have to manually add this script to a gameobject in the scene
                    //But because we inherit from MonoBehaviour whem might have accidentally added several of them to the scene, which will cause trouble, so we have to make sure we have just one!

                    //Find all singletons of this type in the scene
                    SingletonUnity[] allSingletonsInScene = GameObject.FindObjectsOfType<SingletonUnity>();

                    if (allSingletonsInScene != null && allSingletonsInScene.Length > 0)
                    {
                        //Destroy all but one singleton
                        if (allSingletonsInScene.Length > 1)
                        {
                            Debug.LogWarning($"You have more than one SingletonUnity in the scene!");

                            for (int i = 1; i < allSingletonsInScene.Length; i++)
                            {
                                Destroy(allSingletonsInScene[i].gameObject);
                            }
                        }

                        //Now we should have just one singleton in the scene, so pick it
                        instance = allSingletonsInScene[0];

                        //Init the singleton
                        instance.FakeConstructor();
                    }
                    //We have no singletons in the scene
                    else
                    {
                        Debug.LogError($"You need to add the script SingletonUnity to a gameobject in the scene!");
                    }
                }

                return instance;
            }
        }



        //Because this script inherits from MonoBehaviour, we cant use a constructor, so we have to invent our own
        private void FakeConstructor()
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
