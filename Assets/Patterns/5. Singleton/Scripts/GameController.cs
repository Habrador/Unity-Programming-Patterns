using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SingletonPattern
{
    public class GameController : MonoBehaviour
    {

        void Start()
        {
            TestCSharpSingleton();

            //TestUnitySingleton();
        }


        void Update()
        {

        }



        private void TestCSharpSingleton()
        {
            //Is not working because this is a singleton with a private constructor
            //SingletonCSharp singletonCSharp = new SingletonCSharp();

            //This is working
            SingletonCSharp instance = SingletonCSharp.Instance;

            instance.TestSingleton();

            SingletonCSharp instance2 = SingletonCSharp.Instance;

            instance2.TestSingleton();
        }



        private void TestUnitySingleton()
        {
            SingletonUnity instance = SingletonUnity.Instance;

            instance.TestSingleton();

            SingletonUnity instance2 = SingletonUnity.Instance;

            instance2.TestSingleton();
        }
    }
}
