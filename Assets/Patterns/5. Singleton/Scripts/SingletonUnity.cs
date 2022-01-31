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
                    // Find singleton of this type in the scene
                    var instance = GameObject.FindObjectOfType<SingletonUnity>();

                    // If there is no singleton object in the scene, we have to add one
                    if (instance == null)
                    {
                        GameObject obj = new GameObject("Unity Singleton");
                        instance = obj.AddComponent<SingletonUnity>();

                        //Init the singleton
                        instance.FakeConstructor();

                        // The singleton object shouldn't be destroyed when we switch between scenes
                        DontDestroyOnLoad(obj);
                    }
                }

                return instance;
            }
        }

        void Awake()
        {
            if (instance == null)
            {
                instance = this;

                // Init the singleton
                instance.FakeConstructor();

                // The singleton object shouldn't be destroyed when we switch between scenes
                DontDestroyOnLoad(this.gameObject);
            }
            // because we inherit from MonoBehaviour whem might have accidentally added several of them to the scene,
            // which will cause trouble, so we have to make sure we have just one!
            else
            {
                Destroy(gameObject);
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
