using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Update.CustomUpdateMethod
{
    //Attach to all object that should have a custom Update (and Start) method 
    //The parent class will handle the registration of the OnUpdate method
    public class ObjectWithCustomUpdateMethod : UpdateableComponent
    {
        private const float SPEED = 10f;

        private const float MAP_RADIUS = 10f;


        //Custom start, which will be called from the parent which uses Unity's Start() method
        protected override void OnStart()
        {
            Debug.Log($"[{this.name}]Custom Start is working");

            //Generate a random direction
            transform.rotation = GetRandomDirection();
        }


        //Custom Update() 
        //dt is Time.deltaTime
        public override void OnUpdate(float dt)
        {
            //Move forward
            Vector3 newPos = transform.position + transform.forward * SPEED * dt;

            //Are we outside of the circle?
            if ((newPos - Vector3.zero).sqrMagnitude > MAP_RADIUS * MAP_RADIUS)
            {
                //If so we cant move and have to change directon
                transform.rotation = GetRandomDirection();
            }
            //Move to the new postion
            else
            {
                transform.position = newPos;
            }
        }


        //Generate a quaternion with a random rotation around y axis
        private Quaternion GetRandomDirection()
        {
            Quaternion randomDir = Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f));

            return randomDir;
        }
    }
}
