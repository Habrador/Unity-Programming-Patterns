using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Update.CustomUpdateMethod
{
    //Base class for objects with a custom Update method
    public class UpdateableComponent : MonoBehaviour, IUpdateable
    {
        //Unity's method which is working fine because the class inherits from MonoBehaviour
        private void Start()
        {
            //Register the object 
            GameController.RegisterUpdateableObject(this);

            OnStart();
        }


        //This is a custom Start method which the child can override, because we can't use Unity's Start in both parent and child
        protected virtual void OnStart()
        {

        }


        //Custom update method, which the child can override
        public virtual void OnUpdate(float dt)
        {

        }      


        private void OnDestroy()
        {
            //Unegister the object
            //Remember that it's dangerous to call another method in OnDestroy() because the other method might already be destroyed
            GameController.UnregisterUpdateableObject(this);
        }
    }
}
