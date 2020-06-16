using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Observer.DifferentEvents
{
    //A summary of all different events alternatives
    public class DifferentEventAlternatives : MonoBehaviour
    {
        //
        // Built-in event handling 
        //

        //C# built-in EventHandler
        //Requires "using System;"
        public event EventHandler myCoolEvent;
        //With parameters
        public event EventHandler<MyName> myCoolEventWithParameters;


        //C# built-in Action
        //If we have more parameters we can use Action. Compared with EventHandler, the parameters dont have to inherit from EventArgs
        public event Action<MyName, MyAge> myCoolEventAction;


        //Unity built-in UnityEvent
        //Requires that we are "using UnityEngine.Events;"
        public UnityEvent coolUnityEvent = new UnityEvent();
        //If you have parameters you have to create a new event class that inherits from UnityEvent<parameter1, parameter2, ...>
        public MyCustomUnityEvent coolCustomUnityEvent = new MyCustomUnityEvent();
        //There's also something called UnityAction
        //You can add multiple methods to a single UnityAction, and we can add multiple UnityAction to a single UnityEvent
        //The UnityEvent will then trigger all UnityAction associated with it, which will in turn trigger all methods associated with the UnityAction
        //This will make it easier to remove groups if you attach group to a single UnityAction, then you can just remove it
        //Create a UnityAction: UnityAction unityAction = new UnityAction(SomeMethodThatShouldBeCalled);
        //Add a new method to the same UnityAction: unityAction += SomeOtherMethodThatShouldBeCalled

        //The problem with UnityEvents
        //To get how many are listening to an event: thisEvent.GetPersistentEventCount(); BUT this number is not always accurate because Unity is for some reason only counting permanently serialized (like the ones you add in inspector) - not the ones you add in code. If you need this function you have to use C# events



        //
        // Custom event handling
        //

        //Custom delegate with the same parameters as built-in EventHandler
        public delegate void MyEventHandler(object sender, EventArgs e);
        //Custom delegate with no parameters
        public delegate void MyEventHandlerEmpty();

        //The event belonging to the custom delegate
        public event MyEventHandlerEmpty MyCoolCustomEvent;



        void Start()
        {
            //MyCoolEvent += DisplayStuff;

            //MyCoolEventWithParameters += DisplayStuffCustom;

            //MyCoolEventAction += DisplayStuffCustomBig;

            //CoolUnityEvent.AddListener(DisplayStuffEmpty);

            coolCustomUnityEvent.AddListener(DisplayStuffCustomParameters);

            //MyCoolCustomEvent += DisplayStuffEmpty;
        }



        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Built-in
                //myCoolEvent?.Invoke(this, null);

                //MyCoolEventWithParameters?.Invoke(this, new MyName("InsertFunnyName"));

                //MyCoolEventAction?.Invoke(new MyName("InsertFunnyName"), new MyAge(5));

                //CoolUnityEvent?.Invoke();

                coolCustomUnityEvent?.Invoke(new MyName("InsertFunnyName"), new MyAge(5));

                //Custom
                //MyCoolCustomEvent?.Invoke(this, null);

                //MyCoolCustomEvent?.Invoke();
            }
        }



        //What the event will trigger
        private void DisplayStuff(object sender, EventArgs args)
        {
            Debug.Log("Hello this is DisplayStuff");
        }

        private void DisplayStuffCustomArgs(object sender, MyName args)
        {
            Debug.Log($"Hello my name is {args.name}");
        }

        private void DisplayStuffCustomParameters(MyName myName, MyAge myAge)
        {
            Debug.Log($"Hello my name is {myName.name} and my age is {myAge.age}");
        }

        private void DisplayStuffEmpty()
        {
            Debug.Log("Hello this is empty");
        }
    }



    //Parameters in EventHandler have to inherit from EventArgs
    public class MyName : EventArgs
    {
        public string name;

        public MyName(string name)
        {
            this.name = name;
        }
    }

    public class MyAge
    {
        public int age;

        public MyAge(int age)
        {
            this.age = age;
        }
    }



    //To make parameters work with UnityEvents
    public class MyCustomUnityEvent : UnityEvent<MyName, MyAge>
    {
        //Should be empty
    }
}
